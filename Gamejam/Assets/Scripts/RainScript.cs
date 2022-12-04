using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    GameObject mainCamera;
    ParticleSystem particleSystem;
    
    private bool endSequence;
    
    public void StartEndSequence()
    {
        endSequence = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        particleSystem = this.GetComponent<ParticleSystem>();
        
        endSequence = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(mainCamera.transform.position.x, this.transform.position.y, 0.0f);
        
        if (!endSequence)
        {
            var blackOrbRate = Inventory.instance.GetBlackOrbRate();
        
            float amplifier = 0.0f;
            
            if (blackOrbRate > 0.5f)
            {
                amplifier += 350.0f * blackOrbRate;
            }
            
            var emissionSys = particleSystem.emission;
            emissionSys.rateOverTime = 150 + amplifier;
            
            AudioManager.instance.Play("Rain");
        }
        else
        {
            var emissionSys = particleSystem.emission;
            AudioManager.instance.Stop("Rain");
            
            if (emissionSys.rateOverTime.constant > 0.0f)
            {
                emissionSys.rateOverTime = emissionSys.rateOverTime.constant - 2;
            }
        }
    }
}

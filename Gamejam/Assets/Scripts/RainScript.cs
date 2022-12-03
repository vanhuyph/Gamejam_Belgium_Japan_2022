using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    GameObject mainCamera;
    ParticleSystem particleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        particleSystem = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(mainCamera.transform.position.x, this.transform.position.y, 0.0f);
        
        var blackOrbRate = Inventory.instance.GetBlackOrbRate();
        
        float amplifier = 0.0f;
        
        if (blackOrbRate > 0.5f)
        {
            amplifier += 350.0f * blackOrbRate;
        }
        
        var emissionSys = particleSystem.emission;
        emissionSys.rateOverTime = 150 + amplifier;
    }
}

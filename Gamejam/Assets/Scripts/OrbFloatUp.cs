using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbFloatUp : MonoBehaviour
{
    [SerializeField] float floatDistance = 4.0f;
    
    Vector3 startingPosition;
    
    private void Start()
    {
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.instance.GetBlackOrbRate() > 0.55f)
        {
            this.transform.position = startingPosition + new Vector3(0.0f, floatDistance, 0.0f);
        }
        else
        {
            this.transform.position = startingPosition;
        }
    }
}
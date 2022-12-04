using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodingScript : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        if (Inventory.instance.GetBlackOrbRate() > 0.501f)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = mainCamera.transform.position + new Vector3(0.0f, 10.0f, 0.0f);
    }
}

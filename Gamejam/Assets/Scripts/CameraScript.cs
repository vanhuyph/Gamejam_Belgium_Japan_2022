using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject playerObj;
    
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var minPos = -2.0f;
        var maxPos = 20.0f;
        
        transform.position = playerObj.transform.position + new Vector3(0.0f, 2.0f, -10.0f);
        
        var posX = Mathf.Clamp(transform.position.x, minPos, maxPos);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}

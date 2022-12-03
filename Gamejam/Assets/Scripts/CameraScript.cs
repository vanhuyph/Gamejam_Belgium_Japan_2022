using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject playerObj;
    
    [SerializeField] float minPos = -5.0f;
    [SerializeField] float maxPos = 100.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerObj.transform.position + new Vector3(0.0f, 2.0f, -10.0f);
        
        var posX = Mathf.Clamp(transform.position.x, minPos, maxPos);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}

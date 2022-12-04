using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
	
	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smoothing = 1f;
	
	private Transform cam;
	private Vector3 previousCamPosition;
	
	void Awake()
	{
		cam = Camera.main.transform;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        previousCamPosition = cam.position;
		parallaxScales = new float[backgrounds.Length];
		
		for(int i = 0; i < backgrounds.Length; i++)
		{
			parallaxScales[i] = backgrounds[i].position.z;
		}
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < backgrounds.Length; i++)
		{
			float parallax = (cam.position.x - previousCamPosition.x) * parallaxScales[i];
			
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			float backgroundPosY = backgrounds[i].position.y;
			float backgroundPosZ = backgrounds[i].position.z;
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundPosY, backgroundPosZ);
			
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		
		previousCamPosition = cam.position;
    }
}

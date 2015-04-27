using UnityEngine;
using System.Collections;

public class CameraAspect : MonoBehaviour {
	
	// Use this for initialization
	void Start()
	{
		Camera camera = GetComponent<Camera>();
		
		float targetAspect = 10f / 16f;// desired aspect
		float currentAspect = (float)Screen.width / (float)Screen.height;// current aspect ratio
		float scale = currentAspect / targetAspect;
		Rect newRect = camera.rect;
		
		// target has bigger width, smallre height
		if (scale < 1f){
			newRect.width = 1f;
			newRect.height = scale; //decrease current hight
			newRect.x = 0;
			newRect.y = (1f - scale) / 2f;
		}
		
		// target has smaller width, bigger height
		else{
			float scaleWidth = 1f / scale;
			newRect.width = scaleWidth;
			newRect.height = 1f;
			newRect.x = (1f - scaleWidth) / 2f;
			newRect.y = 0;		
		}
		
		camera.rect = newRect;// update 
		
	}
}

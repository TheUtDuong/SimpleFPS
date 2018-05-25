using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooterComponent : MonoBehaviour {

	public Camera Camera;
	public GameObject PrefabMarker;

	void Start()
	{
		Camera = GetComponent<Camera>();		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;	
	}

}

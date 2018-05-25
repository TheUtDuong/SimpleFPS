using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationAxes
{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
}

public class MouseLookComponent : MonoBehaviour 
{
	
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;
	
	public float rotationX = 0;
}

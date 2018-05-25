using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[UpdateInGroup(typeof(BehaviorUpdateGroup))]
public class MouseLookSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentArray<MouseLookComponent> MouseLook;
		public ComponentArray<MouseInputComponent> MouseInput;
		public ComponentArray<Transform> Transform;
		public EntityArray Entities;
	}
	[Inject]private Data m_Data;
    protected override void OnUpdate()
    {
        for(int i = 0; i < m_Data.Length; i++)
		{
			var e = m_Data.Entities[i];
			var mouseLook = m_Data.MouseLook[i];
			var transform = m_Data.Transform[i];
			var mouseInput = m_Data.MouseInput[i];
			if(mouseLook.axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, mouseLook.sensitivityHor * mouseInput.horizontal,0);
			}
			if(mouseLook.axes == RotationAxes.MouseY)
			{
				mouseLook.rotationX -= mouseInput.vertical * mouseLook.sensitivityVert;
				mouseLook.rotationX = Mathf.Clamp(mouseLook.rotationX, mouseLook.minimumVert, mouseLook.maximumVert);

				float rotationY = transform.localEulerAngles.y;
				transform.localEulerAngles = new Vector3(mouseLook.rotationX, rotationY, 0);
			}
			if(mouseLook.axes == RotationAxes.MouseXAndY)
			{
				mouseLook.rotationX -= mouseInput.vertical * mouseLook.sensitivityVert;
				mouseLook.rotationX = Mathf.Clamp(mouseLook.rotationX, mouseLook.minimumVert, mouseLook.maximumVert);

				float delta = mouseInput.horizontal * mouseLook.sensitivityHor;
				float rotationY = transform.localEulerAngles.y + delta;
				transform.localEulerAngles = new Vector3(mouseLook.rotationX, rotationY, 0);
			}
		}
    }
}

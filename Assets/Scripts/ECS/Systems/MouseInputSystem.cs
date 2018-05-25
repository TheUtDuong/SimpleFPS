using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[UpdateInGroup(typeof(InputUpdateGroup))]
public class MouseInputSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentArray<MouseInputComponent> MouseInput;
	}
	[Inject] Data m_Data;
    protected override void OnUpdate()
    {
        for(int i = 0; i < m_Data.Length; i++)
		{
			var MouseInput = m_Data.MouseInput[i];
			MouseInput.horizontal = Input.GetAxis("Mouse X");
			MouseInput.vertical = Input.GetAxis("Mouse Y");
		}
    }
}

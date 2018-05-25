using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[UpdateInGroup(typeof(InputUpdateGroup))]
public class ShootInputSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentArray<ShootInputComponent> ShootInput;
        public EntityArray Entities;
	}
    [Inject] Data m_Data;
    protected override void OnUpdate()
    {
        for(int i = 0; i < m_Data.Length; i++)
        {
			var shootInput = m_Data.ShootInput[i];
			shootInput.IsShooting = Input.GetMouseButtonDown(0);
		}
    }
}

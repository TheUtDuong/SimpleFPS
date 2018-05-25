using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[UpdateInGroup(typeof(InputUpdateGroup))]
public class FPInputSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentArray<FPInputComponent> FPInput;
	}
    [Inject] Data m_Data;
    protected override void OnUpdate()
    {
        for(int i = 0; i < m_Data.Length; i++)
        {
            var FPSInput = m_Data.FPInput[i];
            FPSInput.Horizontal = Input.GetAxis("Horizontal");
            FPSInput.Vertical = Input.GetAxis("Vertical");
        }
    }
}

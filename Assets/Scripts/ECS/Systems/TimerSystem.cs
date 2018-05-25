using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[UpdateBefore(typeof(BehaviorUpdateGroup))]
public class TimerSystem : ComponentSystem {
    
	struct Data
	{
		public int Length;
		public ComponentArray<TimerComponent> Timer;
		public EntityArray Entities;
	}
	[Inject] Data m_Data;
	protected override void OnUpdate()
    {
		var dT = Time.deltaTime;
        for(int i = 0; i < m_Data.Length; i++)
		{
			var timer = m_Data.Timer[i];
			timer.Value -= Time.deltaTime;
		}
    }

}

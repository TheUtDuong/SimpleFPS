using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[UpdateInGroup(typeof(BehaviorUpdateGroup))]
public class DestroyAfterTimeSystem : ComponentSystem {

	struct Data
	{
		public int Length;
		public ComponentArray<TimerComponent> Timer;
		public ComponentArray<DestroyAfterTimeComponent> DestroyAfterTime;
		public EntityArray Entities;
	}
	[Inject] Data m_Data;
	protected override void OnUpdate()
    {
		
        for(int i = 0; i < m_Data.Length; i++)
		{
			var e = m_Data.Entities[i];
			var timer = m_Data.Timer[i];
			if(timer.Value <= 0)
			{			
				PostUpdateCommands.AddComponent(e, new Destroy());
			}
		}
    }
}

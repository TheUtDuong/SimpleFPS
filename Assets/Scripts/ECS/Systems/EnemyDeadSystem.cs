using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class EnemyDeadSystem : ComponentSystem {
    
    struct Data
	{
		public int Length;
		public ComponentDataArray<DeadComponent> Dead;
		public ComponentArray<EnemyComponent> Enemy;
		public GameObjectArray GameObject;
		public EntityArray Entities;
	}
	[Inject] Data m_Data;
	protected override void OnUpdate()
    {
		var dT = Time.deltaTime;
        for(int i = 0; i < m_Data.Length; i++)
		{
			var gameObject = m_Data.GameObject[i];
			var dead = m_Data.Dead[i];
			var e = m_Data.Entities[i];
			if(EntityManager.HasComponent<TargetableComponent>(e))
			{
				PostUpdateCommands.RemoveComponent<TargetableComponent>(e);
			}
			dead.Timer -= dT;
			gameObject.transform.Rotate(75 * dT,0,0);
			if(dead.Timer <= 0)
			{
				PostUpdateCommands.AddComponent(e, new Destroy());
			}
			else{
				EntityManager.SetComponentData<DeadComponent>(e, dead);
			}
			
		}
    }

}

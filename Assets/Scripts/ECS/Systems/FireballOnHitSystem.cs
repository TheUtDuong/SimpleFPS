using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class FireballOnHitSystem : ComponentSystem {

	struct Data
	{
		public int Length;
		public ComponentDataArray<FireBallOnHitComponent> FireballOnHit;
		public ComponentDataArray<OnTriggerEnterComponent> OnTriggerEnterComponent;
		public EntityArray Entities;
	}
	[Inject] Data m_Data;

    protected override void OnUpdate()
    {
        var dT = Time.deltaTime;
		for(int i = 0; i < m_Data.Length; i++)
		{
			var onTriggerEnter = m_Data.OnTriggerEnterComponent[i];
			var entity = m_Data.Entities[i];
			if(EntityManager.HasComponent<HealthComponent>(onTriggerEnter.Target))
			{
				var sourceEntity = onTriggerEnter.Source;
				var targetEntity = onTriggerEnter.Target;

				var fireBall = EntityManager.GetComponentData<Fireball>(sourceEntity);
				var targetHealth = EntityManager.GetComponentData<HealthComponent>(targetEntity);
				targetHealth.Value -= fireBall.Damage;
				Debug.Log(targetHealth.Value);
				EntityManager.SetComponentData<HealthComponent>(targetEntity, targetHealth);
				EntityManager.AddComponent(sourceEntity, typeof(Destroy));
				PostUpdateCommands.DestroyEntity(entity);
			}
		}
    }
}

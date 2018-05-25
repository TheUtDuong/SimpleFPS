using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class WanderingAISystem : ComponentSystem {
    
	struct Data
	{
		public int Length;
		public ComponentArray<WanderingAIComponent> WanderingAI;
		public SubtractiveComponent<DeadComponent> Dead;
		public GameObjectArray GameObject;
		public EntityArray Entities;
	}
	[Inject] Data m_Data;

	struct TargetData
	{
		public int Length;
		public EntityArray Entities;
	}
	[Inject] TargetData m_TargetData;

	protected override void OnUpdate()
    {
		var dT = Time.deltaTime;
        for(int i = 0; i < m_Data.Length; i++)
		{
			var gameObject = m_Data.GameObject[i];
			var transform = gameObject.transform;
			var wanderingAI = m_Data.WanderingAI[i];
			transform.Translate(0, 0, wanderingAI.Speed * dT);
			wanderingAI.Timer -= dT;
			

			if(wanderingAI.Timer <= 0)
			{
				Ray ray = new Ray(transform.position, transform.forward);
				RaycastHit hit;
				if(Physics.SphereCast(ray, 0.75f, out hit))
				{
					var hitTarget = hit.transform.gameObject;
					var gameObjectEntity = hitTarget.GetComponent<GameObjectEntity>();
					if(gameObjectEntity != null && EntityManager.HasComponent<PlayerComponent>(gameObjectEntity.Entity))
					{			
						var _fireball = GameObject.Instantiate(wanderingAI.ProjectilePrefab) as GameObject;
						_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
						_fireball.transform.rotation = transform.rotation;				
					}
					else if(hit.distance < wanderingAI.ObstacleRange)
					{
						float angle = Random.Range(-110, 110);
						transform.Rotate(0,angle,0);
					}
				}
				wanderingAI.Timer = wanderingAI.ScanRate;
			}
			
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[UpdateInGroup(typeof(BehaviorUpdateGroup))]
public class SpawningSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentArray<SpawnerComponent> Spawner;
	}
	[Inject] Data m_Data;

    protected override void OnUpdate()
    {
		var dT = Time.deltaTime;
        for(int i = 0; i < m_Data.Length; i++)
		{
			var spawner = m_Data.Spawner[i];
			spawner.Timer -= dT;
			if(spawner.Timer <= 0)
			{
				float angle = Random.Range(0,360);
				var go = GameObject.Instantiate(spawner.PrefabToSpawn, spawner.LocationToSpawn, Quaternion.identity);
				go.transform.Rotate(0,angle,0);
				spawner.Timer = spawner.Cooldown;
			}
		}
    }
}

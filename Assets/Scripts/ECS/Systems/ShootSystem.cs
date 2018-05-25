using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[UpdateInGroup(typeof(BehaviorUpdateGroup))]
public class ShootSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentArray<ShootInputComponent> ShootInput;
		public ComponentArray<RayShooterComponent> RayShooter;
	}
	struct TargetData
	{
		public int Length;
		public ComponentArray<TargetableComponent> Targetable;
		public EntityArray Entities;
	}
    [Inject] Data m_Data;
	[Inject] TargetData m_TargetData;

    protected override void OnUpdate()
    {
        for(int i = 0; i < m_Data.Length; i++)
        {
			var shootInput = m_Data.ShootInput[i];
			var rayShooter = m_Data.RayShooter[i];
			var rayShooterCamera = rayShooter.Camera;;
			if(shootInput.IsShooting)
			{
				Vector3 point = new Vector3(rayShooterCamera.pixelWidth/2, rayShooterCamera.pixelHeight/2,0);
				Ray ray = rayShooterCamera.ScreenPointToRay(point);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit))
				{
					var hitObject = hit.collider.gameObject;
					bool targetable = false;
					int index = 0;
					for(int j = 0; j < m_TargetData.Length; j++)
					{
						if(hitObject == m_TargetData.Targetable[j].gameObject)
						{
							targetable = true;
							index = j;
							break;
						}
					}

					if(targetable)
					{
						PostUpdateCommands.AddComponent(m_TargetData.Entities[index], new DeadComponent(){Timer = 1f});
					}
					var go = GameObject.Instantiate(rayShooter.PrefabMarker, hit.point, Quaternion.identity);
					go.transform.SetParent(hit.collider.gameObject.transform);
					
				}
			}
		}
    }
}

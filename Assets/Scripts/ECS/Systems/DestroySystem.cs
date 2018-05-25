using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[UpdateInGroup(typeof(PostUpdateGroup))]
public class DestroySystem : ComponentSystem {
		struct Data
		{
			public int Length;
			public ComponentDataArray<Destroy> Destroy;
			public GameObjectArray Go;
		}
		[Inject] Data m_Data;
		protected override void OnUpdate()
		{
			if(m_Data.Length > 0)
			{
				List<GameObject> toDestroy = new List<GameObject>();
				for(int i = 0; i < m_Data.Length; i++)
				{	
					toDestroy.Add(m_Data.Go[i]);
				}
				foreach(var go in toDestroy)
				{
					Object.Destroy(go);
				}
			}
		}
	}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class FireBallSystem : ComponentSystem
{
	struct Data
	{
		public int Length;
		public ComponentDataArray<Fireball> Fireball;
		public ComponentArray<Transform> Transform;
	}
	[Inject] Data m_Data;

    protected override void OnUpdate()
    {
        var dT = Time.deltaTime;
		for(int i = 0; i < m_Data.Length; i++)
		{
			var transform = m_Data.Transform[i];
			var fireBall = m_Data.Fireball[i];
			transform.Translate(0,0, fireBall.Speed * dT);
		}
    }
}

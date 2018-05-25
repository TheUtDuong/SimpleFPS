using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[Serializable]
public struct Fireball : IComponentData {
	public float Speed;
	public int Damage;	
}

public class FireBallComponent : ComponentDataWrapper<Fireball>
{
	void OnTriggerEnter(Collider other)
	{
		var e = OnTriggerEmitter.OnTriggerEnter(other, this.gameObject);
		if(e != null)
		{
			var entityManager = World.Active.GetExistingManager<EntityManager>();
			entityManager.AddComponent(e, typeof(FireBallOnHitComponent));
		}
	}
}

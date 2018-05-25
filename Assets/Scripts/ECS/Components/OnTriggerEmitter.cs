using System;
using UnityEngine;
using Unity.Entities;

[Serializable]
public struct OnTriggerEnterComponent : IComponentData
{
	public Entity Target;
	public Entity Source;
}

public static class OnTriggerEmitter {

	public static Entity OnTriggerEnter(Collider other, GameObject source)
	{
		var otherE = other.GetComponent<GameObjectEntity>();
		if(otherE)
		{
			var entityManager = World.Active.GetExistingManager<EntityManager>();
			Entity sourceEntity = source.GetComponent<GameObjectEntity>().Entity;
			var e = entityManager.CreateEntity(typeof(OnTriggerEnterComponent));
			entityManager.SetComponentData(e, new OnTriggerEnterComponent(){
				Target = otherE.Entity,
				Source = sourceEntity
			});	
			return e;	
		}
		return Entity.Null;
		
	}
}

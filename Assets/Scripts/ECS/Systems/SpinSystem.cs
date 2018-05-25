using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpinSystem : ComponentSystem
{
    struct Data
    {
        public int Length;
        public ComponentDataArray<Spin> Spin;
        public ComponentArray<Transform> Transform;
        public EntityArray Entities;
    }

    [Inject]private Data m_Data;
    protected override void OnUpdate()
    {
        var dt = Time.deltaTime;
        for(int i = 0; i < m_Data.Length; i++)
        {
            var e = m_Data.Entities[i];
            var spin = m_Data.Spin[i];
            var transform = m_Data.Transform[i];
            transform.Rotate(0,spin.Speed,0);
            if(EntityManager.HasComponent<Spin>(e))
            {
                //Debug.Log("I have the component");
            }
        }
        
            
        
    }
}

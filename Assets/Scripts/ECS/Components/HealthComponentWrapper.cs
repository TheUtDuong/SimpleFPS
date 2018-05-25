using System;
using UnityEngine;
using Unity.Entities;
[Serializable]
public struct HealthComponent : IComponentData
{
    public int Value;
}

public class HealthComponentWrapper : ComponentDataWrapper<HealthComponent>{}

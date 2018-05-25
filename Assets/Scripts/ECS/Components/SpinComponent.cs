using System;
using UnityEngine;
using Unity.Entities;
[Serializable]
public struct Spin : IComponentData 
{
	public float Speed;
}

public class SpinComponent : ComponentDataWrapper<Spin>{}


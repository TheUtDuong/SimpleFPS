using UnityEngine;
using Unity.Entities;
[System.Serializable]
public struct PlayerComponent : IComponentData {}

public class PlayerComponentWrapper : ComponentDataWrapper<PlayerComponent>{}
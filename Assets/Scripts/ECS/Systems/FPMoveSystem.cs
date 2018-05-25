using UnityEngine;
using Unity.Entities;

[UpdateInGroup(typeof(BehaviorUpdateGroup))]
public class FPMoveSystem : ComponentSystem
{
	private const float GRAVITY = -9.8f;
	struct Data
	{
		public int Length;
		public ComponentArray<FPInputComponent> FPInput;
		public ComponentArray<FPMovementComponent> FPMovement;
		public ComponentArray<CharControllerComponent> CharController;
		public ComponentArray<Transform> Transform;
        public EntityArray Entities;
	}
    [Inject] Data m_Data;
    protected override void OnUpdate()
    {
        for(int i = 0; i < m_Data.Length; i++)
        {
            var fpsInput = m_Data.FPInput[i];
			var fpsMovement = m_Data.FPMovement[i];
			var transform = m_Data.Transform[i];
			var controller = m_Data.CharController[i];
			if(Mathf.Abs(fpsInput.Horizontal) > 0 || Mathf.Abs(fpsInput.Vertical) > 0)
			{
				float deltaX = fpsInput.Horizontal * fpsMovement.Speed;
				float deltaZ = fpsInput.Vertical * fpsMovement.Speed;
				var movement = new Vector3(deltaX, 0, deltaZ);
				movement = Vector3.ClampMagnitude(movement, fpsMovement.Speed);
				movement.y = GRAVITY;
				movement *= Time.deltaTime;
				movement = transform.TransformDirection(movement);
				controller.Controller.Move(movement);
			}
			else{
				var movement = new Vector3(0, 0, 0);
				movement.y = GRAVITY;
				movement *= Time.deltaTime;
			    controller.Controller.Move(movement);
			}
            
        }
    }
}

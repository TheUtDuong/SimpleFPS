using UnityEngine;

public class CharControllerComponent : MonoBehaviour {

	public CharacterController Controller;
	public void Awake()
	{
		Controller = GetComponent<CharacterController>();
	}
}

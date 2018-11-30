using UnityEngine;

public class CameraBehaviour : MonoBehaviour 
{

	[SerializeField] private GameObject _head;
	private Quaternion fixedRot;
	
	void Update() 
	{
		fixedRot = _head.transform.rotation;

		Quaternion _rot = Quaternion.Euler(fixedRot.x, fixedRot.y, fixedRot.z);

		transform.rotation = _rot;

		transform.position = new Vector3(_head.transform.position.x, _head.transform.position.y + 2f, _head.transform.position.z);
	}
}

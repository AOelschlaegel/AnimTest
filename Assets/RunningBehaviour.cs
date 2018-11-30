using UnityEngine;

public class RunningBehaviour : MonoBehaviour 
{

	[SerializeField] private Camera _mainCamera;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Ground")
		{
			var lastCameraPos = _mainCamera.transform.position;
			var newCameraPos = new Vector3(lastCameraPos.x, lastCameraPos.y + 3f, lastCameraPos.z);

			_mainCamera.transform.position = Vector3.Lerp(lastCameraPos, newCameraPos, Time.deltaTime);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Ground")
		{
			var lastCameraPos = _mainCamera.transform.position;
			var newCameraPos = new Vector3(lastCameraPos.x, lastCameraPos.y - 3f, lastCameraPos.z);

			_mainCamera.transform.position = Vector3.Lerp(lastCameraPos, newCameraPos, Time.deltaTime);
		}
	}

	void Update() 
	{
		
	}
}

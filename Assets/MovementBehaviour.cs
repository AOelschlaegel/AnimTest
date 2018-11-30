using System.Collections;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

	private float _movementSpeed;
	public float DefaultSpeed;
	private float _rotationSpeed = 150f;
	private float _sprintSpeed = 2;
	private Animator _animator;
	private bool _isTurning;

	void Start()
	{
		_animator = GetComponent<Animator>();
		_movementSpeed = DefaultSpeed;
	}

	void Update()
	{
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float translation = Input.GetAxis("Vertical") * _movementSpeed;
		float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;

		if (Input.GetAxis("Vertical") > .1f)
		{
			_animator.SetBool("isMoving", true);

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				_animator.SetBool("isRunning", true);
				_movementSpeed = DefaultSpeed + _sprintSpeed;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				_animator.SetBool("isRunning", false);
				_movementSpeed = DefaultSpeed;
			}
		}

		if (Input.GetAxis("Vertical") < .1f)
		{
			_animator.SetBool("isMoving", false);
		}

		// Make it move 10 meters per second instead of 10 meters per frame...
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		// Move translation along the object's z-axis
		transform.Translate(0, 0, translation);

		// Rotate around our y-axis
		transform.Rotate(0, rotation, 0);


		if (Input.GetKey(KeyCode.Space))
		{
			_animator.SetBool("isJumping", true);
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			_animator.SetBool("isJumping", false);
		}

		if (Input.GetKey(KeyCode.Mouse1))
		{
			_animator.SetBool("isBiting", true);
		}
		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			_animator.SetBool("isBiting", false);
		}

		if (Input.GetKey(KeyCode.Mouse0))
		{
			StopCoroutine(ExitHit());
			_animator.SetBool("isHitting", true);
			StartCoroutine(ExitHit());
		}
	
	}
	private IEnumerator ExitHit()
	{
		yield return new WaitForSeconds(2);
		_animator.SetBool("isHitting", false);
	}
}

using UnityEngine;

public class BotBehaviour : MonoBehaviour 
{

	[SerializeField] private GameObject _target;
	private Animator _animator;
	public float speed;
	private Vector3 _currPos;
	private Vector3 _lastPos;
	public int FollowRadius;
	public int AttackRadius;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	void Update() 
	{
		float step = speed * Time.deltaTime;

		var distance = Vector3.Distance(transform.position, _target.transform.position);

		if(distance < FollowRadius)
		{
			transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
			transform.LookAt(_target.transform);
		}

		if (distance < AttackRadius)
		{
			_animator.SetBool("isHitting", true);
		}
		else _animator.SetBool("isHitting", false);

		_currPos = transform.position;

		if (_currPos != _lastPos)
		{
			_animator.SetBool("isMoving", true);
		}
		else _animator.SetBool("isMoving", false);
		_lastPos = transform.position;



	}
}

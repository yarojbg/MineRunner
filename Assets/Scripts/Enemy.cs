using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float _speed;

	private Rigidbody _rigidbody;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		_rigidbody.velocity = (Player.instance.transform.position - transform.position).normalized * _speed;
	}
}

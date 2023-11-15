using UnityEngine;

public class Explosion : MonoBehaviour
{
	[SerializeField]
	private float explosionSpeed;

	float _startTime;

	void Start()
	{
		_startTime = Time.time;
	}

	void Update()
	{
		transform.localScale = (Time.time - _startTime) * explosionSpeed * Vector3.one;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == Layers.Player)
			return;
		float forceMultiplier = 1 / ((Time.time - _startTime) * (Time.time - _startTime));
		if (other.gameObject.TryGetComponent(out Rigidbody rb))
			rb.velocity = (other.transform.position - transform.position) * forceMultiplier;
	}
}

using UnityEngine;

public class Explosion : MonoBehaviour
{
	[SerializeField]
	private float explosionSpeed;

	float _startTime;

	void Start()
	{
		_startTime = Time.fixedTime;
	}

	void Update()
	{
		transform.localScale = (Time.fixedTime - _startTime) * explosionSpeed * Vector3.one;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == Layers.Player)
			return;
		float forceMultiplier = 1 / ((Time.fixedTime - _startTime) * (Time.fixedTime - _startTime));
		if (other.gameObject.TryGetComponent(out Rigidbody rb))
			rb.velocity = (other.transform.position - transform.position) * forceMultiplier;
	}
}

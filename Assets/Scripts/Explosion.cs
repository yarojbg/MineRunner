using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float explosionSpeed;

    float _startTime;

    // Start is called before the first frame update
    void Start()
    {
        print("explosion");
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = (Time.time - _startTime) * explosionSpeed * Vector3.one;
    }

	private void OnTriggerEnter(Collider other)
	{
        float forceMultiplier = 1 /((Time.time - _startTime)*(Time.time - _startTime));
        other.gameObject.GetComponent<Rigidbody>().velocity = (other.transform.position - transform.position) * forceMultiplier;
	}
}

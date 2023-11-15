using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = InputWrapper.Input;

public class Player : MonoBehaviour
{
	public static Player instance;
	
    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private GameObject _defeatWindow;

    [SerializeField]
    private float _speed;

    private Vector2 _joystickPosition;
    private Rigidbody _rigidbody;

	private void Awake()
	{
		instance = this;
        _rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if(Input.touchCount == 0) return;
        var touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began )
        {
            _joystickPosition = touch.position;
        }
        else
        {
            var direction = touch.position - _joystickPosition;
            if(direction != Vector2.zero )
            {
                direction.Normalize();
                _rigidbody.velocity = new Vector3(_speed * direction.x, 0, _speed * direction.y);
			}
            
        }
	}

	private void OnCollisionEnter(Collision collision)
    {
        print("layers?");
        if (collision.gameObject.layer == Layers.Enemy || collision.gameObject.layer == Layers.Mine)
        {
            print("hello");
            Instantiate(_explosion, collision.contacts[0].point, Quaternion.identity);
            _defeatWindow.SetActive(true);
        }
        else
        {
            print(collision.gameObject.layer);
        }
	}
}

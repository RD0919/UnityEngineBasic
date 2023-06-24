using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMovadle;
    public bool isDirectionChangeable;

    public const int DIRETION_RIGHT = 1;
    public const int DIRETION_LEFT = -1;
    public int direction
    {
        get => _direction; 
        set 
        {
            if(value < 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _direction = DIRETION_LEFT;
            }
            else 
            {
                transform.eulerAngles = Vector3.zero;
                _direction = DIRETION_RIGHT;
            }
        }
    }
    private int _direction;

    public float horizontal
    {
        get => _horizontal;
        set 
        {
            if (_horizontal == value)
                return;

            _horizontal = value;
            onHorizontalChanged?.Invoke(value);
        }
    }
    private float _horizontal;
    public event Action<float> onHorizontalChanged;
    [SerializeField] private float _speed = 1.0f;
    private Rigidbody2D _rigidbody;
    private Vector2 _move;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        if(isMovadle)
        {
            _move = new Vector2(horizontal, 0.0f);
        }
        else
        {
            _move = Vector2.zero;
        }

        if(isDirectionChangeable)
        {
            if(horizontal > 0)
                direction= DIRETION_RIGHT;
            else if(horizontal < 0)
                direction= DIRETION_LEFT;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.position += _move * _speed * Time.fixedDeltaTime;
    }

}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _thrustSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;

    public Rigidbody2D _rb;
    private bool _thrusting;
    private float _turnDir;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        
    }
    private void Update()
    {
        InputDetecting();
    }

    private void FixedUpdate()
    {
        MoveController();
    }

    private void InputDetecting()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) _turnDir = 1.0f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) _turnDir = -1.0f;
        else _turnDir = 0.0f;
    }

    private void MoveController()
    {
        if (_thrusting)
        {
            _rb.AddForce(transform.up * _thrustSpeed);
        }
        if (_turnDir != 0.0f)
        {
            _rb.AddTorque(_turnDir * _turnSpeed);
        }
    }
}

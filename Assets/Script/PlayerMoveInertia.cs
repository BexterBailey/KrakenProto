using UnityEngine;
using System.Collections;

public class PlayerMoveInertia : MonoBehaviour
{
    public float turnSpeed = 25f;

    public float _Velocity = 0.0f;      // Current Travelling Velocity
    public float _MaxVelocity = 25.0f;   // Maxima Velocity
    public float _Acc = 0.0f;           // Current Acceleration
    public float _AccSpeed = 0.005f;      // Amount to increase Acceleration with.
    public float _MaxAcc = 10.0f;        // Max Acceleration
    public float _MinAcc = -5.0f;       // Min Acceleration
    private float _VelPrev = 0.0f;


    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            _Acc += _AccSpeed;
	if (Input.GetKey(KeyCode.S))
            _Acc -= _AccSpeed;

        if (Input.GetKey(KeyCode.A))
	    if (_Velocity != 0f)
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            if (_Velocity != 0f)
		transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);


        if (_Acc > _MaxAcc)
            _Acc = _MaxAcc;
        else if (_Acc < _MinAcc)
            _Acc = _MinAcc;
	_VelPrev = _Velocity;
        _Velocity += _Acc;

        if (_Velocity > _MaxVelocity)
            _Velocity = _MaxVelocity;
        if (_Velocity <= 0f && _Acc < 0f)
            _Velocity = 0f;
	    _Acc = 0f;
	if (_Velocity <= _VelPrev && _Velocity > 0)
	    _Acc -= _AccSpeed;

        transform.Translate(Vector3.forward * _Velocity * Time.deltaTime);
    }
}
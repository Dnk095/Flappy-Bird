using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FireBall : MonoBehaviour, IInteractable
{
    private float _speed = 10f;
    private Vector3 _directional;

    public event Action<FireBall> Releasing;
    public event Action<FireBall> Killed;

    private void FixedUpdate()
    {
        Move();
    }

    public void Release()
    {
        Releasing?.Invoke(this);
    }

    public void Kill()
    {
        Killed?.Invoke(this);
    }

    public void Init(Vector3 direction,LayerMask layerMask, Transform currentPosition)
    {
        _directional = direction;
        gameObject.layer = layerMask;
        transform.position = currentPosition.position;
    }

    private void Move()
    {
        transform.position += _directional * _speed * Time.deltaTime;
    }
}

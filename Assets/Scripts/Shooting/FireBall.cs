using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FireBall : MonoBehaviour, IInteractable
{
    private float _speed = 10f;
    private Quaternion _rotate;

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
        Release();
    }

    public void Init(Quaternion rotate, LayerMask layerMask, Transform currentPosition)
    {
        _rotate = rotate;
        gameObject.layer = layerMask;
        transform.position = currentPosition.position;
    }

    private void Move()
    {
        transform.rotation = _rotate;
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);
    }
}

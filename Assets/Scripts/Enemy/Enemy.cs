using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooting))]
public class Enemy : MonoBehaviour
{
    private EnemyShooting _shooting;

    public event Action<Enemy> Releasing;

    private void Awake()
    {
        _shooting = GetComponent<EnemyShooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBall fireBall) && fireBall.gameObject.layer != gameObject.layer)
        {
            fireBall.Release();
            fireBall.Kill();
            Release();
        }
    }

    public void Release()
    {
        Releasing?.Invoke(this);
    }

    public void ShootingInit()
    {
        _shooting.Init();
    }
}

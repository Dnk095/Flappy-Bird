using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShot))]
public class Enemy : MonoBehaviour
{
    private EnemyShot _shooting;

    public event Action<Enemy> Releasing;

    private void Awake()
    {
        _shooting = GetComponent<EnemyShot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBall fireBall) && fireBall.gameObject.layer != gameObject.layer)
        {
            fireBall.Kill();
            Release();
        }
    }

    public void Release()
    {
        Releasing?.Invoke(this);
    }

    public void Init()
    {
        _shooting.Init();
    }

    public void CreatedInit(FireBallPool pool)
    {
        _shooting.InitCreatedFireball(pool);
    }
}

using System;
using UnityEngine;

public class BirdShooting : Shooting<Bird>
{
    private Vector3 _direction = Vector3.right;

    public event Action KillEnemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Shoot(_direction);
    }

    protected override FireBall Shoot(Vector3 direction)
    {
        FireBall fireBall = base.Shoot(direction);

        fireBall.Killed += OnKilled;

        return fireBall;
    }

    private void OnKilled(FireBall fireBall)
    {
        KillEnemy?.Invoke();
        fireBall.Killed -= OnKilled;
    }
}

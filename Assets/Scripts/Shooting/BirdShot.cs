using System;
using UnityEngine;

public class BirdShot : Shot<Bird>
{
    public event Action KillEnemy;

    public void Attack(Transform transform)
    {
        Shoot(transform.rotation);
    }

    protected override FireBall Shoot(Quaternion rotate)
    {
        FireBall fireBall = base.Shoot(rotate);

        fireBall.Killed += OnKilled;
        fireBall.Releasing += OnReleasing;

        return fireBall;
    }

    private void OnKilled(FireBall fireBall)
    {
        fireBall.Killed -= OnKilled;
        KillEnemy?.Invoke();
    }

    private void OnReleasing(FireBall fireBall)
    {
        fireBall.Killed -= OnKilled;
        fireBall.Releasing -= OnReleasing;
    }
}
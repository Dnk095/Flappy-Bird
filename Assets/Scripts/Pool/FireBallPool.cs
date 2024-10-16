using UnityEngine;

public class FireBallPool : Pool<FireBall>
{
    protected override void Spawn(FireBall fireBall)
    {
        base.Spawn(fireBall);
        fireBall.Releasing += OnRelease;
    }

    protected override void OnRelease(FireBall fireBall)
    {
        base.OnRelease(fireBall);
        fireBall.Releasing -= OnRelease;
    }
}

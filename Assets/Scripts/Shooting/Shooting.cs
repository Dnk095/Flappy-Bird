using UnityEngine;

public abstract class Shooting<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] protected FireBallPool Pool;

    protected virtual FireBall Shoot(Vector3 direction)
    {
        FireBall fireBall = Pool.GetObject();
        fireBall.Init(direction, gameObject.layer, _startPosition.transform);

        return fireBall;
    }
}

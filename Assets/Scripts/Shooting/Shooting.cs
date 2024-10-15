using UnityEngine;

public abstract class Shooting<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] protected FireBallPool _pool;

    protected virtual FireBall Shoot(Vector3 direction)
    {
        FireBall fireBall = _pool.GetObject();
        fireBall.Init(direction, gameObject.layer, _startPosition.transform);

        return fireBall;
    }
}

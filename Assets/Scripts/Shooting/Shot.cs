using UnityEngine;

public abstract class Shot<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] protected FireBallPool Pool;

    protected virtual FireBall Shoot(Quaternion rotate)
    {
        FireBall fireBall = Pool.GetObject();
        fireBall.Init(rotate, gameObject.layer, _startPosition.transform);

        return fireBall;
    }
}

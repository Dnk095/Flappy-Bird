using UnityEngine;

public class EnemyPool : Pool<Enemy>
{
    [SerializeField] private FireBallPool _fireBalls;

    protected override void Spawn(Enemy spawnedObject)
    {
        base.Spawn(spawnedObject);
        spawnedObject.ShootingInit();
        spawnedObject.Releasing += OnRelease;
    }

    protected override void OnRelease(Enemy spawnedObject)
    {
        base.OnRelease(spawnedObject);
        spawnedObject.Releasing -= OnRelease;
    }

    protected override Enemy CreateObject()
    {
        Enemy enemy = base.CreateObject();
        enemy.CreatedInit(_fireBalls);

        return enemy;
    }
}
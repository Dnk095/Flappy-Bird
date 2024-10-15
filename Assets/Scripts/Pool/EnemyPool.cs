using UnityEngine;

public class EnemyPool : Pool<Enemy>
{
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
}
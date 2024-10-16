using System.Collections;
using UnityEngine;

public class EnemyShot : Shot<Enemy>
{
    private Coroutine _corrotine;

    public void Init()
    {
        if (_corrotine != null)
            StopCoroutine(_corrotine);

        _corrotine = StartCoroutine(Shoot());
    }

    public void CreatedInit(FireBallPool pool)
    {
        Pool = pool;
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait;

        float minDelay = 1f;
        float maxDelay = 5f;


        while (enabled == true)
        {
            wait = new(Random.Range(minDelay, maxDelay + 1));

            yield return wait;

            Shoot(transform.rotation);
        }
    }
}

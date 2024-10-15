using System.Collections;
using UnityEngine;

public class EnemyShooting : Shooting<Enemy>
{

    private Vector3 _direction = Vector3.left;
    private Coroutine _corrotine;

    public void Init()
    {
        if (_corrotine != null)
            StopCoroutine(_corrotine);

        _corrotine = StartCoroutine(Shoote());
    }

    private IEnumerator Shoote()
    {
        WaitForSeconds wait;

        float minDelay = 1f;
        float maxDelay = 5f;


        while (enabled == true)
        {
            wait = new(Random.Range(minDelay, maxDelay + 1));

            yield return wait;

            Shoot(_direction);
        }
    }
}

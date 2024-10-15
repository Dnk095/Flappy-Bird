using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.Release();
        else if (collision.TryGetComponent(out FireBall fireBall))
            fireBall.Release();
    }
}

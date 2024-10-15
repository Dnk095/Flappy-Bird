using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler), typeof(BirdCounter))]
[RequireComponent(typeof(BirdShooting))]
public class Bird : MonoBehaviour
{
    private BirdMover _BirdMover;
    private BirdCollisionHandler _birdCollisionHandler;
    private BirdCounter _counter;
    private BirdShooting _shooting;

    public event Action GameOver;

    private void Awake()
    {
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
        _counter = GetComponent<BirdCounter>();
        _BirdMover = GetComponent<BirdMover>();
        _shooting = GetComponent<BirdShooting>();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
        _shooting.KillEnemy += OnKillEenmy;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
        _shooting.KillEnemy -= OnKillEenmy;
    }

    public void Reset()
    {
        _counter.Reset();
        _BirdMover.Reset();
    }

    private void OnKillEenmy()
    {
        _counter.Add();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground || interactable is FireBall)
        {
            GameOver?.Invoke();
        }
    }
}

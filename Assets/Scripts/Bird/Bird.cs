using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(BirdCollisionHandler), typeof(BirdCounter))]
[RequireComponent(typeof(BirdShot), typeof(InputReader))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private BirdCollisionHandler _collisionHandler;
    private BirdCounter _counter;
    private BirdShot _shooting;
    private InputReader _inputReader;

    public event Action GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _counter = GetComponent<BirdCounter>();
        _mover = GetComponent<BirdMover>();
        _shooting = GetComponent<BirdShot>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
        _shooting.KillEnemy += OnKillEenmy;
        _inputReader.MoveUp += OnMoveUp;
        _inputReader.Attackiing += OnAttack;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
        _shooting.KillEnemy -= OnKillEenmy;
        _inputReader.MoveUp -= OnMoveUp;
        _inputReader.Attackiing -= OnAttack;
    }

    public void Reset()
    {
        _counter.Reset();
        _mover.Reset();
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

    private void OnMoveUp()
    {
        _mover.MoveUp();
    }

    private void OnAttack()
    {
        _shooting.Attack(transform);
    }
}

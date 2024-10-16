using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _moveUpKey = KeyCode.Space;
    private KeyCode _attackKey = KeyCode.F;

    public event Action MoveUp;
    public event Action Attack;

    private void Update()
    {
        if (Input.GetKeyUp(_moveUpKey))
            MoveUp?.Invoke();
        else if (Input.GetKeyUp(_attackKey))
            Attack?.Invoke();
    }
}

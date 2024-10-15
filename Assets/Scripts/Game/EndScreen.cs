using System;
using UnityEngine;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        CanvasGroup.alpha = 0f;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1f;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}

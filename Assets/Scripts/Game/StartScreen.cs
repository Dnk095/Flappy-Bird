using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

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
        PlayButtonClicked?.Invoke();
    }
}

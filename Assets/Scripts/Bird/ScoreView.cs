using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private BirdCounter _counter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _counter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}

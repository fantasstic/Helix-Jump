using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //[SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        Ball.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        Ball.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}

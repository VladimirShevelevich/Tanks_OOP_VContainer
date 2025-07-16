using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level.Scores;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

public class ScoresHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    
    private IScoresService _scoresService;

    [Inject]
    public void Construct(IScoresService scoresService)
    {
        _scoresService = scoresService;
    }

    private void Start()
    {
        _scoresService.CurrentScore.Subscribe(UpdateScore).
            AddTo(gameObject);
    }

    private void UpdateScore(int newScore)
    {
        _valueText.text = newScore.ToString();
    }
}

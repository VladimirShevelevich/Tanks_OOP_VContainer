using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level.Config;
using Game.Level.Scores;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

public class ScoresHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    
    private IScoresService _scoresService;
    private LevelConfig _levelConfig;

    [Inject]
    public void Construct(IScoresService scoresService, LevelConfig levelConfig)
    {
        _scoresService = scoresService;
        _levelConfig = levelConfig;
    }

    private void Start()
    {
        _scoresService.CurrentScore.Subscribe(UpdateScore).
            AddTo(gameObject);
    }

    private void UpdateScore(int newScore)
    {
        _valueText.text = $"{newScore}/{_levelConfig.ScoreGoal}";
    }
}

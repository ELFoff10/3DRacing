using System;
using UnityEngine;
using UnityEngine.UI;

public class UIRaceResultPanel : MonoSingleton<UIRaceResultPanel>, IDependency<RaceResultTime>
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private Text _recordTime;
    [SerializeField] private Text _currentTime;

    private RaceResultTime _raceResultTime;
    public void Construct(RaceResultTime obj) => _raceResultTime = obj;

    private void Start()
    {
        _resultPanel.SetActive(false);

        _raceResultTime.ResultUpdated += OnUpdateResult;
    }

    private void OnDestroy()
    {
        _raceResultTime.ResultUpdated -= OnUpdateResult;
    }

    private void OnUpdateResult()
    {
        _resultPanel.SetActive(true);

        _recordTime.text = StringTime.SecondToTimeString(_raceResultTime.GetAbsoluteRecord());
        _currentTime.text = StringTime.SecondToTimeString(_raceResultTime.CurrentTime);
    }
}
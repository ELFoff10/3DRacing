using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICountDownTimer : MonoBehaviour/*, IDependency<RaceStateTracker>*/
{
    [SerializeField] private RaceStateTracker raceStateTracker;

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Timer countDownTimer;

    //public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Start()
    {
        raceStateTracker.PreparationStarted += OnRacePreparationStarted;
        raceStateTracker.Started += OnRaceStarted;

        text.enabled = false;
    }

    private void OnDestroy()
    {
        raceStateTracker.PreparationStarted -= OnRacePreparationStarted;
        raceStateTracker.Started -= OnRaceStarted;
    }

    private void OnRacePreparationStarted()
    {
        text.enabled = true;
        enabled = true;
    }

    private void OnRaceStarted()
    {
        text.enabled = false;
        enabled = false;
    }

    private void Update()
    {
        text.text = countDownTimer.Value.ToString("F0");

        if (text.text == "0")
        {
            text.text = "GO!";
        }
    }
}

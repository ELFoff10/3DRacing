using UnityEngine;

public class RaceKeyboardStarter : MonoBehaviour /*, IDependency<RaceStateTracker>*/
{
    [SerializeField] private RaceStateTracker raceStateTracker;
    //public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) == true)
        {
            raceStateTracker.LaunchPeparationStart();
        }
    }
}

using UnityEngine;

public class LevelDisplayController : MonoBehaviour
{
    [SerializeField] private LevelMap[] _levels;
    
    private void Start()
    {
        var drawLevel = 0;

        var score = 1;

        while (score != 0 && drawLevel < _levels.Length &&
                LevelCompletion.Instance.TryIndex(drawLevel, out var race, out score))
        {
            _levels[drawLevel].SetLevelData(race, score);
            drawLevel += 1;
        }

        for (int i = drawLevel; i < _levels.Length; i++)
        {
            //_levels[i].gameObject.SetActive(false);
            _levels[i].LockPanel.SetActive(true);
            _levels[i].GetComponent<UIRaceButton>().enabled = false;
        }

        #region Last
        /*        while (score != 0 && drawLevel < _levels.Length)
                {           
                    score = _levels[drawLevel].Initialise();
                    drawLevel += 1;
                }

                for (int i = drawLevel; i < _levels.Length; i++)
                {
                    //_levels[i].gameObject.SetActive(false);
                    _levels[i].LockPanel.SetActive(true);
                    _levels[i].GetComponent<UIRaceButton>().enabled = false;
                }*/
        #endregion
    }
}
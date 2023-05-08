using System;
using UnityEngine;

public class LevelCompletion : MonoSingleton<LevelCompletion>
{
    public const string filename = "completion.dat";

    [Serializable]
    public class LevelScore
    {
        public RaceInfo RaceInfo;
        public int Score;
    }

    [SerializeField] private LevelScore[] _completionData;

    private new void Awake()
    {
        base.Awake();
        Saver<LevelScore[]>.TryLoad(filename, ref _completionData);
    }

    public void RelpadSavingData()
    {
        foreach (var levelScore in _completionData)
        {
            levelScore.Score = 0;
        }

        Saver<LevelScore[]>.TryLoad(filename, ref _completionData);
    }

    public static void SaveLevelResult(int levelScore)
    {
        if (Instance)
        {
            foreach (var item in Instance._completionData)
            {
                if (item.RaceInfo == LevelSequenceController.Instance.CurrentLevel)
                {
                    if (levelScore > item.Score)
                    {
                        item.Score = levelScore;
                        Saver<LevelScore[]>.Save(filename, Instance._completionData);
                    }
                    
                }
            }
        }
        else
        {
            Debug.Log($"Episode complete with score {levelScore}");
        }
    }

    public int GetEpisodeScore(RaceInfo raceInfo)
    {
        foreach (var data in _completionData)
        {
            if (data.RaceInfo = raceInfo)
            {
                return data.Score;
            }
        }
        return 0;
    }

    public bool TryIndex(int id, out RaceInfo race, out int score)
    {
        if (id >= 0 && id < _completionData.Length)
        {
            race = _completionData[id].RaceInfo;
            score = _completionData[id].Score;
            return true;
        }
        race = null;
        score = 0;
        return false;
    }
}

using UnityEngine;

[CreateAssetMenu]
public class GraphicsQualitySetting : Setting
{
    private int _currentLevelIndex = 0;

    public override bool isMinValue { get => _currentLevelIndex == 0; }

    public override bool isMaxValue { get => _currentLevelIndex == QualitySettings.names.Length - 1; }

    public override void SetNextValue()
    {
        if (isMaxValue == false)
        {
            _currentLevelIndex++;
        }
    }

    public override void SetPreviousValue()
    {
        if (isMinValue == false)
        {
            _currentLevelIndex--;
        }
    }

    public override object GetValue()
    {
        return QualitySettings.names[_currentLevelIndex];
    }

    public override string GetStringValue()
    {
        return QualitySettings.names[_currentLevelIndex];
    }

    public override void Apply()
    {
        QualitySettings.SetQualityLevel(_currentLevelIndex);

        Save();
    }

    public override void Load()
    {
        _currentLevelIndex = PlayerPrefs.GetInt(_title, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(_title, _currentLevelIndex);
    }
}
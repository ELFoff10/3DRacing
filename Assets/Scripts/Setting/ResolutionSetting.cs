using UnityEngine;

[CreateAssetMenu]
public class ResolutionSetting : Setting
{
    [SerializeField]
    private Vector2Int[] _avalibaleResolution = new Vector2Int[]
    {
        new Vector2Int(800, 600),
        new Vector2Int(1280, 720),
        new Vector2Int(1600, 900),
        new Vector2Int(1920, 1080),
    };

    private int _currentResolutionIndex = 0;

    public override bool isMinValue { get => _currentResolutionIndex == 0; }
    public override bool isMaxValue { get => _currentResolutionIndex == _avalibaleResolution.Length - 1; }

    public override void SetNextValue()
    {
        if (isMaxValue == false)
        {
            _currentResolutionIndex++;
        }
    }

    public override void SetPreviousValue()
    {
        if (isMinValue == false)
        {
            _currentResolutionIndex--;
        }
    }

    public override object GetValue()
    {
        return _avalibaleResolution[_currentResolutionIndex];
    }

    public override string GetStringValue()
    {
        return _avalibaleResolution[_currentResolutionIndex].x + "x" + _avalibaleResolution[_currentResolutionIndex].y;
    }

    public override void Apply()
    {
        Screen.SetResolution(_avalibaleResolution[_currentResolutionIndex].x, _avalibaleResolution[_currentResolutionIndex].y, true);

        Save();
    }

    public override void Load()
    {
        _currentResolutionIndex = PlayerPrefs.GetInt(_title, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(_title, _currentResolutionIndex);
    }
}

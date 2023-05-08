using UnityEngine;
using UnityEngine.UI;

public class UISettingButton : UISelectableButton, IScriptableObjectProperty
{
    [SerializeField] private Setting _setting;

    [SerializeField] private Text _titleText;
    [SerializeField] private Text _valueText;

    [SerializeField] private Image _previousImage;
    [SerializeField] private Image _nextImage;

    private void Start()
    {
        ApplyProperty(_setting);
    }

    public void SetNextValueSetting()
    {
        _setting?.SetNextValue();
        _setting?.Apply();
        UpdateInfo();
    }

    public void SetPreviousValueSetting()
    {
        _setting?.SetPreviousValue();
        _setting?.Apply();
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        _titleText.text = _setting.Title;
        _valueText.text = _setting.GetStringValue();

        _previousImage.enabled = !_setting.isMinValue;
        _nextImage.enabled = !_setting.isMaxValue;
    }

    public void ApplyProperty(ScriptableObject setting)
    {
        if (setting == null)
        {
            return;
        }

        if (setting is Setting == false)
        {
            return;
        }

        _setting = setting as Setting;

        UpdateInfo();
    }
}
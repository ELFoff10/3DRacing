using UnityEngine.EventSystems;
using UnityEngine;

public class UIRaceButton : UISelectableButton, IScriptableObjectProperty
{
    private RaceInfo _raceInfo;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    private void Start()
    {
        ApplyProperty(_raceInfo);
    }

    public void ApplyProperty(ScriptableObject property)
    {
        if (property == null)
        {
            return;
        }

        if (property is RaceInfo == false)
        {
            return;
        }
    }
}

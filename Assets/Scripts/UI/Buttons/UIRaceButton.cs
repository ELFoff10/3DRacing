using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIRaceButton : UISelectableButton/*, IScriptableObjectProperty*/
{
    [SerializeField] private RaceInfo raceInfo;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;


    private void Start()
    {
        ApplyProperty(raceInfo);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (raceInfo == null)
        {
            return;
        }

        SceneManager.LoadScene(raceInfo.SceneName);
    }

    public void ApplyProperty(RaceInfo property)
    {
        if (property == null)
        {
            return;
        }

        raceInfo = property;

        icon.sprite = raceInfo.Icon;
        title.text = raceInfo.Title;

        //if (property is raceinfo == false)
        //{
        //    return;
        //}
    }
}

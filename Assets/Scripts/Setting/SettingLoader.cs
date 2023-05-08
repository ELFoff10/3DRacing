using UnityEngine;

public class SettingLoader : MonoBehaviour
{
    [SerializeField] private Setting[] _allSettings;

    private void Awake()
    {
        for (int i = 0; i < _allSettings.Length; i++)
        {
            _allSettings[i].Load();
            _allSettings[i].Apply();
        }
    }
}
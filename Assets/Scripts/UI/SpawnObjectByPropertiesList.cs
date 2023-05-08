using UnityEngine;

public class SpawnObjectByPropertiesList : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private ScriptableObject[] _properties;

    [ContextMenu(nameof(SpawnEditMode))]
    public void SpawnEditMode()
    {
        if (Application.isPlaying == true)
        {
            return;
        }

        GameObject[] allObjects = new GameObject[_parent.childCount];

        for (int i = 0; i < _parent.childCount; i++)
        {
            allObjects[i] = _parent.GetChild(i).gameObject;
        }

        for (int i = 0; i < allObjects.Length; i++)
        {
            DestroyImmediate(allObjects[i]);
        }

        for (int i = 0; i < _properties.Length; i++)
        {
            GameObject go = Instantiate(_prefab, _parent);

            IScriptableObjectProperty scriptableObjectProperty = go.GetComponent<IScriptableObjectProperty>();

            scriptableObjectProperty.ApplyProperty(_properties[i]);
        }
    }
}
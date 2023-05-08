using UnityEngine;

public class UIHint : MonoBehaviour
{
    [SerializeField] private GameObject _hint;

    private void Start()
    {
        _hint.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _hint.SetActive(false);
        }
    }
}

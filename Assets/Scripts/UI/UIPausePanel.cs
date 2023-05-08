using System;
using UnityEngine;

public class UIPausePanel : MonoBehaviour, IDependency<Pauser>
{
    [SerializeField] private GameObject _panel;

    private Pauser _pauser;
    public void Construct(Pauser obj) => _pauser = obj;

    private void Start()
    {
        _panel.SetActive(false);
        _pauser.PauseStateChange += OnPauseStateChange;
    }

    private void OnDestroy()
    {
        _pauser.PauseStateChange -= OnPauseStateChange;
    }

    private void OnPauseStateChange(bool isPause)
    {
        _panel.SetActive(isPause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            _pauser.ChangePauseState();
        }
    }

    public void UnPause()
    {
        _pauser.UnPause();
    }
}

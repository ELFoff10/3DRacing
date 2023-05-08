using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PauseAudioSource : MonoBehaviour, IDependency<Pauser>
{
    private AudioSource _audio;

    private Pauser _pauser;
    public void Construct(Pauser obj) => _pauser = obj;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        _pauser.PauseStateChange += OnPauseStateChange;
    }

    private void OnDestroy()
    {
        _pauser.PauseStateChange -= OnPauseStateChange;
    }

    private void OnPauseStateChange(bool pause)
    {
        if (pause == true)
        {
            _audio.Stop();
        }

        if (pause == false)
        {
            _audio.Play();
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TarActivate : MonoBehaviour, IDependency<TrackPointCircuit>
{
    [SerializeField] private GameObject _warningMessage;
    [SerializeField] private GameObject _tars;

    private AudioSource _audioSource;
    private TrackPointCircuit _trackPointCircuit;
    public void Construct(TrackPointCircuit obj) => _trackPointCircuit = obj;

    private float _time = 6f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _warningMessage.SetActive(false);
        _audioSource.enabled = false;
        _tars.SetActive(false);
    }

    private void Update()
    {
        if (_trackPointCircuit.LapsCompleted == 1)
        {
            _time -= Time.deltaTime;

            if (_time <= 0)
            {
                _time = 0;
                _warningMessage.SetActive(false);
            }
        }

        if (_trackPointCircuit.LapsCompleted != 1)
        {
            _warningMessage.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_trackPointCircuit.LapsCompleted == 1)
        {
            _warningMessage.SetActive(true);
            _audioSource.enabled = true;
            _tars.SetActive(true);
        }
    }
}

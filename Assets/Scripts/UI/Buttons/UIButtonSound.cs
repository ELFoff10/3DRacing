using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _hover;

    private AudioSource _audio;

    private UIButton[] _uiButton;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        _uiButton = GetComponentsInChildren<UIButton>(true);

        for (int i = 0; i < _uiButton.Length; i++)
        {
            _uiButton[i].PointerEnter += OnPointerEnter;
            _uiButton[i].PointerClick += OnPointerClicked;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _uiButton.Length; i++)
        {
            _uiButton[i].PointerEnter -= OnPointerEnter;
            _uiButton[i].PointerClick -= OnPointerClicked;
        }
    }

    private void OnPointerEnter(UIButton arg0)
    {
        _audio.PlayOneShot(_hover);
    }

    private void OnPointerClicked(UIButton arg0)
    {
        _audio.PlayOneShot(_click);
    }
}
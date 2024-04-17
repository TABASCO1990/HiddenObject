using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class Target : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private GameObject _compareImage;
    [SerializeField] private ParticleSystem _particleStars;

    private Button _button;
    private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnChangeState);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnChangeState);
    }

    private void OnChangeState()
    {
        Setpartical();
        _counter.SetValue();
        _image.color = Color.white;
        _button.enabled = false;
    }

    private void Setpartical()
    {
        Instantiate(_particleStars, transform);
        ParticleSystem particle = Instantiate(_particleStars, _compareImage.transform);
        particle.transform.localPosition = transform.localPosition;
    }
}

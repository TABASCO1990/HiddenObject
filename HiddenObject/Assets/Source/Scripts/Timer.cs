using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private int _currentTime = 20;

    private TMP_Text _textTime;

    public bool IsCounting = true;

    private void Awake()
    {
        _textTime = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        StartCoroutine(Ñounting());
    }

    private IEnumerator Ñounting()
    {
        while (IsCounting)
        {
            if (_currentTime >= 0)
            {
                _textTime.text = $"Time: {_currentTime}";
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }
            else
            {
                _loseScreen.SetActive(true);
                _restartButton.SetActive(true);
                IsCounting = false;
            }
        }
    }
}

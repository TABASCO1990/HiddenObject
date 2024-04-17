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

    public int CurrentTime
    {
        get
        {
            return _currentTime;
        }
        set
        {
            if (_currentTime != 0)
            {
                _currentTime = value;
            }
        }
    }

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
                DisplayTime(_currentTime);
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

    private void DisplayTime(float timeTotDisplay)
    {
        if (timeTotDisplay < 0)
        {
            timeTotDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeTotDisplay / 60);
        float seconds = Mathf.FloorToInt(timeTotDisplay % 60);

        _textTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

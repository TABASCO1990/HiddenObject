using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    public static Counter Instance { get; private set; }

    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private Timer _timer;

    private TMP_Text _text;
    private int _currentValue;
    private int _maxValue = 10;   

    private void Awake()
    {
        Instance = this;
        _text = GetComponent<TMP_Text>();
    }

    public void SetValue()
    {
        _currentValue += 1;
        _text.text = $"{_currentValue}/{_maxValue}";

        if (_currentValue == _maxValue)
        {
            _victoryScreen.SetActive(true);
            _restartButton.SetActive(true);
            _timer.IsCounting = false;
            ShowInterstitial();
        }
    }

    private void ShowInterstitial()
    {
        if (Appodeal.IsLoaded(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealAdType.Interstitial);
        }
    }
}

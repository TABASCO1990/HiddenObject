using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Save;
using TMPro;

namespace Game
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textLevel;
        [SerializeField] private Button _button;

        private Data _data;
        private int _curentLevel;

        private void OnEnable()
        {
            _button.onClick.AddListener(RestartLevel);
            AppodealCallbacks.Interstitial.OnClosed += OnInterstitialClosed;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(RestartLevel);
            AppodealCallbacks.Interstitial.OnClosed -= OnInterstitialClosed;
        }

        private void Start()
        {
            _data = new Data();
            _data = DataManager.Instance.Load();

            _curentLevel = _data.CurentLevel;
            _textLevel.text = $"Level: {_curentLevel}";
        }

        private void RestartLevel()
        {
            IncrementNumber();
            SaveData();
            ShowInterstitial();
        }

        private void IncrementNumber()
        {
            _curentLevel++;
            _textLevel.text = $"Level: {_curentLevel}";
        }

        private void SaveData()
        {
            _data.CurentLevel = _curentLevel;
            DataManager.Instance.Save(_data);
        }

        private void ShowInterstitial()
        {
            if (Appodeal.IsLoaded(AppodealAdType.Interstitial))
            {
                Appodeal.Show(AppodealAdType.Interstitial);
            }
        }

        private void OnInterstitialClosed(object sender, EventArgs e)
        {
            SceneManager.LoadScene(0);
        }
    }
}

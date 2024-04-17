using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private TMP_Text _textLevel;
    [SerializeField] private Button _button;

    private Data _data;
    private int _curentLevel; 

    private void OnEnable()
    {
        _button.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RestartLevel);
    }

    private void Start()
    {
        _data = new Data();
        _data = DataManager.Instance.Load();

        _curentLevel = _data.CurentLevel;
        _textLevel.text = $"Level: {_curentLevel}";

        print(_curentLevel);
    }

    private void RestartLevel()
    {
        IncrementNumber();
        SaveData();
        SceneManager.LoadScene(0);      
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
}

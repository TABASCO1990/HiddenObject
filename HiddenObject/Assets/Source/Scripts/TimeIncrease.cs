using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class TimeIncrease : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _button;

    private int _time = 10;

    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id)
        {
            case "com.serbull.iaptutorial.AddTime":
                AddSeconds();
                break;
        }      
    }

    public void StartTime()
    {
        Time.timeScale = 1;
        _button.enabled = true;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
        _button.enabled = false;
    }

    private void AddSeconds()
    {
        _timer.CurrentTime += _time;
        StartTime();
    }
}

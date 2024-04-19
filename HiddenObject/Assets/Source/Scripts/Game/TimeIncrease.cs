using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace Game
{
    public class TimeIncrease : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private Button _button;

        private int _time = 10;

        public void OnPurchaseCompleted(Product product)
        {
            AddSeconds();
        }

        public void StartTime()
        {
            Time.timeScale = 1;
            _button.enabled = true;
        }

        public void StopTime()
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Time.timeScale = 0;
            _button.enabled = false;
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        _timer.CurrentTime += _time;
#endif
        }

        private void AddSeconds()
        {
            _timer.CurrentTime += _time;
            StartTime();
        }
    }
}

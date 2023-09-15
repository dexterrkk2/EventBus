using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float duration = 3f;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
        }
        private void StartTimer()
        {
            StartCoroutine(CountDown());
        }
        private IEnumerator CountDown()
        {
            _currentTime = duration;
            while (_currentTime >0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }
            RaceEventBus.Publish(RaceEventType.START);
        }
        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 0, 100, 200), "Countdown: " + _currentTime);
        }
    }
}
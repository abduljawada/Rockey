using UnityEngine;
using UnityEngine.Events;

public class TriggerOnTimer : MonoBehaviour
{
    [SerializeField] private float timerTime = 3f;
    [SerializeField] private bool isRepeat;
    [SerializeField] private UnityEvent @event;
    private float _timeToTimerEnd;

    private void Start()
    {
        _timeToTimerEnd = timerTime;
    }

    private void Update()
    {
        _timeToTimerEnd -= Time.deltaTime;

        if (!(_timeToTimerEnd <= 0f)) return;
        @event?.Invoke();
        if (isRepeat)
        {
            _timeToTimerEnd = timerTime;
        }
        else
        {
            Destroy(this);
        }
    }
}

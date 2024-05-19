using UnityEngine;
using UnityEngine.Events;

public class TriggerOnInvisible : MonoBehaviour
{
    [SerializeField] private UnityEvent @event;
    private bool _wasVisible;

    private void OnBecameVisible()
    {
        _wasVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (_wasVisible)
        {
            @event?.Invoke();
        }
    }
}

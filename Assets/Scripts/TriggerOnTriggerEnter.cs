using UnityEngine;
using UnityEngine.Events;

public class TriggerOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string otherTag;
    [SerializeField] private UnityEvent @event;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(otherTag)) @event?.Invoke();
    }
}

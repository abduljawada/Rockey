using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event EventHandler<EventArgs> Move; 
    public event EventHandler<EventArgs> Stop; 
    public event EventHandler<EventArgs> Charge; 
    public event EventHandler<EventArgs> Shoot; 
    
    private Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float minRotationSpeed = 2f;
    private float _rotationSpeed = 2f;
    private bool _isCharged;

    private void Update()
    {
        var verticalAxis = Input.GetAxisRaw("Vertical");

        if (verticalAxis > 0f)
        {
            Move?.Invoke(this, EventArgs.Empty);
            Rigidbody2D.AddForce(transform.up * (verticalAxis * speed));
        }
        else
        {
            Stop?.Invoke(this, EventArgs.Empty);
        }

        if (_isCharged && Input.GetKeyDown(KeyCode.Z))
        {
            Shoot?.Invoke(this, EventArgs.Empty);
            Instantiate(bulletPrefab, transform.position + (Vector3)(offset * transform.up), transform.rotation);
            _isCharged = false;
        }

        _rotationSpeed = (1 / (Rigidbody2D.velocity.magnitude + 1f) + minRotationSpeed);
        Rigidbody2D.AddTorque(Input.GetAxisRaw("Horizontal") * -1f * _rotationSpeed);
    }

    public void StartCharge()
    {
        Charge?.Invoke(this, EventArgs.Empty);
        _isCharged = true;
    }
}

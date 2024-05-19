using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float speed = 3f;
    private Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();

    private void Update()
    {
        var angle = (transform.rotation.eulerAngles.z + offset) * Mathf.Deg2Rad;
        Rigidbody2D.velocity = speed * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}

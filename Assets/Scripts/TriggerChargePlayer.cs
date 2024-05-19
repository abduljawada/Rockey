using System;
using UnityEngine;

public class TriggerChargePlayer : MonoBehaviour
{
    private PlayerController PlayerController => GetComponent<PlayerController>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            PlayerController.StartCharge();
        }
    }
}

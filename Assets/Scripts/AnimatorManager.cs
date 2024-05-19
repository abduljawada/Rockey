using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private static readonly int IsThrusting = Animator.StringToHash("IsThrusting");
    private static readonly int IsCharged = Animator.StringToHash("IsCharged");
    private PlayerController PlayerController => GetComponentInParent<PlayerController>();
    private Animator Animator => GetComponent<Animator>();

    private void Start()
    {
        PlayerController.Move += PlayerControllerOnMove;
        PlayerController.Stop += PlayerControllerOnStop;
        PlayerController.Charge += PlayerControllerOnCharge;
        PlayerController.Shoot += PlayerControllerOnShoot;
    }

    private void PlayerControllerOnShoot(object sender, EventArgs e)
    {
        Animator.SetBool(IsCharged, false);
    }

    private void PlayerControllerOnCharge(object sender, EventArgs e)
    {
        Animator.SetBool(IsCharged, true);
    }

    private void PlayerControllerOnMove(object sender, EventArgs e)
    {
        Animator.SetBool(IsThrusting, true);
    }
    
    private void PlayerControllerOnStop(object sender, EventArgs e)
    {
        Animator.SetBool(IsThrusting, false);
    }
}

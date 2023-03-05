using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    /// <summary>
    /// Set Animator Parameter Speed (float)
    /// </summary>
    /// <param name="speed">speed</param>
    public void SetAnimatorSpeed(float speed)
    {
        animator.SetFloat("speed", speed);
    }
}

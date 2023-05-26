using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    #region Fields

    [SerializeField] private Animator animator;
    
    private static readonly int SpeedIDHash = Animator.StringToHash("speed");

    #endregion

    #region Methods

    /// <summary>
    /// Set Animator Parameter Speed (float)
    /// </summary>
    /// <param name="speed">speed</param>
    public void SetAnimatorSpeed(in float speed)
    {
        animator.SetFloat(SpeedIDHash, speed);
    }

    #endregion
}

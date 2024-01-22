using System;
using System.Threading.Tasks;
using UnityEngine;

internal class WeaponController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator slashAnimator;
    private int attackAniHash;
    private int slashDown;
    private int slashUp;
    private bool canAttack=true;

    private void Start()
    {
        attackAniHash = Animator.StringToHash("Attack");
        slashDown = Animator.StringToHash("SlashDown");
        slashUp = Animator.StringToHash("SlashUp");
    }

    internal void FlipXAndAngle(bool isFlipX, float angle)
    {
        transform.localRotation = isFlipX ? Quaternion.Euler(0, 180, angle) : Quaternion.Euler(0, 0, angle);
    }

    public async void Attack()
    {
        if (!canAttack)
        {
            return;
        }
        canAttack = false;
        animator.SetTrigger(attackAniHash);
        await Task.Delay(150);
        slashAnimator.SetTrigger(slashDown);
    }

    public void ResetCanAttackFlag()
    {
        canAttack = true;
    }
}
using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

internal class SwordController : MonoBehaviour, IWeapon
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


    public async void Attack()
    {
        if (!canAttack)
        {
            return;
        }
        canAttack = false;
        animator.SetTrigger(attackAniHash);
        await UniTask.Delay(150);
        slashAnimator.SetTrigger(slashDown);
    }

    public void ResetCanAttackFlag()
    {
        canAttack = true;
    }

    public WeaponType GetWeaponType()
    {
        return WeaponType.Sword;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
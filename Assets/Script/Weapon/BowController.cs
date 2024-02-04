using UnityEngine;

public class BowController : MonoBehaviour, IWeapon
{
    [SerializeField] private Animator animator;
    private int shootAniHash;

    private void Awake()
    {
        shootAniHash = Animator.StringToHash("Shoot");
    }
    public void Attack()
    {
        Debug.Log("Bow Attack");
        animator.SetTrigger(shootAniHash);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public WeaponType GetWeaponType()
    {
        return WeaponType.Bow;
    }
}

using UnityEngine;

public class StaffController : MonoBehaviour, IWeapon
{
    [SerializeField] private Animator animator;
    private int swingAniHash;

    private void Awake()
    {
        swingAniHash = Animator.StringToHash("StaffSwing");
    }

    public void Attack()
    {
        Debug.Log("Staff Attack");
        animator.SetTrigger(swingAniHash);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public WeaponType GetWeaponType()
    {
        return WeaponType.Staff;
    }
}

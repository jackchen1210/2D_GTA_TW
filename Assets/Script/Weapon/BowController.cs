using UnityEngine;

public class BowController : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        Debug.Log("Bow Attack");
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

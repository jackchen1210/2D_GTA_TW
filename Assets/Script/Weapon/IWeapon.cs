using UnityEngine;

public interface IWeapon
{
    WeaponType GetWeaponType();
    void Attack();
    GameObject GetGameObject();
}

using System;
using UniRx;
using UnityEngine;

internal class WeaponController : MonoBehaviour
{
    private IWeapon weapon;

    private void Start()
    {
        DataManager.GetInstance().CurrentSelectWeapon.Subscribe(OnWeaponChanged).AddTo(this);
    }

    private void OnWeaponChanged(WeaponInfo info)
    {
        if(info == null)
        {
            DestroyPrevWeaponIfExist();
            return;
        }

        if(weapon== null || weapon.GetWeaponType() != info.GetWeaponType())
        {
            DestroyPrevWeaponIfExist();
            CreateWeapon();
        }
    }

    private void CreateWeapon()
    {
        var prefab = DataManager.GetInstance().CurrentSelectWeapon.Value.GetPrefab();
        if(prefab == null)
        {
            return;
        }
        weapon = Instantiate(prefab, transform).GetComponent<IWeapon>();
    }

    private void DestroyPrevWeaponIfExist()
    {
        if (weapon != null)
        {
            Destroy(weapon.GetGameObject());
            weapon = null;
        }
    }

    internal void Attack()
    {
        if(weapon == null)
        {
            Debug.LogError("Weapon is not set");
            return;
        }
        weapon.Attack();
    }
    internal void FlipXAndAngle(bool isFlipX, float angle)
    {
        transform.localRotation = isFlipX ? Quaternion.Euler(0, 180, angle) : Quaternion.Euler(0, 0, angle);
    }
}
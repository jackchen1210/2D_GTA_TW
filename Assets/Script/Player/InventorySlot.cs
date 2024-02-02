using UnityEngine;
internal class InventorySlot : MonoBehaviour
{
    [SerializeField] private Transform frameTrans;
    [SerializeField] private WeaponInfo weaponInfo;

    public void SetActive(bool active)
    {
        frameTrans.gameObject.SetActive(active);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
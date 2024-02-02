using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponInfo",menuName ="SO/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject prefab;
    [SerializeField]private WeaponType weaponType;

    public string GetWeaponName()
    {
        return name;
    }

    public GameObject GetPrefab()
    {
        if(prefab == null)
        {
            Debug.LogError("WeaponInfo裡面的prefab沒有設定");
        }

        return prefab;
    }

    internal WeaponType GetWeaponType()
    {
        return weaponType;
    }
}

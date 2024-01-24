using System;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject destructVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<SwordHitbox>(out var swordHitbox))
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        Instantiate(destructVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

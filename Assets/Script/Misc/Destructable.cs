using System;
using UnityEngine;
using DG.Tweening;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject destructVFX;
    [SerializeField] private int destructTime = 1;

    private Tween shakeTween;
    private int currentDestructCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<SwordHitbox>(out var swordHitbox))
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        currentDestructCounter++;
        if (currentDestructCounter < destructTime)
        {
            Shake();
            return;
        }
        Instantiate(destructVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Shake()
    {
        shakeTween?.Kill();
        shakeTween = transform.DOShakePosition(0.1f).SetRelative();
    }

    private void OnDestroy()
    {
        shakeTween?.Kill();
    }
}

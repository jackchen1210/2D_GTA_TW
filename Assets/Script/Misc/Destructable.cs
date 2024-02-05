using System;
using UnityEngine;
using DG.Tweening;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject destructVFX;
    [SerializeField] private int destructTime = 1;
    [Header("Shake Setting")]
    [SerializeField] private float duraction = 0.1f;
    [SerializeField] private float strength = 1;
    [SerializeField] private int vibrato = 10;

    private Tween shakeTween;
    private int currentDestructCounter;

    public void Destruct()
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
        shakeTween = transform.DOShakePosition(duraction,strength, vibrato).SetRelative();
    }

    private void OnDestroy()
    {
        shakeTween?.Kill();
    }
}

using UnityEngine;
using DG.Tweening;
using System;

public abstract class TransparentDetection : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] private float alpha = 0.8f;
    private float fadedTime = 0.4f;
    private Tween fadeOutTween;
    private Tween fadeInTween;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision))
        {
            fadeOutTween?.Kill();
            fadeOutTween = FadeOutColor(new Color(1, 1, 1, alpha), fadedTime);
        }
    }

    protected abstract Tween FadeOutColor(Color fadedColor, float fadedTime);
    protected abstract Tween FadeInColor(Color fadedColor, float fadedTime);

    private bool IsPlayer(Collider2D collision)
    {
        return collision.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision))
        {
            fadeInTween?.Kill();
            fadeInTween = FadeInColor(Color.white, fadedTime);
        }
    }

    private void OnDestroy()
    {
        fadeOutTween?.Kill();
        fadeInTween?.Kill();
    }

}

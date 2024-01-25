using DG.Tweening;
using UnityEngine;

public class SpriteRenderderTransparentDetection : TransparentDetection
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    protected override void FadeInColor(Color fadedColor, float fadedTime)
    {
        spriteRenderer.DOColor(fadedColor, fadedTime);
    }

    protected override void FadeOutColor(Color fadedColor, float fadedTime)
    {
        spriteRenderer.DOColor(fadedColor, fadedTime);
    }
}

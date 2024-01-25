using DG.Tweening;
using UnityEngine;

public class SpriteRenderderTransparentDetection : TransparentDetection
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    protected override Tween FadeInColor(Color fadedColor, float fadedTime)
    {
        return spriteRenderer.DOColor(fadedColor, fadedTime);
    }

    protected override Tween FadeOutColor(Color fadedColor, float fadedTime)
    {
        return spriteRenderer.DOColor(fadedColor, fadedTime);
    }
}

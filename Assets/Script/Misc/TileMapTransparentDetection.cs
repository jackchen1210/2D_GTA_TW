using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTransparentDetection : TransparentDetection
{
    [SerializeField] private Tilemap tilemap;

    protected override Tween FadeInColor(Color fadedColor, float fadedTime)
    {
        return DOTween.To(() => tilemap.color, _ => tilemap.color = _, fadedColor, fadedTime);
    }

    protected override Tween FadeOutColor(Color fadedColor, float fadedTime)
    {
        return DOTween.To(() => tilemap.color, _ => tilemap.color = _, fadedColor, fadedTime);
    }
}

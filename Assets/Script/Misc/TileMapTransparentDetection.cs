using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTransparentDetection : TransparentDetection
{
    [SerializeField] private Tilemap tilemap;

    protected override void FadeInColor(Color fadedColor, float fadedTime)
    {
        DOTween.To(()=>tilemap.color,_=>tilemap.color = _,fadedColor,fadedTime);
    }

    protected override void FadeOutColor(Color fadedColor, float fadedTime)
    {
        DOTween.To(() => tilemap.color, _ => tilemap.color = _, fadedColor, fadedTime);
    }
}

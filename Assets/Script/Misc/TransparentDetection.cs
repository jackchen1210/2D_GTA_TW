using UnityEngine;
using DG.Tweening;

public abstract class TransparentDetection : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] private float alpha = 0.8f;
    private float fadedTime = 0.4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision))
        {
            FadeOutColor(new Color(1,1,1, alpha), fadedTime);
        }
    }

    protected abstract void FadeOutColor(Color fadedColor, float fadedTime);
    protected abstract void FadeInColor(Color fadedColor, float fadedTime);

    private bool IsPlayer(Collider2D collision)
    {
        return collision.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision))
        {
            FadeInColor(Color.white, fadedTime);
        }
    }
}

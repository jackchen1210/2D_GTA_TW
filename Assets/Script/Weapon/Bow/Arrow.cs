using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private ParticleSystem hitPs;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float disappearTime = 1;
    [SerializeField] private float speed = 1;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (destroyCancellationToken.IsCancellationRequested)
        {
            return;
        }
        trailRenderer.Clear();
        gameObject.SetActive(false);
    }

    public async void Fly(Vector3 direction,Action onFlyEnd)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        transform.right = direction;
        rg.AddForce(direction* speed, ForceMode2D.Impulse);
        await UniTask.Delay((int)(1000*disappearTime));
        onFlyEnd?.Invoke();
    }
}

using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Action OnArrowHitBlocker { get; set; }

    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private ParticleSystem hitPsPrefab;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float disappearTime = 1;
    [SerializeField] private float speed = 1;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        trailRenderer.Clear();
        gameObject.SetActive(false);
    }

    public async void Fly(Vector3 direction, Action onFlyEnd)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        transform.right = direction;
        rg.AddForce(direction * speed, ForceMode2D.Impulse);
        await UniTask.Delay((int)(1000 * disappearTime));
        onFlyEnd?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<IArrowBlockable>(out var arrowBlockable))
        {
            return;
        }
        Instantiate(hitPsPrefab, transform.position, Quaternion.identity);
        OnArrowHitBlocker?.Invoke();
    }
}

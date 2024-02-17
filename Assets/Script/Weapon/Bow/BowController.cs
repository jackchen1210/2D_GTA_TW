using System;
using UnityEngine;
using UnityEngine.Pool;

public class BowController : MonoBehaviour, IWeapon
{
    [SerializeField] private Animator animator;
    [SerializeField] private Arrow arrowPrefab;
    private ObjectPool<Arrow> arrowPool;
    private int shootAniHash;

    private float arrow_bow_distance = 1.5f;

    private void Awake()
    {
        arrowPool = new ObjectPool<Arrow>(()=> { return Instantiate<Arrow>(arrowPrefab); },OnGetArrow,OnReleaseArrow);
        shootAniHash = Animator.StringToHash("Shoot");
    }

    private void OnReleaseArrow(Arrow arrow)
    {
        arrow.Hide();
    }

    private void FixedUpdate()
    {
        var direction = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        transform.right = direction;
    }

    private void OnGetArrow(Arrow arrow)
    {
        var isReleased = false;
        arrow.OnArrowHitBlocker = ReleaseArrow;
        arrow.Show();
        var direction = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        arrow.transform.position = transform.position + direction* arrow_bow_distance;
        arrow.Fly(direction, ReleaseArrow);
        void ReleaseArrow()
        {
            if (isReleased)
            {
                return;
            }

            isReleased = true;
            arrowPool.Release(arrow);
        }
    }

    public void Attack()
    {
        animator.SetTrigger(shootAniHash);
        arrowPool.Get();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public WeaponType GetWeaponType()
    {
        return WeaponType.Bow;
    }
}

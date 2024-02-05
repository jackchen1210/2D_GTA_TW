using System;
using UnityEngine;
using UnityEngine.Pool;

public class BowController : MonoBehaviour, IWeapon
{
    [SerializeField] private Animator animator;
    [SerializeField] private Arrow arrowPrefab;
    private ObjectPool<Arrow> arrowPool;
    private int shootAniHash;

    private void Awake()
    {
        arrowPool = new ObjectPool<Arrow>(()=> { return Instantiate<Arrow>(arrowPrefab); },OnGetArrow,OnReleaseArrow);
        shootAniHash = Animator.StringToHash("Shoot");
    }

    private void OnReleaseArrow(Arrow arrow)
    {
        arrow.Hide();
    }

    private void OnGetArrow(Arrow arrow)
    {
        arrow.Show();
        arrow.transform.position = transform.position;
        var direction = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        arrow.Fly(direction,()=> arrowPool.Release(arrow));
    }

    public void Attack()
    {
        Debug.Log("Bow Attack");
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

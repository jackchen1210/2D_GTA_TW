using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool IsGettingKnockBack { get; set; }

    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float knockbackTime = .2f;
    private WaitForSeconds waitForSeconds;

    private void Awake()
    {
        waitForSeconds = new WaitForSeconds(knockbackTime);
    }

    public void DoKnockBack(Transform damageSoruce, float thrust)
    {
        IsGettingKnockBack = true;
        var difference = (transform.position - damageSoruce.position).normalized * thrust * rg.mass;
        rg.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine()
    {
        yield return waitForSeconds;
        rg.velocity = Vector2.zero;
        IsGettingKnockBack = false;
    }
}

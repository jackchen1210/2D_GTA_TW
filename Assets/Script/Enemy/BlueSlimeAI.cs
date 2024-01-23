using System.Collections;
using UnityEngine;

public class BlueSlimeAI : MonoBehaviour
{
    private enum State
    {
        None,
        Roaming
    }

    [SerializeField] private EnemyPathFinding enemyPathFinding;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private KnockBack knockBack;
    [SerializeField] private Flash flash;
    [SerializeField] private DeathVFX deathVFX;

    private State currentState;
    private WaitForSeconds waitFor2Seconds = new WaitForSeconds(2);
    private void Start()
    {
        currentState = State.Roaming;
        StartCoroutine(ChangeTargetPos());
    }

    private IEnumerator ChangeTargetPos()
    {
        while (currentState == State.Roaming)
        {
            var targetPos = GetRandomTargetPos();
            enemyPathFinding.Move(targetPos);
            yield return waitFor2Seconds;
        }
    }

    private Vector2 GetRandomTargetPos()
    {
        return new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)).normalized;
    }

    internal void Damage(int dmg)
    {
        flash.DoFlash();
        enemyHealth.Damage(dmg);
        knockBack.DoKnockBack(PlayerController.GetInstance().transform,15f);

        if (enemyHealth.CurrentHealth <= 0)
        {
            SelfDestroy();
        }
    }

    private void SelfDestroy()
    {
        deathVFX.Show();
        enemyHealth.Death();
    }
}

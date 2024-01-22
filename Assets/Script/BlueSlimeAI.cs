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
    [SerializeField] private int health=3;

    private State currentState;
    private WaitForSeconds waitFor2Seconds = new WaitForSeconds(2);
    private int currentHealth;
    private void Start()
    {
        currentState = State.Roaming;
        StartCoroutine(ChangeTargetPos());
        currentHealth = health;
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
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}

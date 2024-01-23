using UnityEngine;

internal class EnemyHealth:MonoBehaviour
{
    [SerializeField] private int health = 3;
    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = health;
    }
    internal void Damage(int dmg)
    {
        CurrentHealth -= dmg;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
using UnityEngine;

public class ArrowHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BlueSlimeAI>(out var blueSlimeAI))
        {
            blueSlimeAI.Damage(1);
        }

        if (collision.TryGetComponent<Destructable>(out var destructable))
        {
            destructable.Destruct();
        }
    }
}

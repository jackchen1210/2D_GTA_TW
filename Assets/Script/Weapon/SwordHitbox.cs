using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<BlueSlimeAI>(out var blueSlimeAI))
        {
            blueSlimeAI.Damage(1);
        }
    }
}
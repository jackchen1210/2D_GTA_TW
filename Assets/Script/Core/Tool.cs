using UnityEngine;

public static class Tool
{
    public static bool IsPlayer(Collider2D collision)
    {
        return collision.CompareTag("Player");
    }
}
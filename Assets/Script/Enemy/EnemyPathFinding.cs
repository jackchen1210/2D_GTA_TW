using System;
using UnityEngine;

internal class EnemyPathFinding:MonoBehaviour
{
    [SerializeField] private bool isEnable = true;
    [SerializeField] private KnockBack knockBack;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float moveSpeed = 1;
    private Vector2 targetPos;

    internal void Move(Vector2 targetPos)
    {
        this.targetPos = targetPos;
    }

    private void FixedUpdate()
    {
        if (!isEnable)
        {
            return;
        }

        if (knockBack.IsGettingKnockBack)
        {
            return;
        }

        if(rg.position == targetPos)
        {
            return;
        }
        rg.MovePosition(rg.position + targetPos * moveSpeed * Time.fixedDeltaTime);
    }
}
using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;

    public void Show()
    {
        trailRenderer.emitting = true;
    }

    public void Hide()
    {
        trailRenderer.emitting = false;
    }

}

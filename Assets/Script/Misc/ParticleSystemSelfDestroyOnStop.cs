using System;
using UnityEngine;

public class ParticleSystemSelfDestroyOnStop : MonoBehaviour
{
    private void Awake()
    {
        var ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    public void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }
}

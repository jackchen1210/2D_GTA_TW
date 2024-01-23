using UnityEngine;

public class DeathVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathPsPrefab;

    private ParticleSystem deathPsInstance;

    public void Show()
    {
        if(deathPsInstance == null)
        {
            deathPsInstance = Instantiate<ParticleSystem>(deathPsPrefab, transform.position,Quaternion.identity);
        }
        deathPsInstance.Play();
    }
}

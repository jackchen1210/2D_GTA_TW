using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material whiteMat;
    private Material defaultMat;
    private WaitForSeconds waitForSeconds = new WaitForSeconds(.2f);

    private void Awake()
    {
        defaultMat = spriteRenderer.material;
    }

    public void DoFlash()
    {
        StartCoroutine(DelayFlash());
    }

    private IEnumerator DelayFlash()
    {
        spriteRenderer.material = whiteMat;
        yield return waitForSeconds;
        spriteRenderer.material = defaultMat;
    }
}

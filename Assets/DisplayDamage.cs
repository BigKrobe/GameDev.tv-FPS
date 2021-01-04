using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas _damageDisplayCanvas;
    [SerializeField] float _impactTime = 0.3f;

    private void Start()
    {
        _damageDisplayCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        _damageDisplayCanvas.enabled = true;
        yield return new WaitForSeconds(_impactTime);
        _damageDisplayCanvas.enabled = false;

    }
}

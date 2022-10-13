using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorNotifier : MonoBehaviour
{
    public float displayTime = 3.0f;

    private void OnEnable()
    {
        StartCoroutine(DeleteErrorMessage());
    }

    IEnumerator DeleteErrorMessage()
    {
        yield return new WaitForSeconds(displayTime);

        gameObject.SetActive(false);
    }
}

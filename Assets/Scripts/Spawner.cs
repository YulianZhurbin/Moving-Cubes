using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spawnInterval = 2;
    public GameObject cube;
    public TMP_Text errorMessage;
    public TMP_InputField spawnIntervalInputField;

    private Vector3 spawnPoint = new Vector3(0, 0, 0);

    private void Start()
    {
        SetSpawnInterval();
    }

    public void SetSpawnInterval()
    {
        if (int.TryParse(spawnIntervalInputField.text, out int result))
        {
            spawnInterval = result;

            if (spawnInterval < 1)
            {
                spawnInterval = 1;
                spawnIntervalInputField.text = spawnInterval.ToString();
                errorMessage.gameObject.SetActive(true);
            }
            else if (spawnInterval > 5)
            {
                spawnInterval = 5;
                spawnIntervalInputField.text = spawnInterval.ToString();
                errorMessage.gameObject.SetActive(true);
            }
        }
        else
        {
            spawnIntervalInputField.text = spawnInterval.ToString();
            errorMessage.gameObject.SetActive(true);
        }
    }

    public void SetSpawnTimer()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnInterval);

        cube.SetActive(true);
        cube.transform.position = spawnPoint;
    }
}

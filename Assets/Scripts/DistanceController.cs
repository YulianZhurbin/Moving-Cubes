using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DistanceController : MonoBehaviour
{
    public int distance = 20;
    public TMP_Text errorMessage;
    public TMP_InputField distanceInputField;

    public UnityEvent onCollision;

    private void Start()
    {
        SetDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (onCollision != null)
                onCollision.Invoke();
        }
    }

    public void SetDistance()
    {
        if(int.TryParse(distanceInputField.text, out int result))
        {
            distance = result;

            if(distance < 0)
            {
                distance = 0;
                distanceInputField.text = distance.ToString();
                errorMessage.gameObject.SetActive(true);
            }
            else if(distance > 50)
            {
                distance = 50;
                distanceInputField.text = distance.ToString();
                errorMessage.gameObject.SetActive(true);
            }
        }
        else
        {
            distanceInputField.text = distance.ToString();
            errorMessage.gameObject.SetActive(true);
        }

        transform.position = new Vector3(0, 0, distance);
    }
}

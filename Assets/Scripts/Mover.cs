using System;
using UnityEngine;
using TMPro;


public class Mover : MonoBehaviour
{
    public TMP_InputField speedInputField;
    private int speed = 10;
    public TMP_Text errorMessage;

    private void Start()
    {
        SetSpeed();
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void SetSpeed()
    {
        if(int.TryParse(speedInputField.text, out int result))
        {
            speed = result;

            if (speed < 5)
            {
                speed = 5;
                speedInputField.text = speed.ToString();
                errorMessage.gameObject.SetActive(true);
            }
            else if(speed > 50)
            {
                speed = 50;
                speedInputField.text = speed.ToString();
                errorMessage.gameObject.SetActive(true);
            }
        }
        else
        {
            speedInputField.text = speed.ToString();
            errorMessage.gameObject.SetActive(true);
        }     
    }
}

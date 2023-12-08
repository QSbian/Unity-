using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public float displayTIme_1 = 4.0f;
    public GameObject dialogBox_1;
    public GameObject dialogBox_2;
    float timerDisplay;
    float timerDisplay_1;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox_1.SetActive(false);
        dialogBox_2.SetActive(false);
        timerDisplay = -1.0f;
        timerDisplay_1 = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox_1.SetActive(false);
                dialogBox_2 .SetActive(true);
                timerDisplay_1 = displayTIme_1;
            }
        }
        if (timerDisplay_1 >= 0)
        {

            timerDisplay_1 -= Time.deltaTime;
            if (timerDisplay_1 < 0)
            {
                dialogBox_2.SetActive(false);
            }
        }



    }
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox_1.SetActive(true);
    }
}

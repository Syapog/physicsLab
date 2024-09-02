using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SText;
    [SerializeField] private TextMeshProUGUI VText;
    [SerializeField] private TextMeshProUGUI TText;
    [SerializeField] private TextMeshProUGUI BrakeTText;
    [SerializeField] private TextMeshProUGUI GasTText;

    [SerializeField] private bool IsTest;

    private float S = 0;
    private float V0 = 0, V = 0;
    private float T = 0, gasT = 0, brakeT = 0;
    private float N, m, g, my;

    bool timeIsCounted = false;

    private void Start()
    {

        N = 58800f;
        m = 1300000f;
        g = 9.8f;
        my = 0.8f;
    }

    private void FixedUpdate()
    {
        if(timeIsCounted)
        {
            T += Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.W))
        {

            V0 = V;
            if (!timeIsCounted)
                timeIsCounted = true;
            else
                gasT += Time.deltaTime;
            V = Mathf.Sqrt(V0 * V0 + 2 * N * gasT / m);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            if (timeIsCounted)
                brakeT += Time.deltaTime;
            V -= my * g * Time.deltaTime;
            if (V < 0)
                V = 0;
        }
        else
        {
            gasT = 0;
            brakeT = 0;
        }
        
        transform.Translate(0, 0, V * Time.deltaTime);
        S += V * Time.deltaTime;

        SText.text = "S = " + S;
        VText.text = "V = " + V;
        TText.text = "T = " + T;
        if(IsTest)
        {
            if (V > 0)
                BrakeTText.text = "brakeT = " + brakeT;
            if (V < 27.8f)
                GasTText.text = "gasT = " + gasT;
        }
        else
        {
            BrakeTText.text = "brakeT = " + brakeT;
            GasTText.text = "gasT = " + gasT;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class ResetButton : MonoBehaviour
{
    public EtchaScriptable etchData;
    public LineDrawer lineDrawer;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(11, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(11);

        if(buttonValue == 1)
        {
            lineDrawer.Reset();
            Debug.Log("reset");
        }
    }
}

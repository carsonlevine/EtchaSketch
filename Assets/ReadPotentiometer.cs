using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;



public class ReadPotentiometer : MonoBehaviour
{
    UduinoManager manager; 
    public Slider Rslider;
    public Slider Gslider;
    public Slider Bslider;


    // Start is called before the first frame update
    void Start()
    {
        manager = UduinoManager.Instance;
        manager.pinMode(AnalogPin.A0, PinMode.Input);
        manager.pinMode(AnalogPin.A1, PinMode.Input);
        manager.pinMode(AnalogPin.A2, PinMode.Input);

        
    }

    // Update is called once per frame
    void Update()
    {
        float redValue = manager.analogRead(AnalogPin.A0)/1023.0f;
        float greenValue = manager.analogRead(AnalogPin.A1)/1023.0f;
        float blueValue = manager.analogRead(AnalogPin.A2)/1023.0f;

        // Debug.Log(redValue);
        // Debug.Log(manager.analogRead(AnalogPin.A0));


        Rslider.value = redValue;
        Gslider.value = greenValue;
        Bslider.value = blueValue;
    }
}

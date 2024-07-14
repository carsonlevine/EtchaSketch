using Uduino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadEncoder : MonoBehaviour
{

    UduinoManager manager; 
    public EtchaScriptable etchData;

    // Start is called before the first frame update
    void Start()
    {
        // manager = UduinoManager.Instance;
        // UduinoManager.Instance.OnDataReceived += DataReceived;
        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    void DataReceived(string data, UduinoDevice board)
    {
        // data= x,y,z,r,g,b ; xyz = change since beginning
        Debug.Log(data);
        string[] values = data.Split(',');

        string xString = values[0];
        string yString = values[1];
        string zString = values[2];

        string rString = values[3];
        string gString = values[4];
        string bString = values[5];

        // encoder values
        int xValue;
        int yValue;
        int zValue;

        // convert
        int.TryParse(xString, out xValue);
        int.TryParse(yString, out yValue);
        int.TryParse(zString, out zValue);

        // store previous X
        etchData.xPrev = etchData.xValue;
        etchData.yPrev = etchData.yValue;
        etchData.zPrev= etchData.zValue;

        //set new value
        etchData.xValue = xValue;
        etchData.yValue = yValue;
        etchData.zValue = zValue;
        
        // convert rgb to integers, store new data in SO
        int rValue;
        int gValue;
        int bValue;
        int.TryParse(rString, out rValue);
        int.TryParse(gString, out gValue);
        int.TryParse(bString, out bValue);
        etchData.rPrev = etchData.rValue;
        etchData.gPrev = etchData.gValue;
        etchData.bPrev = etchData.bValue;

        etchData.rValue = rValue;
        etchData.gValue = gValue;
        etchData.bValue = bValue;
    }
}

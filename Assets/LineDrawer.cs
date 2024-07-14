using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    public EtchaScriptable etchData;
    List<Vector3> linePoints;
    float timer;


    GameObject newLine;
    LineRenderer drawLine;

    // Start is called before the first frame update
    void Start()
    {
        etchData.xValue = 0;
        etchData.yValue = 0;
        etchData.zValue = 0;

        etchData.startColor = new Color(etchData.rValue,etchData.gValue,etchData.bValue);
        etchData.endColor = new Color(etchData.rValue,etchData.gValue,etchData.bValue);
        linePoints = new List<Vector3>();
        transform.position = new Vector3(etchData.xValue, etchData.yValue, etchData.zValue);
        timer = etchData.timerDelay;

        NewLine();

    }

    // Update is called once per frame
    void Update()
    {
        if (etchData.xPrev != etchData.xValue)
        {
            etchData.xPrev = etchData.xValue;
            etchData.yPrev = etchData.yValue;
            etchData.zPrev = etchData.zValue;

            

            if (timer<=0)
            {
                // if (etchData.xValue < -4768)
                // {
                //     etchData.xValue = 4768;
                // }
                // if (etchData.xValue > 4768)
                // {
                //     etchData.xValue = -4768;
                // }
                //  if (etchData.yValue < -2000)
                // {
                //     etchData.yValue = 2317;
                // }
                // if (etchData.yValue > 2317)
                // {
                //     etchData.yValue = -2000;
                // }
                linePoints.Add(new Vector3(etchData.xValue, etchData.yValue, etchData.zValue ));
                Debug.Log(linePoints.Count);
                Debug.Log(linePoints[0]);
                Debug.Log(linePoints[linePoints.Count-1]);
            }
            timer -= Time.deltaTime;
        }

        else if (etchData.yPrev != etchData.yValue)
        {
            etchData.xPrev = etchData.xValue;
            etchData.yPrev = etchData.yValue;
            etchData.zPrev = etchData.zValue;

            if (timer<=0)
            {
                linePoints.Add(new Vector3(etchData.xValue, etchData.yValue, etchData.zValue));
                Debug.Log(linePoints.Count);
                Debug.Log(linePoints[0]);
                Debug.Log(linePoints[linePoints.Count-1]);
            }
            timer -= Time.deltaTime;
        }
        else if (etchData.zPrev != etchData.zValue)
        {
            etchData.xPrev = etchData.xValue;
            etchData.yPrev = etchData.yValue;
            etchData.zPrev = etchData.zValue;

            if (timer<=0)
            {
                linePoints.Add(new Vector3(etchData.xValue, etchData.yValue, etchData.zValue));
                Debug.Log(linePoints.Count);
                Debug.Log(linePoints[0]);
                Debug.Log(linePoints[linePoints.Count-1]);
                timer = etchData.timerDelay;
            }
            timer -= Time.deltaTime;
        }
        UpdateLine();
    }

    void NewLine()
    {
        newLine = new GameObject();
        drawLine = newLine.AddComponent<LineRenderer>();
        drawLine.material = new Material(Shader.Find("Sprites/Default"));
        drawLine.startWidth = etchData.lineWidth;
        drawLine.endWidth = etchData.lineWidth;
        Color updatedColor = new Color(etchData.rValue,etchData.gValue,etchData.bValue);

        drawLine.startColor = updatedColor;
        drawLine.endColor = updatedColor;
        drawLine.material.color = updatedColor;
        etchData.startColor = updatedColor;
        etchData.endColor = updatedColor;

    }

    void UpdateLine()
    {
        drawLine.positionCount = linePoints.Count;
        drawLine.SetPositions(linePoints.ToArray());
        //drawLine.material.color = new Color(etchData.rValue,etchData.gValue,etchData.bValue);
        Color updatedColor = new Color(etchData.rValue,etchData.gValue,etchData.bValue);

        drawLine.startColor = updatedColor;
        drawLine.endColor = updatedColor;
        drawLine.material.color = updatedColor;
        etchData.startColor = updatedColor;
        etchData.endColor = updatedColor;

    }

    public void Reset()
    {
        var lines = FindObjectsOfType<LineRenderer>();
        foreach(LineRenderer line in lines) {
            Destroy(line);
        }
    }


}


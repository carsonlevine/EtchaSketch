using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public EtchaScriptable etchData;
    private List<Vector3> linePoints;
    private float timer;
    private GameObject newLine;
    private LineRenderer drawLine;

    void Start()
    {
        InitializeEtchData();
        linePoints = new List<Vector3>();
        transform.position = new Vector3(etchData.xValue, etchData.yValue, etchData.zValue);
        timer = etchData.timerDelay;
        NewLine();
    }

    void Update()
    {
        if (HasEtchDataChanged())
        {
            UpdateEtchDataPreviousValues();

            if (timer <= 0)
            {
                AddLinePoint();
                timer = etchData.timerDelay; // Reset timer after adding a point
            }

            timer -= Time.deltaTime;
        }

        UpdateLine();
    }

    private void InitializeEtchData()
    {
        etchData.xValue = 0;
        etchData.yValue = 0;
        etchData.zValue = 0;
        etchData.startColor = new Color(etchData.rValue / 255f, etchData.gValue / 255f, etchData.bValue / 255f);
        etchData.endColor = new Color(etchData.rValue / 255f, etchData.gValue / 255f, etchData.bValue / 255f);
    }

    private bool HasEtchDataChanged()
    {
        return etchData.xPrev != etchData.xValue || etchData.yPrev != etchData.yValue || etchData.zPrev != etchData.zValue;
    }

    private void UpdateEtchDataPreviousValues()
    {
        etchData.xPrev = etchData.xValue;
        etchData.yPrev = etchData.yValue;
        etchData.zPrev = etchData.zValue;
    }

    private void AddLinePoint()
    {
        linePoints.Add(new Vector3(etchData.xValue, etchData.yValue, etchData.zValue));
        Debug.Log(linePoints.Count);
        Debug.Log(linePoints[0]);
        Debug.Log(linePoints[linePoints.Count - 1]);
    }

    void NewLine()
    {
        newLine = new GameObject("Line");
        drawLine = newLine.AddComponent<LineRenderer>();
        drawLine.material = new Material(Shader.Find("Sprites/Default"));
        drawLine.startWidth = etchData.lineWidth;
        drawLine.endWidth = etchData.lineWidth;
        UpdateLineColor();
    }

    void UpdateLine()
    {
        drawLine.positionCount = linePoints.Count;
        drawLine.SetPositions(linePoints.ToArray());
        UpdateLineColor();
    }

    private void UpdateLineColor()
    {
        Color updatedColor = new Color(etchData.rValue / 255f, etchData.gValue / 255f, etchData.bValue / 255f);
        drawLine.startColor = updatedColor;
        drawLine.endColor = updatedColor;
        drawLine.material.color = updatedColor;
        etchData.startColor = updatedColor;
        etchData.endColor = updatedColor;
    }

    public void Reset()
    {
        var lines = FindObjectsOfType<LineRenderer>();
        foreach (LineRenderer line in lines)
        {
            Destroy(line.gameObject);
        }
    }
}

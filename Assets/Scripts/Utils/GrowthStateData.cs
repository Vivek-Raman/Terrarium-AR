using UnityEngine;

[System.Serializable]
public class GrowthStateData
{
    public string stateName;
    [TextArea(2, 6)]
    public string helperText;
    public GameObject model;
}
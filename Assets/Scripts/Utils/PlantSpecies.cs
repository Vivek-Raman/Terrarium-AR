using UnityEngine;

[System.Serializable]
public class PlantSpecies
{
    public string name;
    public int speciesID;
    public Sprite thumbnail;
    public string description;
    public GrowthStateData[] growthStates;
    public int dryTolerance;
}
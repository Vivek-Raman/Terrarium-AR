using System;
using APIs.Data;
using UnityEngine;
using UnityEngine.Events;

public class PlantContainer : MonoBehaviour
{
    public static UnityAction<Plant> playerEntersPlantProximityAction;
    public static UnityAction<Plant> playerExitsPlantProximityAction;

    [SerializeField] private PlantSpeciesDirectory speciesDirectory;

    private Plant plant = null;

    public void SetPlantState(Plant plant)
    {
        this.plant = plant;
        Debug.Log($"\"{speciesDirectory.FindSpeciesByID(plant.speciesID).name}\", planted on {plant.dateOfPlanting}, unwatered for {plant.unwateredDayCount}, at state {plant.growthState}");
        // determine state?

        Transform plantRoot = this.transform.GetChild(0).GetChild(0);
        GameObject plantPrefab = speciesDirectory.FindSpeciesByID(plant.speciesID).growthStates[plant.GrowthState].model;
        if (plantPrefab == null) return;
        Instantiate(plantPrefab, plantRoot.position, plantRoot.rotation, plantRoot);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.plant == null) throw new Exception("Plant data not set.");
        if (!other.CompareTag("MainCamera")) return;

        playerEntersPlantProximityAction?.Invoke(plant);
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.plant == null) throw new Exception("Plant data not set.");
        if (!other.CompareTag("MainCamera")) return;

        playerExitsPlantProximityAction?.Invoke(plant);
    }

    [ContextMenu(nameof(Debug_SetTempPlant))]
    private void Debug_SetTempPlant()
    {
        Debug.LogWarning("Test method called");
        SetPlantState(new Plant("plant-id", 1, new User(), "now", 0f, 0f, 0f, 0f, 0f, 0f, 0, 1));
    }
}
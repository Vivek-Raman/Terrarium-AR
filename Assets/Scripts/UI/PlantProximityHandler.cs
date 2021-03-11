using System;
using APIs.Data;
using TMPro;
using UnityEngine;

public class PlantProximityHandler : MonoBehaviour
{
    [SerializeField] private GameObject infoPlantButton = null;
    [SerializeField] private GameObject waterPlantButton = null;
    [SerializeField] private GameObject trimPlantButton = null;


    private void Awake()
    {
        PlantContainer.playerEntersPlantProximityAction += OnPlayerEntersPlantProximity;
        PlantContainer.playerExitsPlantProximityAction += OnPlayerExitsPlantProximity;
    }

    private void OnDestroy()
    {
        PlantContainer.playerEntersPlantProximityAction -= OnPlayerEntersPlantProximity;
        PlantContainer.playerExitsPlantProximityAction -= OnPlayerExitsPlantProximity;
    }

    private void OnPlayerEntersPlantProximity(Plant plant)
    {
        infoPlantButton.SetActive(true);
        waterPlantButton.SetActive(true);
        trimPlantButton.SetActive(plant.growthState > 7);
        
        Debug.Log("player enters " + plant.plantID);
    }

    private void OnPlayerExitsPlantProximity(Plant plant)
    {
        infoPlantButton.SetActive(false);
        waterPlantButton.SetActive(false);
        trimPlantButton.SetActive(false);

        Debug.Log("player exits " + plant.plantID);
    }
}
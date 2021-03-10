using System;
using APIs.Data;
using TMPro;
using UnityEngine;

public class PlantProximityHandler : MonoBehaviour
{
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
        Debug.Log("player enters " + plant.plantID);
    }

    private void OnPlayerExitsPlantProximity(Plant plant)
    {
        // hide water button

        // hide trim button

        Debug.Log("player exits " + plant.plantID);
    }
}
using APIs.Data;
using UnityEngine;

public class PlantProximityHandler : MonoBehaviour
{
    [SerializeField] private GameObject infoPlantButton = null;
    [SerializeField] private GameObject waterPlantButton = null;
    [SerializeField] private GameObject trimPlantButton = null;

    [SerializeField] private PlantSpeciesDirectory plantSpeciesDirectory = null;

    [SerializeField] private PlantInfoCardHandler infoCard = null;

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
        ShowButtons(plant.GrowthState);
        infoCard.SetText(
            plantSpeciesDirectory.FindSpeciesByID(plant.speciesID).growthStates[plant.GrowthState].stateName,
            plantSpeciesDirectory.FindSpeciesByID(plant.speciesID).growthStates[plant.GrowthState].helperText);
    }

    private void OnPlayerExitsPlantProximity(Plant plant)
    {
        HideButtons();
        // infoCard.SetText("", "");
    }

    private void ShowButtons(int plantGrowthState)
    {
        infoPlantButton.SetActive(true);
        waterPlantButton.SetActive(true);
        trimPlantButton.SetActive(plantGrowthState > 7);
    }

    private void HideButtons()
    {
        infoPlantButton.SetActive(false);
        waterPlantButton.SetActive(false);
        trimPlantButton.SetActive(false);
    }
}
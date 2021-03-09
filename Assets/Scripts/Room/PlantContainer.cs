using APIs.Data;
using UnityEngine;

public class PlantContainer : MonoBehaviour
{
    [SerializeField] private PlantSpeciesDirectory speciesDirectory;


    public void SetPlantState(int speciesID, string dateOfPlanting, int unwateredDayCount, int growthState)
    {
        Debug.Log($"\"{speciesDirectory.FindSpeciesByID(speciesID).name}\", planted on {dateOfPlanting}, unwatered for {unwateredDayCount}, at state {growthState}");
        // determine state?
        // set up actionable zone
    }
}
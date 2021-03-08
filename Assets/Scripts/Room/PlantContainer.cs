using APIs.Data;
using UnityEngine;

public class PlantContainer : MonoBehaviour
{
    public void SetPlantState(Species species, string dateOfPlanting, int unwateredDayCount)
    {
        Debug.Log($"\"{species.speciesName}\", planted on {dateOfPlanting}, unwatered for {unwateredDayCount}");
    }
}
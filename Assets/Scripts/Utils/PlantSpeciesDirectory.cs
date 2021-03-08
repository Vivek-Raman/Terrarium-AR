using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlantSpeciesDirectory : ScriptableObject
{
    public List<PlantSpecies> species;

    public PlantSpecies FindSpeciesByID(int speciesID)
    {
        for (var i = 0; i < species.Count; i++)
        {
            if (speciesID == species[i].speciesID)
            {
                return species[i];
            }
        }

        return null;
    }
}
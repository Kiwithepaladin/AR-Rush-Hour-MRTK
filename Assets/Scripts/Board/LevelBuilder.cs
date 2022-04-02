using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public partial class LevelBuilder : ScriptableObject
{
    [SerializeField] private List<UnitData> units;
    [SerializeField] private GameObject basePrefabCar;
    [SerializeField] private GameObject basePrefabTruck;
    public Transform parentObject;

    public void InitializeLevel()
    {
        foreach (UnitData unit in units)
        {
            if(unit.type == VehicleType.Car)
            {
                GameObject newUnit = Instantiate(basePrefabCar,unit.initalPosition,unit.initalRotation,parentObject);
                newUnit.GetComponentInChildren<MeshRenderer>().material = unit.colorMaterial;
            }
            else
            {
                GameObject newUnit = Instantiate(basePrefabTruck,unit.initalPosition,unit.initalRotation,parentObject);
                newUnit.GetComponentInChildren<MeshRenderer>().material = unit.colorMaterial;
            }
        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Board 
{
    public List<Tile> allTiles = new List<Tile>();
    private const int BOARD_SIZE = 6;
    public List<UnitBase> allUnits = new List<UnitBase>();
    public UnitBase PlayerUnit;
    public List<Tile> OccupiedTiles {get => UpdateOccupiedTiles();}
    public Board()
    {
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                Tile newTile = new Tile(new Vector3(i,0,j));
                allTiles.Add(newTile);
            }
        }
        allUnits =  GameObject.FindObjectsOfType<UnitBase>().ToList();
        PlayerUnit = allUnits[0];
    }
    public List<Tile> UpdateOccupiedTiles()
    {
        List<Tile> tempList = new List<Tile>();
        //Reseting all occupied tiles to false
        foreach (Tile tile in allTiles)
        {
            tile.IsOccupied = false;
        }
        //Foreach tile that is in units reach set them to occupied
        foreach (UnitBase unit in allUnits)
        {
            foreach (Tile selfTile in unit.TilesOccupiedBySelf)
            {
                selfTile.IsOccupied = true;
                tempList.Add(selfTile);
            }
        }
        return tempList;
    }
}

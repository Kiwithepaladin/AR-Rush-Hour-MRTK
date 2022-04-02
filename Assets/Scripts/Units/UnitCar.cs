using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCar : UnitBase
{
    protected override List<Tile> OccupiedTiles()
    {
        List<Tile> tempTiles = new List<Tile>();
        var chacheCurrent = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition);
        if(chacheCurrent != null)
            tempTiles.Add(chacheCurrent);
        return tempTiles;
    }
}

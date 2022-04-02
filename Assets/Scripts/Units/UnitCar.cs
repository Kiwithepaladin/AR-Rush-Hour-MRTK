using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCar : UnitBase
{
    protected override List<Tile> OccupiedTiles()
    {
        List<Tile> tempTiles = new List<Tile>();
        var chacheCurrent = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition);
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            var chacheRight = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == chacheCurrent.TilePosition + Vector3.right);
            if(chacheCurrent != null || chacheCurrent != null)
            {
                tempTiles.Add(chacheCurrent);
                tempTiles.Add(chacheRight);
            }
        }
        else if(VehicleDirection == VehicleDirection.Vertical)
        {
            var chacheRight = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == chacheCurrent.TilePosition + Vector3.forward);
            if(chacheCurrent != null || chacheCurrent != null)
            {
                tempTiles.Add(chacheCurrent);
                tempTiles.Add(chacheRight);
            }
        }
        return tempTiles;
    }
}

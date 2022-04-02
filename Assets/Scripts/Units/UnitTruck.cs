using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTruck : UnitBase
{
    protected override List<Tile> OccupiedTiles()
    {
        List<Tile> tempTiles = new List<Tile>();
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            var chacheCurrent = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition);
            var chacheRight = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == chacheCurrent.TilePosition + Vector3.right);
            var chacheLeft = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == chacheCurrent.TilePosition + Vector3.left); 
            if(chacheRight != null || chacheCurrent != null || chacheLeft != null)
            {
                tempTiles.Add(chacheCurrent);
                tempTiles.Add(chacheRight);
                tempTiles.Add(chacheLeft);
            }
        }
        //Added an if just in case  I will decide to add more directions in the future
        else if(VehicleDirection == VehicleDirection.Vertical)
        {
            var chacheCurrent = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition);
            var chacheRight = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == chacheCurrent.TilePosition + Vector3.forward);
            var chacheLeft = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == chacheCurrent.TilePosition + Vector3.back); 
            if(chacheRight != null && chacheCurrent != null && chacheLeft != null)
            {
                tempTiles.Add(chacheCurrent);
                tempTiles.Add(chacheRight);
                tempTiles.Add(chacheLeft);
            }
        }
        return tempTiles;
    }
}

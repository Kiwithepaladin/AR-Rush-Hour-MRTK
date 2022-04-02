using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //Tile victoryTile;
    private Vector3 victoryTilePosition = new Vector3(5,0,3);
    // private void Start()
    // {
    //     victoryTile = BoardBuilder.gameBoard.allTiles.Find((t) => t.TilePosition == victoryTilePosition);
    // }
    private void Update()
    {
        if(BoardBuilder.gameBoard.PlayerUnit.TilesOccupiedBySelf.Contains(BoardBuilder.gameBoard.allTiles.Find((t) => t.TilePosition == victoryTilePosition)))
        {
            print("VICTORYYYYYYY");
        }
    }
}

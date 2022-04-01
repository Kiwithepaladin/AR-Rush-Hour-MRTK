using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBuilder : MonoBehaviour
{
    Board gameBoard;
    [SerializeField] List<GameObject> physicalObjects;
    [SerializeField] private GameObject physicalTileAppearance;
    private void Awake() 
    {
        gameBoard = new Board();
        physicalObjects = new List<GameObject>();
        foreach (Tile tile in gameBoard.allTiles)
        {
            physicalObjects.Add(Instantiate(physicalTileAppearance,tile.TilePosition,Quaternion.identity));
        }
    }
}

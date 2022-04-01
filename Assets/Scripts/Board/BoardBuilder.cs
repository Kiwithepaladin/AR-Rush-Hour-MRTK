using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BoardBuilder : MonoBehaviour
{
    public static Board gameBoard;
    [SerializeField] List<GameObject> physicalObjects;
    [SerializeField] private GameObject physicalTileAppearance;
    private void Awake() 
    {
        gameBoard = new Board();
        physicalObjects = new List<GameObject>();
        foreach (Tile tile in gameBoard.allTiles)
        {
            GameObject tilePhysical = Instantiate(physicalTileAppearance,tile.TilePosition,Quaternion.identity,transform);
            tilePhysical.AddComponent<TileMono>().SetTileData(tile);
            physicalObjects.Add(tilePhysical);
        }
    }
}

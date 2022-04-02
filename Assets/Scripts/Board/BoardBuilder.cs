using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BoardBuilder : MonoBehaviour
{
    public static Board gameBoard;
    [SerializeField] List<GameObject> physicalObjects;
    //made just for debugging reasons
    [SerializeField] private List<Tile> occupied;
    [SerializeField] private GameObject physicalTileAppearance;
    [SerializeField] private LevelBuilder levleBuilder;
    private void Awake() 
    {
        levleBuilder.parentObject = transform;
        levleBuilder.InitializeLevel();
        gameBoard = new Board();
        physicalObjects = new List<GameObject>();
        foreach (Tile tile in gameBoard.allTiles)
        {
            GameObject tilePhysical = Instantiate(physicalTileAppearance,tile.TilePosition,Quaternion.identity,transform);
            tilePhysical.AddComponent<TileMono>().SetTileData(tile);
            physicalObjects.Add(tilePhysical);
        }
    }
    private void Update()
    {
        occupied = gameBoard.OccupiedTiles;
    }
}

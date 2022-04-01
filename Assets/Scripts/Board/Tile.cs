using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Tile
{
    [SerializeField] private Vector3 tilePosition;
    public Vector3 TilePosition {get => tilePosition; set => tilePosition = value;}
    public bool IsOccupied;
    public Tile(Vector3 initialPos)
    {
        tilePosition = initialPos;
    }
    public Tile()
    {
        tilePosition = Vector3.zero;
    }
}

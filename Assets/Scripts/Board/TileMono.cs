using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMono : MonoBehaviour
{
    [SerializeField] private Tile tileData;
    public void SetTileData(Tile newTileData)
    {
        tileData = newTileData;
    }
}

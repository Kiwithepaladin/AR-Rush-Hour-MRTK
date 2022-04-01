using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board 
{
    public List<Tile> allTiles = new List<Tile>();
    private const int BOARD_SIZE = 6;
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
    } 
}

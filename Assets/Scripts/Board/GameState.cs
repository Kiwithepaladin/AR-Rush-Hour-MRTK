using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool Victory {get => BoardBuilder.gameBoard.allTiles.Find((t) => t.IsOccupied) != null ? true : false;} 


    private void Update()
    {
        if(Victory)
        {
            print("VICTORYYYYYYY");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract partial class UnitBase : MonoBehaviour
{
    [SerializeField] private int selfSizeOnGrid = 1;
    [SerializeField] private Vector3 roundedPos;
    [SerializeField] protected Vector3 RoundedPosition {get => new Vector3(
        RoundToNearestGrid(transform.position.x), 
        0f, 
        RoundToNearestGrid(transform.position.z));}
    public bool IsPlaced {get => TilesOccupiedBySelf.Count > 0 ? true : false;}
    private List<Tile> occupiedTilesSelf;
    protected List<Tile> TilesOccupiedBySelf {get => OccupiedTiles();}
    [SerializeField] private GameObject arrowForward,arrowBackward;
    [SerializeField] private VehicleDirection vehicleDir;
    [SerializeField] private VehicleDirection VehicleDirection {get => transform.rotation.y == 0 ?  VehicleDirection.Horizontal : VehicleDirection.Vertical;}
    private void Update()
    {
        roundedPos = RoundedPosition;
        vehicleDir = VehicleDirection;
        occupiedTilesSelf = TilesOccupiedBySelf;
        //Editors note, I need to find a more elegant way of doing this.
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            if(BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.right) == null)
            {
                arrowForward.SetActive(false);
            }
            else
            {
                arrowForward.SetActive(true);
            }
            if(BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.left) == null)
            {
                arrowBackward.SetActive(false);
            }
            else
            {
                arrowBackward.SetActive(true);
            }
        }
        else
        {
            if(BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.forward) == null)
            {
                arrowForward.SetActive(false);
            }
            else
            {
                arrowForward.SetActive(true);
            }
            if(BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.back) == null)
            {
                arrowBackward.SetActive(false);
            }
            else
            {
                arrowBackward.SetActive(true);
            }
        }
        // else 
        // {
        //     rightArrow.SetActive(false);
        //     leftArrow.SetActive(false);
        //     if(BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.forward) == null)
        //     {
        //         forwardArrow.SetActive(false);
        //     }
        //     else
        //     {
        //         forwardArrow.SetActive(true);
        //     }
        //     if(BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.back) == null)
        //     {
        //         backwardArrow.SetActive(false);
        //     }
        //     else
        //     {
        //         backwardArrow.SetActive(true);
        //     }
        // }
    }
    public void FlagMovement(ArrowDirection arrowDirection)
    {
        Tile tileExists = new Tile();
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            if(arrowDirection == ArrowDirection.Forward)
            {
                transform.position += Vector3.right;
            }
            if(arrowDirection == ArrowDirection.Backward)
            {
                transform.position += Vector3.left;
            }
        }
        else
        {
            if(arrowDirection == ArrowDirection.Forward)
            {
                transform.position += Vector3.forward;
            }
            if(arrowDirection == ArrowDirection.Backward)
            {
                transform.position += Vector3.back;
            }
        }
    }
    private List<Tile> OccupiedTiles()
    {
        List<Tile> tempTiles = new List<Tile>();
        foreach (var tile in BoardBuilder.gameBoard.allTiles)
        {
            //0.2f is just a small number can be changed later (if needed)
            if(Vector3.Distance(tile.TilePosition,RoundedPosition) < 0.2f)
            {
                tempTiles.Add(tile);
            }
        }
        return tempTiles;
    }
    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % selfSizeOnGrid;
        pos -= xDiff;
        if (xDiff > (selfSizeOnGrid / 2))
        {
            pos += selfSizeOnGrid;
        }
        return pos;
    }
}

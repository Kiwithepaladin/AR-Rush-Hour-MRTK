using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract partial class UnitBase : MonoBehaviour
{
    //Currently only supports two vehicle types
    protected int selfSizeOnGrid {get => this is UnitCar ? 1 : 3;}
    [SerializeField] private Vector3 roundedPos;
    [SerializeField] protected Vector3 RoundedPosition {get => new Vector3(
        Mathf.Round(transform.position.x), 
        0f, 
        Mathf.Round(transform.position.z));}
    public bool IsPlaced {get => TilesOccupiedBySelf.Count > 0 ? true : false;}
    [SerializeField] private List<Tile> occupiedTilesSelf;
    public List<Tile> TilesOccupiedBySelf {get => OccupiedTiles();}
    [SerializeField] private GameObject arrowForward,arrowBackward;
    [SerializeField] private VehicleDirection vehicleDir;
    [SerializeField] protected VehicleDirection VehicleDirection {get => transform.rotation.y != 0 ?  VehicleDirection.Vertical : VehicleDirection.Horizontal;}
    private void Update()
    {
        roundedPos = RoundedPosition;
        vehicleDir = VehicleDirection;
        occupiedTilesSelf = TilesOccupiedBySelf;
        //Editors note, I need to find a more elegant way of doing this.
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            var chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.right + Vector3.right);
            if(chache == null || chache.IsOccupied)
            {
                arrowForward.SetActive(false);
            }
            else
            {
                arrowForward.SetActive(true);
            }
            chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.left + Vector3.left);
            if(chache == null || chache.IsOccupied)
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
            var chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.forward + Vector3.forward);
            if(chache == null || chache.IsOccupied)
            {
                arrowForward.SetActive(false);
            }
            else
            {
                arrowForward.SetActive(true);
            }
            chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.back + Vector3.back);
            if(chache == null || chache.IsOccupied)
            {
                arrowBackward.SetActive(false);
            }
            else
            {
                arrowBackward.SetActive(true);
            }
        }
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
    protected abstract List<Tile> OccupiedTiles();
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

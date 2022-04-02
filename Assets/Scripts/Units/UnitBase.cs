using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract partial class UnitBase : MonoBehaviour
{
    //Currently only supports two vehicle types
    protected int selfSizeOnGrid {get => this is UnitCar ? 2 : 3;}
    [SerializeField] private Vector3 roundedPos;
    [SerializeField] protected Vector3 RoundedPosition {get => new Vector3(
        Mathf.Round(transform.localPosition.x), 
        0f, 
        Mathf.Round(transform.localPosition.z));}

    [SerializeField] private Vector3 objectCenter;
    [SerializeField] private List<Tile> occupiedTilesSelf;
    public List<Tile> TilesOccupiedBySelf {get => OccupiedTiles();}
    public Tile primaryTile {get => BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition);}
    [SerializeField] private GameObject arrowForward,arrowBackward;
    [SerializeField] private VehicleDirection vehicleDir;
    [SerializeField] protected VehicleDirection VehicleDirection {get => transform.rotation.y != 0 ?  VehicleDirection.Vertical : VehicleDirection.Horizontal;}
    private void Update()
    {
        roundedPos = RoundedPosition;
        vehicleDir = VehicleDirection;
        occupiedTilesSelf = TilesOccupiedBySelf;


        Bounds bounds = new Bounds(transform.position, Vector3.zero);

        foreach(Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }

        objectCenter = transform.TransformPoint(bounds.center - this.transform.position);
        objectCenter = new Vector3(Mathf.Round(objectCenter.x), 0.5f, Mathf.Round(objectCenter.z));
        arrowForward.SetActive(true);
        arrowBackward.SetActive(true);

        //Editors note, I need to find a more elegant way of doing this.
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            var chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.right + Vector3.right);
            if(chache == null || chache.IsOccupied)
            {
                arrowForward.SetActive(false);
            }
            chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.left + Vector3.left);
            if(this is UnitCar)
                chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == primaryTile.TilePosition + Vector3.left);
            if(chache == null || chache.IsOccupied)
            {
                arrowBackward.SetActive(false);
            }
        }
        else
        {
            var chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.forward + Vector3.forward);
            if(chache == null || chache.IsOccupied)
            {
                arrowForward.SetActive(false);
            }
            chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.back + Vector3.back);
            if(this is UnitCar)
                chache = BoardBuilder.gameBoard.allTiles.Find((tile) => tile.TilePosition == RoundedPosition + Vector3.back);
            if(chache == null || chache.IsOccupied)
            {
                arrowBackward.SetActive(false);
            }
        }
    }
    public void FlagMovement(ArrowDirection arrowDirection)
    {
        if(VehicleDirection == VehicleDirection.Horizontal)
        {
            if(arrowDirection == ArrowDirection.Forward)
            {
                transform.localPosition += Vector3.right;
            }
            if(arrowDirection == ArrowDirection.Backward)
            {
                transform.localPosition += Vector3.left;
            }
        }
        else
        {
            if(arrowDirection == ArrowDirection.Forward)
            {
                transform.localPosition += Vector3.forward;
            }
            if(arrowDirection == ArrowDirection.Backward)
            {
                transform.localPosition += Vector3.back;
            }
        }
    }
    
    private void CalculateLocalBounds()
     {
         Quaternion currentRotation = this.transform.rotation;
         this.transform.rotation = Quaternion.Euler(0f,0f,0f);
 
         Bounds bounds = new Bounds(this.transform.position, Vector3.zero);
 
         foreach(Renderer renderer in GetComponentsInChildren<Renderer>())
         {
             bounds.Encapsulate(renderer.bounds);
         }
 
         Vector3 localCenter = bounds.center - this.transform.position;
         bounds.center = localCenter;
         Debug.Log("The local bounds of this model is " + bounds);
 
         this.transform.rotation = currentRotation;
    }
    protected abstract List<Tile> OccupiedTiles();
}

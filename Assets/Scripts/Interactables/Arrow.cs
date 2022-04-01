using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
public class Arrow : MonoBehaviour, IMixedRealityPointerHandler
{
    [SerializeField] private ArrowDirection arrowDirection;
    private UnitBase vehicle;
    private void Awake()
    {
        vehicle = GetComponentInParent<UnitBase>();
    }
    private void Update()
    {
    }
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        return;
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        vehicle.FlagMovement(arrowDirection);  
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        return;
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        return;
    }
}

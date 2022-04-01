using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSupervisor : MonoBehaviour
{
    #if UNITY_EDITOR
    public static Camera mainCam;

    private void Start() 
    {
        mainCam = Camera.main;
        InitializeMainCamPosition();
    }
    public static void InitializeMainCamPosition()
    {
        //Begin set to a strict position, quite hard coded and would I would like to to be replaced, will replace if I get the time later on 
        mainCam.transform.position = new Vector3(2.5f,8.5f,-7.5f);
        mainCam.transform.rotation = Quaternion.Euler(45f,mainCam.transform.eulerAngles.y,mainCam.transform.eulerAngles.z);
    }
    #endif
}

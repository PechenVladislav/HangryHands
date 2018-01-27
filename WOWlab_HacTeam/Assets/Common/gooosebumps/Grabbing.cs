
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Grabbing : MonoBehaviour
{

    public void OnTriggerStay(Collider other)
    {
        if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerDown())
        {
            transform.parent = other.transform.parent;
        }
    }
}
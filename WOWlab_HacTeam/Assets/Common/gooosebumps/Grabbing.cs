
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grabbing : MonoBehaviour
{

    public GameObject Banana;

    public void Catch(Transform newParent)
    //public void OnTriggerStay(Collider other)
    {
        Banana.transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}


// if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerDown())
// схватить по нажатию на кнопку как-то так
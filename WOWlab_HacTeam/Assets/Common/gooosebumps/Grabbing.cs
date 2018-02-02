
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grabbing : MonoBehaviour
{
	[SerializeField]
	Collider col;
    public void Catch(HandController newParent)
    //public void OnTriggerStay(Collider other)
    {
		transform.SetParent(newParent.ActualHand.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
		newParent.AnimationGrab (true);
		AudioManager.Instance.PlayOneShot (AudioManager.Instance.CatchBanan);
    }

	public void Ate()
	{
		gameObject.SetActive (false);
		col.enabled = false;
		AudioManager.Instance.PlayOneShot (AudioManager.Instance.EatingBanan);
	}

}


// if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerDown())
// схватить по нажатию на кнопку как-то так
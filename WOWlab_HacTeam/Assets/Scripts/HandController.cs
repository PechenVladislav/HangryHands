using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

    [SerializeField]
    Transform ControllerTransform;
    [SerializeField]
    HandLogic HandLogic;
    [SerializeField]
    Rigidbody Rigidbody;
    [SerializeField]
    float Speed;
    [SerializeField]
    Transform snapFoodPoint;
    [SerializeField]
    Transform handPositionOnController;
	[SerializeField]
	float maxDistance;

    public bool MoveBack { get; private set; }

    // Use this for initialization
    void Start()
    {
        throwHand = false;
        MoveBack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (throwHand)
        {
			if (transform.parent != null)
				transform.parent = null;
			transform.position += transform.forward * Speed * Time.deltaTime;
			transform.forward = ControllerTransform.forward;

			if ((transform.position - ControllerTransform.position).magnitude > maxDistance)
				StartCoroutine(MoveBackCoroutine());
        }
        else if (MoveBack)
        {
            MoveBack = false;
            StartCoroutine(MoveBackCoroutine());
        }
    }
    bool throwHand;


	void Update()
	{
		if (SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex (SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerUp ())
			Thorw ();
	}


    IEnumerator MoveBackCoroutine()
    {
        Vector3 startPos = transform.position;
        float dist = (transform.position - ControllerTransform.position).magnitude;
        float speed = 10;
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / dist * speed;
            transform.position = Vector3.Lerp(startPos, ControllerTransform.position, t);
            yield return null;
        }
		throwHand = false;
        transform.position = handPositionOnController.position;
		transform.parent = handPositionOnController.transform.parent;
    }


    public void Thorw()
    {
        throwHand = true;
    }

    public void OnTriggerStay(Collider other)
    {
		if (other.GetComponent<Grabbing>() && SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex (SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerDown ())
        {
			other.GetComponent<Grabbing>().Catch(snapFoodPoint);
            MoveBack = true;
            throwHand = false;
        }
    }
}
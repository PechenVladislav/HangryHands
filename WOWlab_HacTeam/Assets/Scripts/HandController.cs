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
    Animator Anim;
    [SerializeField]
    float Speed;
	[Space(22)]
    [SerializeField]
    Transform snapFoodPoint;
    [SerializeField]
    Transform handPositionOnController;
	[SerializeField]
	float maxDistance;
	[SerializeField]
	float SpehereRadius = 0.3f;
	[SerializeField]
	public GameObject ActualHand;


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


    IEnumerator MoveBackCoroutine()
    {
		throwHand = false;
		Physics.gravity = new Vector3 (0, -1, 0);
        Vector3 startPos = transform.position;
        float dist = (transform.position - ControllerTransform.position).magnitude;
		float t = 0f;
        float speed = 10;
        while (t <= 1f)
        {
            t += Time.deltaTime / dist * speed;
            transform.position = Vector3.Lerp(startPos, ControllerTransform.position, t);
            yield return null;
        }
        transform.position = handPositionOnController.position;
		transform.parent = handPositionOnController.transform.parent;
    }


	void Update()
	{
		if (SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex (SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerDown () && throwHand)
		{
			print (1232321323);
			Collider[] colliders = Physics.OverlapSphere (transform.position, SpehereRadius);
			foreach (var col in colliders) {
				Grabbing banana = col.GetComponent<Grabbing> ();
				if (banana != null) {
					bananaLoc = banana;

					banana.Catch (this);
					bananaInHand = true;
					break;
				}
			}

			MoveBack = true;
		}
	}
	bool bananaInHand;
	Grabbing bananaLoc;


    public void Thorw()
    {
		if (!bananaInHand) {
			Physics.gravity = new Vector3 (0, 3, 0);
			throwHand = true;
		}
    }


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Head" && bananaInHand && bananaLoc != null) {
			bananaInHand = false;
			Anim.SetBool ("TakeBanana", bananaInHand);
			bananaLoc.Ate ();
		}
	}
		

	public void AnimationGrab(bool grab)
	{
		Anim.SetBool ("TakeBanana", grab);
	}

}
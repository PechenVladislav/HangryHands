using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HandStates { NotREadyToShoot, ReadyToShoot }

public class HandLogic : MonoBehaviour {



    //
    // hands
    // 
	[SerializeField] GameObject leftHand;
	[SerializeField] GameObject rightHand;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }


	[SerializeField] Text testText1;
	[SerializeField] Text testText2;
	[SerializeField] Text testText3;
	[SerializeField] Text testText4;

    private GameObject sphere;
    

	private Vector3 posLeftHand;
	private Vector3 posRightHand;

	private Vector3 lastPosLeftHand;
	private float biggerDistance;

	private float biggerSpeed = 0f;

    private bool IsPressed;

    private bool IsWaitingToShoot;

    public float CurrentSpeed { get; private set; }

    public HandStates handState;

	private void Awake()
	{
        // pos of left hand
		posLeftHand = leftHand.transform.position;

        // pos of right hand
		posRightHand = rightHand.transform.position;

        // for get speed
        lastPosLeftHand = posLeftHand;

        // current nand state
        handState = HandStates.NotREadyToShoot;

        //test
        sphere = GameObject.Find("OurSphere");
        sphere.SetActive(false);

        // current hand
        trackedObj = leftHand.GetComponent<SteamVR_TrackedObject>();
	}

	private void FixedUpdate()
	{
        IsPressed = Controller.GetHairTriggerDown();

        if(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed && !IsWaitingToShoot)
        {
            StartCoroutine(WaitTimeToShoot());
        } else {
            if (IsWaitingToShoot) { StopCoroutine(WaitTimeToShoot()); }
            handState = HandStates.NotREadyToShoot;
        }

        if(handState == HandStates.ReadyToShoot && !IsPressed)
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        sphere.SetActive(true);
    }

    private IEnumerator WaitTimeToShoot()
    {
        IsWaitingToShoot = true;
        var startTime = Time.realtimeSinceStartup;
        var endTime = startTime + GameManager.Instance.minTimeShoot;
        while(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed && Time.realtimeSinceStartup < endTime)
        {
            yield return new WaitForFixedUpdate();
        }
        handState = HandStates.ReadyToShoot;
        IsWaitingToShoot = false;
    }


    private void Update()
    {

        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }


        Tests();
    }



    private void Tests()
	{

        // text 1
		posLeftHand = leftHand.transform.position;
		posRightHand = rightHand.transform.position;
		var distance = Vector3.Distance (posLeftHand, posRightHand);
		testText1.text = "Distance btwn hands: " + distance;

        //text 2
        testText2.text = "Trigger : " + IsPressed;


        // text 3
		float currentDistance = Vector3.Distance (leftHand.transform.position, lastPosLeftHand);

		CurrentSpeed = currentDistance / Time.deltaTime;
		testText3.text = "current speed : " + CurrentSpeed;

		lastPosLeftHand = posLeftHand;

		if (CurrentSpeed > biggerSpeed) {
			biggerSpeed = CurrentSpeed;
			if (biggerSpeed > 100) {
				biggerSpeed = 0f;
			}
		}


        // text 4
		testText4.text = "bigger speed : " + biggerSpeed;
	}

    

    
}

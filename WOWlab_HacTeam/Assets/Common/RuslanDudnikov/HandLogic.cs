using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HandStates { NotREadyToShoot, ReadyToShoot }

public class HandLogic : MonoBehaviour {




	[SerializeField] GameObject leftHand;
	[SerializeField] GameObject rightHand;
    private SteamVR_Controller.Device controller;

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

    public float CurrentSpeed { get; private set; }

    public HandStates handState;

	private void Awake()
	{
		posLeftHand = leftHand.transform.position;
		posRightHand = rightHand.transform.position;
		lastPosLeftHand = Vector3.zero;
        handState = HandStates.NotREadyToShoot;
        sphere = GameObject.Find("OurSphere");
        sphere.SetActive(false);
	}

	private void FixedUpdate()
	{
        IsPressed = controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);

        if(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed)
        {
            StartCoroutine(WaitTimeToShoot());
        } else {
            StopCoroutine(WaitTimeToShoot());
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
        var startTime = Time.realtimeSinceStartup;
        var endTime = startTime + GameManager.Instance.minTimeShoot;
        while(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed && Time.realtimeSinceStartup < endTime)
        {
            yield return new WaitForFixedUpdate();
        }
        handState = HandStates.ReadyToShoot;
    }


    private void Update()
    {
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

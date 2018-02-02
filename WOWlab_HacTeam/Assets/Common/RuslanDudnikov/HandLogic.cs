using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HandStates { NotREadyToShoot, ReadyToShoot }

public class HandLogic : MonoBehaviour
{



    //
    // hands
    // 
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;
	[SerializeField] HandController handController;

    //private SteamVR_TrackedObject trackedObj;

    //private SteamVR_Controller.Device Controller
    //{
    //    get { return SteamVR_Controller.Input(14); }
    //}



    //
    // For Tests
    //
	[Space(30)]
    [SerializeField] Text testText1;
    [SerializeField] Text testText2;
    [SerializeField] Text testText3;
    [SerializeField] Text testText4;

    private GameObject sphere;


    private Vector3 posLeftHand;
    private Vector3 posRightHand;

    private Vector3 lastPosRightHand;
    private float biggerDistance;

    private float biggerSpeed = 0f;

    //
    // End block for test
    //
    private bool IsPressed;

    // IsCountingTime Coroutine working ? 
    private bool IsCountingTime;

    public float CurrentSpeed { get; private set; }

    public HandStates handState;

    private void Awake()
    {
        // pos of left hand
        posLeftHand = leftHand.transform.position;

        // pos of right hand
        posRightHand = rightHand.transform.position;

        // for get speed
		lastPosRightHand = posRightHand;

        // current nand state
        handState = HandStates.NotREadyToShoot;



        // current hand
        //trackedObj = leftHand.GetComponent<SteamVR_TrackedObject>();
    }

    //private void FixedUpdate()
    //{

    //}

    private void Shoot()
    {
		handController.Thorw ();
    }

    //private IEnumerator CountingTime()
    //{
    //    IsCountingTime = true;

    //    float startingTime = 0f;

    //    while(true)
    //    {
    //        startingTime += Time.deltaTime;

    //        StartCoroutine(Vibrate((GameManager.Instance.minTimeShoot - startingTime) / 2f));

    //        if(startingTime >= GameManager.Instance.minTimeShoot)
    //        {
    //            handState = HandStates.ReadyToShoot;
    //        }
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //private IEnumerator Vibrate(float waitTime)
    //{
    //    if (waitTime <= 0f)
    //    {
    //        StartCoroutine(VibrateUntilUp());
    //    }
    //    else
    //    {
    //        SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(100);
    //        yield return new WaitForSecondsRealtime(waitTime);
    //        SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(100);
    //    }
    //}

    //private IEnumerator VibrateUntilUp()
    //{
    //    while(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed)
    //    {
    //        SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(50);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}


    private void VibrateHand(float currentTimeTrigger)
    {
        if(currentTimeTrigger >= GameManager.Instance.minTimeShoot)
        {
            currentTimeTrigger = GameManager.Instance.minTimeShoot;
        }
        ushort casted = (ushort) (currentTimeTrigger * 500f);
		testText1.text = casted.ToString();
		SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).TriggerHapticPulse(casted);
    }


    float timeCount;

    private void Update()
	{


		Tests ();


		// --------------------------------------

		if (IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed) {
			timeCount += Time.deltaTime;
			VibrateHand (timeCount);
			if (timeCount >= GameManager.Instance.minTimeShoot) {
				handState = HandStates.ReadyToShoot;

			}
		} else {
			handState = HandStates.NotREadyToShoot;
			timeCount = 0f;
		}

		// --------------------------------------


		if (SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex (SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerUp ()) {
			if (handState == HandStates.ReadyToShoot) {
				Shoot ();
			}
		}
		IsPressed = SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex (SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTrigger ();
	}
	Coroutine ReadyCoroutine;


		IEnumerator WaitForShoot()
		{
			handState = HandStates.ReadyToShoot;
			float t = 0f;
			while(t <= 1)
			{
				t += Time.deltaTime;
				yield return null;

			}
			ReadyCoroutine = null;
		}




        // --------------------------------------


        //if (IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed)
        //{
        //    if (!IsCountingTime) { StartCoroutine(CountingTime()); }
        //}
        //else
        //{
        //    if (IsCountingTime)
        //    {
        //        StopCoroutine(CountingTime());
        //        IsCountingTime = false;
        //        handState = HandStates.NotREadyToShoot;
        //        testText1.text = "Change at : " + CurrentSpeed + " | " + IsPressed;
        //    }
        //}




        //if (handState == HandStates.ReadyToShoot)
        //{
        //    //Debug.Log("ReadyToShot");
        //    if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp())
        //    {
        //        Shoot();
        //    }
        //    Debug.Log(SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp());
        //}

        //Debug.Log("CurrentState : " + handState);

    



    private void Tests()
    {

        // text 1
        posLeftHand = leftHand.transform.position;
        posRightHand = rightHand.transform.position;
        var distance = Vector3.Distance(posLeftHand, posRightHand);
        //testText1.text = "Distance btwn hands: " + distance;

        //text 2
        testText2.text = "Trigger : " + IsPressed;


        // text 3
        float currentDistance = Vector3.Distance(rightHand.transform.position, lastPosRightHand);

        CurrentSpeed = currentDistance / Time.deltaTime;
        testText3.text = "current speed : " + CurrentSpeed;

        lastPosRightHand = posLeftHand;

        if (CurrentSpeed > biggerSpeed)
        {
            biggerSpeed = CurrentSpeed;
            if (biggerSpeed > 100)
            {
                biggerSpeed = 0f;
            }
        }


        // text 4
        testText4.text = "currentState : " + handState;
    }

}


//=======
//﻿using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public enum HandStates { NotREadyToShoot, ReadyToShoot }
//
//public class HandLogic : MonoBehaviour
//{
//
//
//
//    //
//    // hands
//    // 
//    [SerializeField] GameObject leftHand;
//    [SerializeField] GameObject rightHand;
//
//    //private SteamVR_TrackedObject trackedObj;
//
//    //private SteamVR_Controller.Device Controller
//    //{
//    //    get { return SteamVR_Controller.Input(14); }
//    //}
//
//
//
//    //
//    // For Tests
//    //
//    [SerializeField] Text testText1;
//    [SerializeField] Text testText2;
//    [SerializeField] Text testText3;
//    [SerializeField] Text testText4;
//
//    private GameObject sphere;
//
//
//    private Vector3 posLeftHand;
//    private Vector3 posRightHand;
//
//    private Vector3 lastPosLeftHand;
//    private float biggerDistance;
//
//    private float biggerSpeed = 0f;
//
//    //
//    // End block for test
//    //
//    private bool IsPressed;
//
//    // IsCountingTime Coroutine working ? 
//    private bool IsCountingTime;
//
//    public float CurrentSpeed { get; private set; }
//
//    public HandStates handState;
//
//    private void Awake()
//    {
//        // pos of left hand
//        posLeftHand = leftHand.transform.position;
//
//        // pos of right hand
//        posRightHand = rightHand.transform.position;
//
//        // for get speed
//        lastPosLeftHand = posLeftHand;
//
//        // current nand state
//        handState = HandStates.NotREadyToShoot;
//
//        //test
//        sphere = GameObject.Find("OurSphere");
//        sphere.SetActive(false);
//
//        // current hand
//        //trackedObj = leftHand.GetComponent<SteamVR_TrackedObject>();
//    }
//
//    //private void FixedUpdate()
//    //{
//
//    //}
//
//    private void Shoot()
//    {
//        sphere.SetActive(true);
//        Debug.Log("Shoot");
//    }
//
//    private IEnumerator CountingTime()
//    {
//        IsCountingTime = true;
//
//        float startingTime = 0f;
//
//        while(true)
//        {
//            startingTime += Time.deltaTime;
//
//            StartCoroutine(Vibrate((GameManager.Instance.minTimeShoot - startingTime) / 2f));
//
//            if(startingTime >= GameManager.Instance.minTimeShoot)
//            {
//                handState = HandStates.ReadyToShoot;
//            }
//            yield return new WaitForEndOfFrame();
//        }
//    }
//
//    private IEnumerator Vibrate(float waitTime)
//    {
//        if (waitTime <= 0f)
//        {
//            StartCoroutine(VibrateUntilUp());
//        }
//        else
//        {
//            SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(100);
//            yield return new WaitForSecondsRealtime(waitTime);
//            SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(100);
//        }
//    }
//
//    private IEnumerator VibrateUntilUp()
//    {
//        while(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed)
//        {
//            SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(500);
//            yield return new WaitForEndOfFrame();
//        }
//    }
//
//
//    private void Update()
//    {
//
//
//        Tests();
//
//        IsPressed = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTrigger();
//
//
//        if (IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed)
//        {
//            if (!IsCountingTime) { StartCoroutine(CountingTime()); }
//        }
//        else
//        {
//			if (IsCountingTime) {
//				StopCoroutine (CountingTime ());
//				IsCountingTime = false;
//				handState = HandStates.NotREadyToShoot;
//				testText1.text = "Change at : " + CurrentSpeed + " | " + IsPressed;
//			} else {
//				handState = HandStates.NotREadyToShoot;
//			}
//        }
//
//
//
//
//        if (handState == HandStates.ReadyToShoot)
//        {
//            //Debug.Log("ReadyToShot");
//            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp())
//            {
//				if (CurrentSpeed >= GameManager.Instance.minSpeed) {
//					Shoot ();
//				} else {
//					handState = HandStates.NotREadyToShoot;
//				}
//            }
//            //Debug.Log(SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp());
//        }
//
//        //Debug.Log("CurrentState : " + handState);
//
//    }
//
//
//
//    private void Tests()
//    {
//
//        // text 1
//        posLeftHand = leftHand.transform.position;
//        posRightHand = rightHand.transform.position;
//        var distance = Vector3.Distance(posLeftHand, posRightHand);
//        //testText1.text = "Distance btwn hands: " + distance;
//
//        //text 2
//        testText2.text = "Trigger : " + IsPressed;
//
//
//        // text 3
//        float currentDistance = Vector3.Distance(leftHand.transform.position, lastPosLeftHand);
//
//        CurrentSpeed = currentDistance / Time.deltaTime;
//        testText3.text = "current speed : " + CurrentSpeed;
//
//        lastPosLeftHand = posLeftHand;
//
//        if (CurrentSpeed > biggerSpeed)
//        {
//            biggerSpeed = CurrentSpeed;
//            if (biggerSpeed > 100)
//            {
//                biggerSpeed = 0f;
//            }
//        }
//
//
//        // text 4
//		testText4.text = "current state : " + handState;
//    }
//
//
//
//
//>>>>>>> Ruslans-branch
//}
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

    //private SteamVR_TrackedObject trackedObj;

    //private SteamVR_Controller.Device Controller
    //{
    //    get { return SteamVR_Controller.Input(14); }
    //}



    //
    // For Tests
    //
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

    //
    // End block for test
    //
    private bool IsPressed;

    // IsCountingTime ? 
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
        lastPosLeftHand = posLeftHand;

        // current nand state
        handState = HandStates.NotREadyToShoot;

        //test
        sphere = GameObject.Find("OurSphere");
        sphere.SetActive(false);

        // current hand
        //trackedObj = leftHand.GetComponent<SteamVR_TrackedObject>();
    }

    private void FixedUpdate()
    {

        if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTrigger())
        {
            IsPressed = true;
        }
        else
        {
            IsPressed = false;
        }
        //IsPressed = SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex (SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerDown ();

        if(IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed)
        {
            if (!IsCountingTime) { StartCoroutine(CountingTime()); }
        } else
        {
            if(IsCountingTime)
            {
                StopCoroutine(CountingTime());
                IsCountingTime = false;
                handState = HandStates.NotREadyToShoot;
            }
        }

        if(handState == HandStates.ReadyToShoot)
        {
            Debug.Log("ReadyToShot");
            if(SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp())
            {
                Shoot();
            }
        }


        //if (IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed && !IsCountingTime)
        //{
        //    StartCoroutine(WaitTimeToShoot());
        //}
        //else
        //{
        //    if (IsCountingTime) { StopCoroutine(WaitTimeToShoot()); }
        //    handState = HandStates.NotREadyToShoot;
        //}

        //if (handState == HandStates.ReadyToShoot && !IsPressed)
        //{
        //    Shoot();
        //}
    }

    private void Shoot()
    {
        sphere.SetActive(true);
        Debug.Log("Shoot");
    }

    private IEnumerator CountingTime()
    {
        float testTime = Time.realtimeSinceStartup;
        IsCountingTime = true;
        float startingTime = 0f;
        while(true)
        {
            startingTime += Time.deltaTime;
            if(startingTime >= GameManager.Instance.minTimeShoot)
            {
                handState = HandStates.ReadyToShoot;
                Debug.Log(Time.realtimeSinceStartup - testTime);
            }
            yield return new WaitForFixedUpdate();
        }

        //IsCountingTime = false;


        //IsCountingTime = true;
        //var startTime = Time.realtimeSinceStartup;
        //var endTime = startTime + GameManager.Instance.minTimeShoot;
        //Debug.Log("Start at : " + startTime);
        //Debug.Log("End at : " + endTime);
        //while (IsPressed && CurrentSpeed >= GameManager.Instance.minSpeed && Time.realtimeSinceStartup < endTime)
        //{
        //    Debug.Log("Counting");
        //    yield return new WaitForFixedUpdate();
        //}
        //Debug.Log("Counting end");
        //handState = HandStates.ReadyToShoot;
        //IsCountingTime = false;
    }


    private void Update()
    {

        //Debug.Log("CurrentState : " + handState);

        Tests();
    }



    private void Tests()
    {

        // text 1
        posLeftHand = leftHand.transform.position;
        posRightHand = rightHand.transform.position;
        var distance = Vector3.Distance(posLeftHand, posRightHand);
        testText1.text = "Distance btwn hands: " + distance;

        //text 2
        testText2.text = "Trigger : " + IsPressed;


        // text 3
        float currentDistance = Vector3.Distance(leftHand.transform.position, lastPosLeftHand);

        CurrentSpeed = currentDistance / Time.deltaTime;
        testText3.text = "current speed : " + CurrentSpeed;

        lastPosLeftHand = posLeftHand;

        if (CurrentSpeed > biggerSpeed)
        {
            biggerSpeed = CurrentSpeed;
            if (biggerSpeed > 100)
            {
                biggerSpeed = 0f;
            }
        }


        // text 4
        testText4.text = "bigger speed : " + biggerSpeed;
    }




}
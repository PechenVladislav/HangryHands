using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandLogic : MonoBehaviour {


	[SerializeField] GameObject leftHand;
	[SerializeField] GameObject rightHand;

	[SerializeField] Text testText1;
	[SerializeField] Text testText2;
	[SerializeField] Text testText3;
	[SerializeField] Text testText4;

	private Vector3 posLeftHand;
	private Vector3 posRightHand;

	private Vector3 lastPosLeftHand;
	private float biggerDistance;

	private float biggerSpeed = 0f;

	private void Awake()
	{
		posLeftHand = leftHand.transform.position;
		posRightHand = rightHand.transform.position;
		lastPosLeftHand = Vector3.zero;
	}

	private void FixedUpdate()
	{



			
	}


	private void Tests()
	{
		posLeftHand = leftHand.transform.position;
		posRightHand = rightHand.transform.position;
		var distance = Vector3.Distance (posLeftHand, posRightHand);
		testText1.text = "Distance btwn hands: " + distance;


		float currentDistance = Vector3.Distance (leftHand.transform.position, lastPosLeftHand);
		if (currentDistance > biggerDistance) {
			biggerDistance = currentDistance;
		}
		testText2.text = "bigger : " + biggerDistance;

		var currentSpeed = currentDistance / Time.deltaTime;
		testText3.text = "current speed : " + currentSpeed;

		lastPosLeftHand = posLeftHand;



		if (currentSpeed > biggerSpeed) {
			biggerSpeed = currentSpeed;
			if (biggerSpeed > 100) {
				biggerSpeed = 0f;
			}
		}

		testText4.text = "bigger speed : " + biggerSpeed;
	}

    

    
}

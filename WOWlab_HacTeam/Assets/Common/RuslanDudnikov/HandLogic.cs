using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandLogic : MonoBehaviour {

    [SerializeField] private float speedToShoot = 1.0f;

    [SerializeField] Text testText1;
    [SerializeField] Text testText2;

    public float CurrentSpeedOfHandByVector { get; private set; }
    public float CurrentSpeedOfHandByVelocity { get; private set; }

    private Vector3 currentPosition;
    private Vector3 lastPosition;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = gameObject.transform.position;
        lastPosition = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        currentPosition = gameObject.transform.position;
        CurrentSpeedOfHandByVector = GetControllerSpeedByVector();
        CurrentSpeedOfHandByVelocity = GetControllerSpeedByVelocity();
    }

    private void LateUpdate()
    {
        lastPosition = gameObject.transform.position;
    }

    private float GetControllerSpeedByVector()
    {
        return Vector3.Distance(lastPosition, currentPosition) / Time.deltaTime;
    }

    private float GetControllerSpeedByVelocity()
    {
        return rb.velocity.magnitude;
    }

    private void Update()
    {
        testText1.text = "Speed by Vector3 : " + CurrentSpeedOfHandByVector;
        testText2.text = "Speed by velosity : " + CurrentSpeedOfHandByVelocity;
    }
}

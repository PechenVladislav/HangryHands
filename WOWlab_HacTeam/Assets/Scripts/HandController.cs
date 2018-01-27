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
            Rigidbody.velocity = ControllerTransform.up * Speed;
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
        Vector3 startPos = transform.position;
        float dist = (transform.position - ControllerTransform.position).magnitude;
        float speed = 4;
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / dist * speed;
            transform.position = Vector3.Lerp(startPos, ControllerTransform.position, t);
            yield return null;
        }

        transform.position = handPositionOnController.position;
    }


    public void Thorw()
    {
        throwHand = true;
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.GetComponent<Grabbing>())//&& HandLogic.Squeeze
        //{
        //    Grabbing food = other.GetComponent<Grabbing>().Catch(snapPoint);
        //    MoveBack = true;
        //    throwHand = false;
        //    yield return null;
        //}
    }
}
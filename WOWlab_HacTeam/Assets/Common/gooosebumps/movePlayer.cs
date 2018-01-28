using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

    public static int movespeed = 5;
    public GameObject movingObj;
    public Vector3 userDirection = Vector3.right;
    //public List<GameObject> trail = new List<GameObject>();
    //public GameObject trailObject = null;
    //public Transform currentPosition;




    public void Start()
    {
        //trailObject = Instantiate(Resources.Load("Prefabs/Cube")) as GameObject;
        // currentPosition = transform.
    }

    public void Update()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime);


        //GameObject t = new GameObject("trailObject");
        //trail.Add(Instantiate(t));
        // Instantiate(trailObject);

    }
}

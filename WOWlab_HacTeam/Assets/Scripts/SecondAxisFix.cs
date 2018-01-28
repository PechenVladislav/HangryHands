using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAxisFix : MonoBehaviour {

    [SerializeField]
    Transform Target;

    // Update is called once per frame
    void Update () {
        transform.LookAt(Target, Vector3.up);
    }
}

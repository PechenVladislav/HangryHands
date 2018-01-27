using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotationFix : MonoBehaviour {

    [SerializeField]
    Transform Target;

    private void Update()
    {
        transform.rotation = Target.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPos : MonoBehaviour {

	[SerializeField]
	Transform Target;
	[SerializeField]
	float Speed;

	// Use this for initialization
	void Update () {
		transform.position = Vector3.Lerp (transform.position, Target.position, Speed * Time.deltaTime); 
	}
}

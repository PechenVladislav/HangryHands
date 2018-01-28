using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRot : MonoBehaviour {

	[SerializeField]
	Transform Target;
	[SerializeField]
	float Speed;

	// Use this for initialization
	void Update () {
		transform.rotation = Quaternion.Lerp (transform.rotation, Target.rotation, Speed * Time.deltaTime);
	}
}

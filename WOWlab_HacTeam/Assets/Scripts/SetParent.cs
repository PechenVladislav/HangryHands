using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour {

	[SerializeField]
	Transform Transform;
	[SerializeField]
	Transform Target;
	[SerializeField]
	Vector3 TargetLocalPosition;
	[SerializeField]
	Vector3 TargetRotation;

	// Use this for initialization
	IEnumerator Start () {
		int counter = 0;
		while (counter < 4) {
			counter++;
			yield return null;
		}
		Transform.parent = Target.transform;
		Transform.localPosition = TargetLocalPosition;
		Transform.localEulerAngles = TargetRotation;
	}
}

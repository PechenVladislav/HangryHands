using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour {

	[SerializeField]
	MeshFilter Filter;

	// Use this for initialization
	void Start () {
		Bounds bounds = Filter.mesh.bounds;//
		bounds = new Bounds(Filter.mesh.bounds.center, Filter.mesh.bounds.size * 100f);
		Filter.mesh.bounds = bounds;
	}
}

using UnityEngine;
using System.Collections;

public class RotationLock : MonoBehaviour {

	Quaternion prevRotation;

	// Use this for initialization
	void Start () {
		prevRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftShift)) {
			transform.rotation = prevRotation;
		}

		prevRotation = transform.rotation;
	}
}

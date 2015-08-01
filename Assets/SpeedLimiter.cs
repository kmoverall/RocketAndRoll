using UnityEngine;
using System.Collections;

public class SpeedLimiter : MonoBehaviour {

	float speedLimit;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	void OnDrawGizmos() {
		Gizmos.DrawLine(transform.position, transform.position + (Vector3)(body.velocity));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}

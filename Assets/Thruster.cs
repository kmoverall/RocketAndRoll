using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

	public Rigidbody2D thrustBase;
	public float thrustForce;
	public KeyCode thrustButton;
	public ParticleSystem jet;
	public float totalSecondsOfFuel;
	public float fuelRefillDelay;	//Time between turning off the thrusters and beginning of refueling in seconds
	public float fuelRefillRate;	//% of fuel that refills per second

	float fuelRemaining;
	float timeUntilRefuel;
	Vector2 forceVector;

	// Use this for initialization
	void Start () {
		forceVector = new Vector2();
		fuelRemaining = totalSecondsOfFuel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			if (Input.GetKey(thrustButton) && fuelRemaining > 0) {
				jet.Play();
					
				//Thrust in direction of thruster
				forceVector.x = Mathf.Cos(transform.eulerAngles.z * (Mathf.PI / 180)) * thrustForce;
				forceVector.y = Mathf.Sin(transform.eulerAngles.z * (Mathf.PI / 180)) * thrustForce;
				thrustBase.AddForceAtPosition(forceVector, transform.position);
					
				//Reduce fuel and check if it is empty
				fuelRemaining -= Time.fixedDeltaTime;
				if (fuelRemaining <= 0) {
					fuelRemaining = 0;
					timeUntilRefuel = fuelRefillDelay;
				}
			}
			else {
				//Turn off particles if thruster is off
				jet.Stop();
				
				//Begin delay for refueling and countdown until refuel
				if (Input.GetKeyUp(thrustButton)) {
					timeUntilRefuel = fuelRefillDelay;
				}
				else {
					timeUntilRefuel -= Time.fixedDeltaTime;
					if (timeUntilRefuel <= 0) {
						timeUntilRefuel = 0;
					}
				}

				if (timeUntilRefuel <= 0) {
					fuelRemaining += fuelRefillRate * totalSecondsOfFuel * Time.fixedDeltaTime;
				}

				if (fuelRemaining >= totalSecondsOfFuel) {
					fuelRemaining = totalSecondsOfFuel;
				}
			}
	}
}

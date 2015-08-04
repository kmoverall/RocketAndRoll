using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class DeathZone : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D coll) {
		//Quick and simple: Restart the game on death
		Application.LoadLevel(0);
	}
}

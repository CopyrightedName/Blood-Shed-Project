using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour {

	public Rigidbody playerRB;
	public Slider staminaSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerRB.velocity.magnitude >= 1) {
			staminaSlider.value -= 1;
		} else {
			staminaSlider.value += 1;
		}
	}
}

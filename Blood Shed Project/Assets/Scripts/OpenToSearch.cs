using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenToSearch : MonoBehaviour {

	public Animation vanAnim;
	public bool canOpen;
	public GameObject helpText;
	// Use this for initialization
	void Start () {
		helpText.SetActive (false);
	}
	
	// Update is called once per frame
	void FixeUpdate () 
	{
		if (canOpen = true) {
			helpText.SetActive (true);
		}
		if (canOpen = false) {
			helpText.SetActive (false);
		}
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)&& canOpen) {
			vanAnim.Play ("OpenVanDoor");
		}

	}
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.transform.tag.Equals ("Player")) {
			canOpen = true;
		}
	}
	void OnTriggerExit (Collider col) {
		if (col.gameObject.transform.tag.Equals ("Player")) {
			canOpen = false;
		}
	}
}

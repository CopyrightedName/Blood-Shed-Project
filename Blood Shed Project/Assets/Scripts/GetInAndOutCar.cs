﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class GetInAndOutCar : MonoBehaviour {

	public GameObject Player;
	public GameObject PlayerCam;
	public Rigidbody carRb;
	public Behaviour[] scriptsToDissableWhenEntering;
	public Behaviour[] playerBeh;
	public bool CanEnter;
	public bool Entered;
	public Transform placeToCreate;
	public AudioSource[] allAudioSources;
	public string camTag;
	public GameObject camForCar;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < scriptsToDissableWhenEntering.Length; i++) {
			scriptsToDissableWhenEntering [i].enabled = false;
		}
		carRb.isKinematic = true;
		carRb.useGravity = false;

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
	}
	void Update () 
	{
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		Player = GameObject.FindGameObjectWithTag ("Player");
		if (Input.GetKeyDown (KeyCode.F)&& CanEnter == true) {
			PlayerCam.SetActive (false);
			camForCar.transform.gameObject.tag = camTag;
			for (int i = 0; i < playerBeh.Length; i++) {
				playerBeh [i].enabled = false;
			}
			carRb.isKinematic = false;
			carRb.useGravity = true;
			CanEnter = false;
			for (int i = 0; i < scriptsToDissableWhenEntering.Length; i++) {
				scriptsToDissableWhenEntering [i].enabled = true;
				Entered = true;
			}
			foreach( AudioSource audioS in allAudioSources) {
				audioS.Play();
			}
		}
		if (Input.GetKeyDown (KeyCode.E)&& CanEnter == false &&Entered) {
			camForCar.transform.gameObject.tag = "Untagged";
			PlayerCam.SetActive (true);
			CanEnter = false;
			for (int i = 0; i < playerBeh.Length; i++) {
				playerBeh [i].enabled = true;
			}
			Player.transform.position = placeToCreate.transform.position;
			for (int i = 0; i < scriptsToDissableWhenEntering.Length; i++) {
				scriptsToDissableWhenEntering [i].enabled = false;
			}
			carRb.isKinematic = true;
			carRb.useGravity = false;
			foreach( AudioSource audioS in allAudioSources) {
				audioS.Stop();
			}
		}
	}
	void OnTriggerEnter (Collider triga) {
		if (triga.gameObject.tag.Equals ("Player")) {
			CanEnter = true;
		}
	}
	void OnTriggerExit (Collider triga) {
		if (triga.gameObject.tag.Equals ("Player")) {
			CanEnter = false;
		}
	}
}


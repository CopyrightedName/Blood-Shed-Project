using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour {

	public Rigidbody shellrb;
	public float force;
	// Use this for initialization
	void Start () {
		shellrb.AddForce (transform.right * -force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

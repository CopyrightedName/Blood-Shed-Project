using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHole : MonoBehaviour {

	public GameObject bulletholeprefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collider col) {
		if (col.gameObject.transform.tag.Equals ("Enviroment")) {
			Instantiate (bulletholeprefab, gameObject.transform.position , Quaternion.identity);
		}
	}
}

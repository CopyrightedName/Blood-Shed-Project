using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSwing : MonoBehaviour {

	public Animation meleeAnims;

	public float animNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			animNum = Random.Range (0, 4);
		} else {
			animNum = 0;
		}


		if (animNum == 1) {
			meleeAnims.Play ("Swing1");
		}
		if (animNum == 2) {
			meleeAnims.Play ("Swing2");
		}
		if (animNum == 3) {
			meleeAnims.Play ("Swing3");
		}
	}
}

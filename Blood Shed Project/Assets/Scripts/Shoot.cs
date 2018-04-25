using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	//Variables
	public float bulletsLeft;
	public float bulletImpulse = 100.0f;
	public float reload;
	public float bulletCount = 30;
	public float reloadTimer = 0.1f;
	public float ShotTimer = 0.01f;
	public float bullet = 1.0f;
	public float timeToReloadPoint = 0.0f;
	public float audioVolume = 5.0f;
	public float nextFire = 0.0f;
	public bool canshoot;
	public Text ammotxt;

	//Game Objects
	public GameObject gun_prefab;
	public GameObject muzzle_flash;
	public GameObject bullet_prefab;

	//Audio
	public AudioClip shootSound;


	float theBullet;

	void Start () {
		bulletCount = bulletsLeft;
	}


	IEnumerator reloadIN () 
	{
		Debug.Log("Reload started");
		yield return new WaitForSeconds (reloadTimer);
		bulletsLeft += bulletCount;
		Debug.Log ("Reload ended");
	}

	void Update () {
		ammotxt.text = bulletsLeft + " / " + bulletCount;

		if (bulletsLeft <= 0) {
			canshoot = false;
		} else {
			canshoot = true;
		}

		if( Input.GetButton("Fire1") && Time.time > nextFire &&canshoot) {

			//Time
			nextFire = Time.time + ShotTimer;

			//Shooting Action
			GameObject theBullet = (GameObject)Instantiate(bullet_prefab, gun_prefab.transform.position, gun_prefab.transform.rotation);
			theBullet.GetComponent<Rigidbody>().AddForce( gun_prefab.transform.forward * bulletImpulse, ForceMode.Impulse);

			//M4 audio
			GetComponent<AudioSource>().PlayOneShot(shootSound , audioVolume );

			//M4 Muzzle Flash
			Instantiate(muzzle_flash, gun_prefab.transform.position, gun_prefab.transform.rotation);
			bulletsLeft -= 1;





		}
		if( Input.GetKeyDown(KeyCode.R)&& !canshoot) {
			StartCoroutine (reloadIN());

		}

		if(bulletsLeft != timeToReloadPoint ){
			print("Need To Reload");

		}
	}
}

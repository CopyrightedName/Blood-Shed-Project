using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletHole;
	public float delayTime = 0.5f;
	AudioSource audioSource;
	public AudioClip shoot;
	public Text ammotxt;
	public float maxammo;
	public float currammo;
	public Animation gunAnims;
	public bool canFire;
	public GameObject bulletshell;
	public Transform shellPoint;
	public GameObject muzzle;
	
	private float counter = 0;
	
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
	void Update () {
		if (currammo <= 0) {
			canFire = false;
		} else {
			canFire = true;
		}

		ammotxt.text = currammo.ToString() + " / " + maxammo.ToString();
	}
	IEnumerator reload () 
	{
		gunAnims.Play ("Reload");
		yield return new WaitForSeconds (1.9F);
		currammo += maxammo;

	}
	IEnumerator muzzlevoid () 
	{
		muzzle.SetActive (true);
		muzzle.transform.Rotate (0f,0f,7f);
		yield return new WaitForSeconds (0.5f);
		muzzle.SetActive (false);

	}

	void FixedUpdate ()	
 	{
		if (Input.GetKeyDown (KeyCode.R)&&!canFire) {
			StartCoroutine(reload());
		}
		if(Input.GetKey(KeyCode.Mouse0) && counter > delayTime && canFire)
		{
			StartCoroutine(muzzlevoid());
			Instantiate (bulletshell, shellPoint.transform.position, Quaternion.identity);
			currammo -= 1;
			Instantiate(bullet, transform.position, transform.rotation);
			audioSource.PlayOneShot (shoot, 0.25f);
			counter = 0;
			gunAnims.Play ("Shoot");
			RaycastHit hit;
			Ray ray = new Ray(transform.position, transform.forward);
			if(Physics.Raycast(ray, out hit, 100f))
			{
				Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}
		}
		counter += Time.deltaTime;
	}
}

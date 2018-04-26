using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletHole;
	public float delayTime = 0.5f;
	AudioSource audioSource;
	public AudioClip shoot;
	
	private float counter = 0;
	
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
	void FixedUpdate ()	
 	{
		if(Input.GetKey(KeyCode.Mouse0) && counter > delayTime)
		{
			Instantiate(bullet, transform.position, transform.rotation);
			audioSource.PlayOneShot (shoot, 0.25f);
			counter = 0;
			
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

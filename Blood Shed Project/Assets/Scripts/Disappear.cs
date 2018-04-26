using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

	public float time = 5f;
	private float a = 1f;
	
	void Update ()	
 	{
		if(time < 0)
		{
			if(a < 0)
			{
				Destroy(transform.parent.gameObject);
			}
			
		}
	}
}

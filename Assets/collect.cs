using UnityEngine;
using System.Collections;

public class collect : MonoBehaviour {
	public int value;
	public float rotatedspeed;

	// Update is called once per frame
	void Update () {
		
		gameObject.transform.Rotate(Vector3.up*Time.deltaTime* rotatedspeed);

	}

	void OnTriggerEnter(){
		
		gamemange.instance.Collect (value, gameObject);
		AudioSource source = GetComponent<AudioSource>();
		source.Play ();
	}


}

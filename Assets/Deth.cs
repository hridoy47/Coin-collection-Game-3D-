using UnityEngine;
using System.Collections;

public class Deth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter(Collision collision){
		if (collision.relativeVelocity.magnitude > 2)
			Death ();
	}

	private void Death(){
		Debug.Log ("death");
	}

	}

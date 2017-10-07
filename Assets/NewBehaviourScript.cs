using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	Rigidbody myRigidbody;
	public Vector3 com = new Vector3 (0, 0, 0);
	public WheelCollider[] wc;
	public GameObject wheelShape;
	public int wc_tq_len;
	public bool breakallowed;
	public float maxAngle = 30.0f;
	public float maxTorque = 3000.0f;
	public float m_break=10000.0f;
	private bool isDead = false;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.centerOfMass = com;
		wc = GetComponentsInChildren<WheelCollider>();

		for (int i = 0; i < wc.Length; ++i) 
		{
			var wheel = wc [i];

			// create wheel shapes only when needed
			if (wheelShape != null)
			{
				var ws = GameObject.Instantiate (wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}

	}

	void Update(){
		if (isDead)
			return;
		hanbreak ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (isDead)
			return;
		for (int i = 0; i < wc_tq_len; i++) {
			wc [i].motorTorque = maxTorque * Input.GetAxis ("Vertical");
		
		}

		wc [0].steerAngle = maxAngle * Input.GetAxis ("Horizontal");
		wc [1].steerAngle = maxAngle * Input.GetAxis ("Horizontal");

		foreach (WheelCollider wheel in wc) {
			// a simple car where front wheels steer while rear ones drive


			// update visual wheels if any
			if (wheelShape) {
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);

				// assume that the only child of the wheelcollider is the wheel shape
				Transform shapeTransform = wheel.transform.GetChild (0);
				shapeTransform.position = p;
				shapeTransform.rotation = q;
			}

		}
	}

		private void hanbreak(){
		if (Input.GetKey(KeyCode.Space)){
			breakallowed = true;
				
			}	
		else{
			breakallowed = false;

		}
		if (breakallowed) {
			for (int i = 0; i < wc_tq_len; i++) {
				wc [i].brakeTorque = m_break;
				wc [i].motorTorque = 0.0f;

			}
		} else if (!breakallowed && Input.GetButton ("Vertical") == true) {
			for (int i = 0; i < wc_tq_len; i++) {
				wc [i].brakeTorque =0.0f;


			}
		}
	
}
	public void OnCollisionEnter(Collision collision){
		if (collision.relativeVelocity.magnitude > 2) {
			Death ();

		}
	}

	private void Death()
	{
		isDead = true;
		GetComponent<gamemange> ().OnDeath ();

	}


}
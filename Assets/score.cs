using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
	private float Score=0.0f;
	public Text scoretext;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		Score += Time.deltaTime;
		scoretext.text = ((int)Score).ToString();
	
	}
}

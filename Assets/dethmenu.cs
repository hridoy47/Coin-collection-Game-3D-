using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class dethmenu : MonoBehaviour {
	public Text scoretext;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ToggleEndMenu (float score){
		gameObject.SetActive (true);
		scoretext.text=((int)score).ToString();
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		
	}
	public void ToMenu(){
		SceneManager.LoadScene ("Menu");
	}
}

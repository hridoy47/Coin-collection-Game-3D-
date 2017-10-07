using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gamemange : MonoBehaviour {
	private float Score=0.0f;
	public Text scoretext;
	private bool isDead = false;
	public dethmenu deathMenu;


	public static gamemange instance = null;

	void Update(){
		if (isDead)
			return;
	}
	void Awake(){
		
		
		if (instance == null) {
			instance = this;

		}
		else if(instance!=null)
			Destroy(gameObject);


		scoretext = scoretext.GetComponent<Text> ();
		scoretext.text=((int)Score).ToString();
	}
	public void Collect(int passvalue,GameObject passobject){
		if (isDead)
			return;
		
		passobject.GetComponent<Renderer> ().enabled = false;
		passobject.GetComponent<Collider> ().enabled = false;
		Destroy (passobject,.30f);

		Score += passvalue;
		scoretext.text=((int)Score).ToString();

	}

	public void OnDeath(){
		isDead = true;
		deathMenu.ToggleEndMenu (Score);
		
	}

}

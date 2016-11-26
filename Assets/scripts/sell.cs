using UnityEngine;
using System.Collections;

public class sell : MonoBehaviour {

	public GameObject tower;

	void OnMouseDown(){
		Destroy(tower.GetComponent<tower> ().r.gameObject);
		Destroy(tower.GetComponent<tower> ().b2.gameObject);
		Destroy(tower.GetComponent<tower> ().b3.gameObject);
		float value = Camera.main.GetComponent<main>().upgrades[tower.GetComponent<tower>().type + (tower.GetComponent<tower>().level).ToString()][4];
		Camera.main.GetComponent<main> ().playerCash += (int)value;
		Destroy (tower.gameObject);
		GameObject.FindGameObjectWithTag ("cancel").GetComponent<cancel>().hideButtons();
	}

	void OnMouseOver(){
		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
	}

	void OnMouseExit(){
		transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
	}
}

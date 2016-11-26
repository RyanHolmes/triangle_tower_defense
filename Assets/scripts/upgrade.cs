using UnityEngine;
using System.Collections;

public class upgrade : MonoBehaviour {

	public GameObject tower;

	void Update(){
		if (tower != null) {
			float costToUpgrade = Camera.main.GetComponent<main> ().upgrades [tower.GetComponent<tower> ().type + (tower.GetComponent<tower> ().level + 1).ToString ()] [0];
			if (costToUpgrade > Camera.main.GetComponent<main> ().playerCash) {
				this.GetComponent<Renderer> ().material.color = Color.red;
			} else {
				this.GetComponent<Renderer> ().material.color = Color.white;
			}
		}
	}

	void OnMouseDown(){
		float costToUpgrade = Camera.main.GetComponent<main>().upgrades[tower.GetComponent<tower>().type + (tower.GetComponent<tower>().level + 1).ToString()][0];
		if( costToUpgrade <= Camera.main.GetComponent<main>().playerCash){
			tower.GetComponent<tower>().upgrade();
			Camera.main.GetComponent<main> ().playerCash -= (int)costToUpgrade;
			Destroy(tower.GetComponent<tower> ().r.gameObject);
			GameObject.FindGameObjectWithTag ("cancel").GetComponent<cancel>().hideButtons();
		} else {
			GameObject.FindGameObjectWithTag ("cancel").GetComponent<cancel>().hideButtons();
		}
	}

	void OnMouseOver(){
		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
		//populate stats area
	}

	void OnMouseExit(){
		transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
		//unpopulate stats area
	}
}

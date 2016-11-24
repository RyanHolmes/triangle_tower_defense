using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameObject tower;
	public GameObject tower2;
	public GameObject tower3;
	public bool isUsed = false;

	void OnMouseOver(){
		if(Camera.main.GetComponent<main> ().bought == true){
			this.transform.localScale = new Vector3 (0.85f, 0.85f, 0.85f);
		}
	}

	void OnMouseExit(){
		if (Camera.main.GetComponent<main> ().bought == true) {
			this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		}
	}

	void OnMouseDown(){
		//place current tile, check if tower exists, reset current tower and bought
		Debug.Log("CLICK TILE");
		if (Camera.main.GetComponent<main> ().bought == true && isUsed == false) {
			if(Camera.main.GetComponent<main> ().currentTower == "slow"){
				this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
				GameObject t = (GameObject)Instantiate (tower2, new Vector3 (transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
				t.tag = "tower";
				t.GetComponent<tower> ().type = "slow";
				t.GetComponent<tower> ().cost = 25;
				t.GetComponent<tower> ().range = 3f;
				t.GetComponent<tower> ().fireRate = 2f;
				t.GetComponent<tower> ().damage = 20;
				isUsed = true;
				Camera.main.GetComponent<main> ().bought = false;
				Camera.main.GetComponent<main> ().currentTower = null;
			}
			if(Camera.main.GetComponent<main> ().currentTower == "standard"){
				this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
				GameObject t = (GameObject)Instantiate (tower, new Vector3 (transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
				t.tag = "tower";
				t.GetComponent<tower> ().type = "standard";
				t.GetComponent<tower> ().cost = 25;
				t.GetComponent<tower> ().range = 3f;
				t.GetComponent<tower> ().fireRate = 1f;
				t.GetComponent<tower> ().damage = 5;
				isUsed = true;
				Camera.main.GetComponent<main> ().bought = false;
				Camera.main.GetComponent<main> ().currentTower = null;
			}
			if(Camera.main.GetComponent<main> ().currentTower == "fast"){
				this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
				GameObject t = (GameObject)Instantiate (tower3, new Vector3 (transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
				t.tag = "tower";
				t.GetComponent<tower> ().type = "fast";
				t.GetComponent<tower> ().cost = 25;
				t.GetComponent<tower> ().range = 3f;
				t.GetComponent<tower> ().fireRate = 0.3f;
				t.GetComponent<tower> ().damage = 1;
				isUsed = true;
				Camera.main.GetComponent<main> ().bought = false;
				Camera.main.GetComponent<main> ().currentTower = null;
			}
		}
	}
}

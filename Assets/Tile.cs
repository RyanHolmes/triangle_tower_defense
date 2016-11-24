using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameObject tower;
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
		if (Camera.main.GetComponent<main> ().bought == true && isUsed == false) {
			this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			GameObject t = (GameObject)Instantiate (tower, new Vector3 (transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
			t.tag = "tower";
			isUsed = true;
			Camera.main.GetComponent<main> ().bought = false;
		}
	}
}

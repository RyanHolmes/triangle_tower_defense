using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buyButton : MonoBehaviour {

	public int cost;

	void Update(){
		if (cost > Camera.main.GetComponent<main> ().playerCash) {
			this.GetComponent<Button> ().interactable = false;
		} else {
			this.GetComponent<Button> ().interactable = true;
		}
	}
}

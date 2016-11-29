using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buyButton : MonoBehaviour {

	public int cost;
	public Text costUI;
	public Text rangeUI;
	public Text damageUI;
	public Text frUI;

	void Update(){
		if (cost > Camera.main.GetComponent<main> ().playerCash) {
			this.GetComponent<Button> ().interactable = false;
		} else {
			this.GetComponent<Button> ().interactable = true;
		}
	}

	public void OnMouseHover(){
		if (this.gameObject.name == "tower_slow") {
			costUI.text = "Cost: " +  "$" + cost;
			rangeUI.text = "Range: " + Camera.main.GetComponent<main> ().upgrades ["slow1"] [1];
			damageUI.text = "Damage: " + Camera.main.GetComponent<main> ().upgrades ["slow1"] [2];
			frUI.text = "Fire Rate: " + Camera.main.GetComponent<main> ().upgrades ["slow1"] [3];
		} else if (this.gameObject.name == "tower_fast") {
			costUI.text = "Cost: " +  "$" + cost;
			rangeUI.text = "Range: " + Camera.main.GetComponent<main> ().upgrades ["fast1"] [1];
			damageUI.text = "Damage: " + Camera.main.GetComponent<main> ().upgrades ["fast1"] [2];
			frUI.text = "Fire Rate: " + Camera.main.GetComponent<main> ().upgrades ["fast1"] [3];
		} else if (this.gameObject.name == "tower_standard") {
			costUI.text = "Cost: " + "$" + cost;
			rangeUI.text = "Range: " + Camera.main.GetComponent<main> ().upgrades ["standard1"] [1];
			damageUI.text = "Damage: " + Camera.main.GetComponent<main> ().upgrades ["standard1"] [2];
			frUI.text = "Fire Rate: " + Camera.main.GetComponent<main> ().upgrades ["standard1"] [3];
		} else {
			Debug.Log ("UHOH");
		}
	}
}

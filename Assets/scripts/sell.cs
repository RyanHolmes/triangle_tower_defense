using UnityEngine;
using System.Collections;

public class sell : MonoBehaviour {

	public GameObject tower;

	void OnMouseDown(){
		Destroy(tower.GetComponent<tower> ().r.gameObject);
		//TODO: add money to bank

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

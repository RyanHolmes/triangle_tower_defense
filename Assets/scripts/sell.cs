using UnityEngine;
using System.Collections;

public class sell : MonoBehaviour {

	public GameObject tower;

	void OnMouseDown(){
		tower.GetComponent<tower> ().r.SetActive (false);
		GameObject.FindGameObjectWithTag ("cancel").GetComponent<cancel>().hideButtons();
		Destroy (tower.gameObject);
	}

	void OnMouseOver(){
		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
	}

	void OnMouseExit(){
		transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
	}
}

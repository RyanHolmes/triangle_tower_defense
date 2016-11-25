using UnityEngine;
using System.Collections;

public class upgrade : MonoBehaviour {

	void OnMouseDown(){
		Debug.Log ("UPGRADE");
	}

	void OnMouseOver(){
		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
	}

	void OnMouseExit(){
		transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
	}
}

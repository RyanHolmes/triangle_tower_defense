using UnityEngine;
using System.Collections;

public class TileHover : MonoBehaviour {

	void OnMouseOver(){
		this.transform.localScale = new Vector3 (0.85f, 0.85f, 0.85f);
	}

	void OnMouseExit(){
		this.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
	}
}

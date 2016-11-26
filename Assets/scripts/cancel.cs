using UnityEngine;
using System.Collections;

public class cancel : MonoBehaviour {

	public GameObject tower;

	void OnMouseDown(){
		Destroy(tower.GetComponent<tower> ().r.gameObject);
		hideButtons ();
	}

	void OnMouseOver(){
		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
	}

	void OnMouseExit(){
		transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
	}

	public void hideButtons(){
		GameObject s = GameObject.FindGameObjectWithTag("sell");
		s.transform.position = new Vector3 (100, 100, 0);
		s.gameObject.GetComponent<sell> ().tower = null;

		GameObject u = GameObject.FindGameObjectWithTag("upgrade");
		u.transform.position = new Vector3 (100, 100, 0);
		u.gameObject.GetComponent<upgrade> ().tower = null;

		GameObject c = GameObject.FindGameObjectWithTag("cancel");
		c.transform.position = new Vector3 (100, 100, 0);
		c.gameObject.GetComponent<cancel> ().tower = null;
	}
}

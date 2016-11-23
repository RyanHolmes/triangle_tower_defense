using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour {

	public List<Vector3> markers;
	public int currentTarget = 1;
	public float speed = 10000000f;//TODO doesnt work at all

	// Use this for initialization
	void Start () {
		populateMarks ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = markers [currentTarget] - markers [currentTarget - 1];
		moveEnemy (dir);
	}

	void populateMarks(){
		GameObject[] marks = GameObject.FindGameObjectsWithTag ("mark");
		List<string> temp = new List<string> (); 
		for(int j = 0; j < marks.Length; j++){
			temp.Add (marks[j].name);
		}
		temp.Sort ();
		for(int i = 0; i < temp.Count; i++){
			for(int j = 0; j < marks.Length; j++){
				if(temp[i] == marks[j].name){
					markers.Add (marks[j].transform.position);
				}
			}
		}
	}

	public void moveEnemy(Vector3 dir){
		if (!(currentTarget < markers.Count - 1)) {
			Destroy (this.gameObject);
		}
		if (Vector3.Distance (transform.position, markers [currentTarget]) >= 0.1f) {
			transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
		} else {
			currentTarget += 1;
		}
	}
}

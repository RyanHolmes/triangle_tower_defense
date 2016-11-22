using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class main : MonoBehaviour {

	public GameObject enemy;
	public GameObject start;
	public GameObject e;
	public List<Vector3> markers;
	public int currentTarget = 0;
//	public float speed = 0.001f;

	// Use this for initialization
	void Start () {
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
		e = (GameObject)Instantiate (enemy, markers[0], Quaternion.identity);
//		Vector3 dir = markers [1] - markers [0];
//		e.transform.Translate (dir.normalized * Time.deltaTime * 10, Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		if(e.transform.position.y > markers[1].y){
			Vector3 dir = markers [1] - markers [0];
			e.transform.Translate (dir * Time.deltaTime, Space.World);
		} 
	}
}

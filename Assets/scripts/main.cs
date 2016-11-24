using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class main : MonoBehaviour {
	public int cash;
	public int playerHealth;
	public string currentTower;
	public bool bought = false;

	public List<Vector3> markers;
	public GameObject start;
	public GameObject enemy1;
	// x = enemy type, y = speed, z = health
	public Vector3[] wave0;
	public int currentWave = 0;
	public int currentEnemy = 0;
	public float spawnRate;
	public float currentTime;
	public List<Vector3[]> waves = new List<Vector3[]>();

	// Use this for initialization
	void Start () {
		populateMarks ();
		currentTime = 0f;
		spawnRate = 1f;
		wave0 = new Vector3[] { new Vector3(1, 4, 100), new Vector3(1, 1, 100) };
		waves.Add (wave0);
	}
	
	// Update is called once per frame
	void Update () { 
		if(currentEnemy >= wave0.Length){
			return;
		}
		if((Time.time - currentTime) >= spawnRate){
			spawnEnemy(wave0[currentEnemy]);
			currentTime = Time.time;
			currentEnemy++;
		}
	}

	void spawnEnemy(Vector3 en){
		// 1 = normal
		GameObject e;
		switch((int)en.x){
			case 1:
			e = (GameObject)Instantiate (enemy1, new Vector3(start.transform.position.x, start.transform.position.y, 0f), Quaternion.identity);
				e.name = "enemy" + currentEnemy.ToString();
				e.tag = "enemy";
				e.GetComponent<enemy> ().speed = en.y;
				e.GetComponent<enemy> ().health = en.z;
				break;
		}
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
}

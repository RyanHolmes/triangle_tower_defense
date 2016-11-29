using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class main : MonoBehaviour {
	public Text healthUI;
	public Text cashUI;
	public Text waveUI;

	public int playerCash;
	public int playerHealth;
	public string currentTower;
	public bool bought = false;
	public bool gameOver;

	public Transform standard_button;
	public Transform slow_button;
	public Transform fast_button;

	//ui
	public GameObject cancel;
	public GameObject sell;
	public GameObject upgrade;

	public List<Vector3> markers;
	public GameObject start;
	public bool gameStart;

	public GameObject boss;
	public GameObject enemy_standard;//1
	public GameObject enemy_slow;//2
	public GameObject enemy_fast;//3

	// x = enemy type, y = speed, z = health
	public List<Vector3[]> waves = new List<Vector3[]>();
	public Vector3[] wave0;
	public Vector3[] wave1;
	public Vector3[] wave2;
	public Vector3[] wave3;
	public Vector3[] wave4;
	public Vector3[] wave5;
	public int currentWave;
	public int currentEnemy;
	public float[] spawnRates;
	public float currentTime;
	public Dictionary<string, float[]> upgrades = new Dictionary<string, float[]>();

	// Use this for initialization
	void Start () {
		populateMarks ();
		currentTime = 0f;
		spawnRates = new float[]{ 1f, 0.9f, 1.2f};
		playerCash = 40;
		playerHealth = 20;
		gameOver = false;
		gameStart = false;
		currentWave = -1;
		currentEnemy = 0;

		//fast = 3 standard = 2, slow = 1
		wave0 = new Vector3[] { new Vector3(1, 2f, 50), new Vector3(1, 2f, 50), new Vector3(1, 2f, 50), new Vector3(1, 2f, 50), new Vector3(1, 2f, 50) };
		wave1 = new Vector3[] { new Vector3(1, 2f, 60), new Vector3(1, 2f, 60), new Vector3(1, 2f, 60), new Vector3(1, 2f, 60), new Vector3(1, 2f, 80), new Vector3(1, 2f, 80), new Vector3(1, 2f, 80) };
		wave2 = new Vector3[] { new Vector3 (3, 4f, 50), new Vector3 (3, 4f, 60), new Vector3 (3, 4f, 50), new Vector3 (3, 4f, 60), new Vector3 (3, 4f, 50), new Vector3 (3, 4f, 60), new Vector3 (3, 4f, 50), new Vector3 (3, 4f, 60), new Vector3 (3, 4f, 50), new Vector3 (3, 4f, 60) };
//		wave3 = new Vector3[] { };
//		wave4 = new Vector3[] { };
//		wave5 = new Vector3[] { };
		waves.Add (wave0);
		waves.Add (wave1);
		waves.Add (wave2);
		waves.Add (wave3);
		waves.Add (wave4);
		waves.Add (wave5);

		//ui
		GameObject c = (GameObject)Instantiate (cancel, new Vector3(100, -100, 0), Quaternion.identity);
		c.tag = "cancel";
		GameObject s = (GameObject)Instantiate (sell, new Vector3(100, -100, 0), Quaternion.identity);
		s.tag = "sell";
		GameObject u = (GameObject)Instantiate (upgrade, new Vector3(100, -100, 0), Quaternion.identity);
		u.tag = "upgrade";

		setButtonCost ();
		populateUpgrades ();

		InvokeRepeating ("resetBoxes", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () { 
		cashUI.text = "$" + playerCash.ToString ();
		if (gameStart) {
			healthUI.text = playerHealth.ToString ();
			waveUI.text = (currentWave + 1).ToString () + "/10";
			if (currentEnemy >= waves [currentWave].Length && !gameOver) {
				return;
			}
			if ((Time.time - currentTime) >= spawnRates[currentWave] && !gameOver) {
				spawnEnemy (waves [currentWave] [currentEnemy]);
				currentTime = Time.time;
				currentEnemy++;
			}
		}
	}

	void spawnEnemy(Vector3 en){
		// 1 = normal
		GameObject e;
		switch((int)en.x){
		case 1://standard
			e = (GameObject)Instantiate (enemy_standard, start.transform.position, Quaternion.identity);
			e.name = "enemy" + currentEnemy.ToString();
			e.tag = "enemy";
			e.GetComponent<enemy> ().speed = en.y;
			e.GetComponent<enemy> ().health = en.z;
			break;

		case 2://slow
			e = (GameObject)Instantiate (enemy_slow, start.transform.position, Quaternion.identity);
			e.name = "enemy" + currentEnemy.ToString();
			e.tag = "enemy";
			e.GetComponent<enemy> ().speed = en.y;
			e.GetComponent<enemy> ().health = en.z;
			break;

		case 3://fast
			e = (GameObject)Instantiate (enemy_fast, start.transform.position, Quaternion.identity);
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

	public void nextWave(){
		if(currentWave < waves.Count - 1) {
			currentEnemy = 0;
			currentWave++;
			currentTime = Time.time;
		} else {
			gameOver = true;
			return;
		}
	}

	void setButtonCost () {
		GameObject[] btns = GameObject.FindGameObjectsWithTag ("tower_button");
		foreach(GameObject b in btns){
			if (b.name == "tower_standard") {
				b.GetComponent<buyButton>().cost = 10;
			} else if (b.name == "tower_slow") {
				b.GetComponent<buyButton>().cost = 30;
			} else {
				b.GetComponent<buyButton>().cost = 15;
			}
		}
	}


	void populateUpgrades (){
		//tower.type + tower.level
		//cost, range, damage, speed, value(60%)
		upgrades["standard1"] = new float[5] { 10, 2.5f, 15, 1, 6 };
		upgrades["standard2"] = new float[5] { 12, 2.75f, 24, 0.9f, 12 };
		upgrades["standard3"] = new float[5] { 50, 3, 45, 0.7f, 42 };

		upgrades["slow1"] = new float[5] { 30, 3, 40, 3, 18 };
		upgrades["slow2"] = new float[5] { 35, 3.5f, 70, 3, 36 };
		upgrades["slow3"] = new float[5] { 100, 4.5f, 450, 2.5f, 96 };

		upgrades["fast1"] = new float[5] { 15, 2, 5, 0.5f, 9 };
		upgrades["fast2"] = new float[5] { 20, 2, 12, 0.4f, 21 };
		upgrades["fast3"] = new float[5] { 75, 2.5f, 36, 0.3f, 66 };
		//access
		//string i = upgrades["standard1"][0];
	}

	void resetBoxes(){
		GameObject[] towers = GameObject.FindGameObjectsWithTag ("tower");
		foreach(GameObject t in towers){
			t.GetComponent<BoxCollider2D> ().enabled = false;
			t.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}

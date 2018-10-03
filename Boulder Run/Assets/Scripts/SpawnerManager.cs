using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

	// Use this for initialization

	public GameObject spPre;

	GameObject [] spawners;
	GameObject insSpawners;

	GameObject activeSpawner;

	float xPos = 1.6f ;
	float yPos;
	float zPos =210f;

	bool left=true;

	float time;

	int check;
	int delay;
	int max;
	int range;

	void Start () {
	
		spawners = new GameObject[4];

		yPos = 5f;

		for (int spawnN = 0; spawnN <= 3; spawnN++) {

			insSpawners = Instantiate (spPre, new Vector3 (xPos, yPos, zPos), Quaternion.identity);
		    
				spawners[spawnN]=insSpawners;

			xPos=xPos*-1;

			if(left==true){

				left = false;

			}

			else if(left == false){

				yPos=yPos-1.5f;
				left=true;
			}
		}

		max = 8;

		Invoke ("spawnObstacle", 1f);
	}
	
	// Update is called once per frame
	void Update () {

		time = Time.time;
		check = (int)time;
	}

	void spawnObstacle(){
	
		range = Random.Range (0, 4);

		activeSpawner = spawners [range];
	
		activeSpawner.GetComponent<ObstacleSpawner> ().spawnObs ();

		delay = Random.Range (1, max);

		Invoke ("spawnObstacle", delay);

		if (check == 30) {
		
			Invoke("spawnObstacle", 1f);		
		
		}


		if (check == 10) {
		
			max--;
		
		}
	
		if (check == 20) {

			max--;

		}

		if (check == 30) {

			max--;

		}

		if (check == 40) {

			max--;

		}

		if (check == 50) {

			max--;

		}
	}

	public void stop(){

		CancelInvoke ();

	}
}

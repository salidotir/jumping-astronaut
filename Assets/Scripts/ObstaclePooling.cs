using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour {

	public int obstaclePoolSize = 5;
	public GameObject obstaclePrefab;

	public float spawnRate = 4f;
	public float obstacleMin = -1f;
	public float obstacleMax = 3.5f;

	private GameObject[] obstacles;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private float timeSincePreviousSpawn;
	private float spawnXPosition = 5f;
	private int currentObstacleIndex = 0;

	// Use this for initialization
	void Start () {
		obstacles = new GameObject[obstaclePoolSize];
		for (int i = 0; i < obstaclePoolSize; i++)
        {
			obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }
	}

	private float movingSpeed = 10f;
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime * movingSpeed;
		timeSincePreviousSpawn += Time.deltaTime;
		
		if (TapController.gameOver == false && timeSincePreviousSpawn >= spawnRate)
        {
			timeSincePreviousSpawn = 0;
			float spawnYPosition = Random.Range(obstacleMin, obstacleMax);

			// position the obstacle
			obstacles[currentObstacleIndex].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentObstacleIndex += 1;

			if (currentObstacleIndex >= obstaclePoolSize)
            {
				currentObstacleIndex = 0;
            }
        }
	}
}

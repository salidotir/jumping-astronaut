using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour {

	public static int obstaclePoolSize = 5;
	public GameObject obstaclePrefab;

	public float spawnRate = 4f;
	public float obstacleMin = -1f;
	public float obstacleMax = 2.5f;

	public static GameObject[] obstacles;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private float timeSincePreviousSpawn;
	private float spawnXPosition = 8f;
	private int currentObstacleIndex = 0;

	public static void DestroyObstacles()
    {
		for (int i = 0; i < obstaclePoolSize; i++)
		{
			Destroy(obstacles[i]);
		}
	}

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
		if (TapController.IsGameActive == true)
		{
			transform.position += Vector3.right * Time.deltaTime * movingSpeed;
			timeSincePreviousSpawn += Time.deltaTime;

			if (TapController.IsGameActive == true && timeSincePreviousSpawn >= spawnRate)
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 1f;

	[SerializeField]
	private float offset;

	private Vector2 startPosition;
	private float newXPosition;

//	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
//		rb2d = GetComponent<Rigidbody2D>();
//		rb2d.velocity = new Vector2(1.5f, 0f);

		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(TapController.gameOver == true)
        {
			// stop Update
			this.enabled = false;
			//rb2d.velocity = Vector2.zero;
        }

		newXPosition = Mathf.Repeat(Time.time * -moveSpeed, offset);

		transform.position = startPosition + Vector2.right * newXPosition;
	}
}

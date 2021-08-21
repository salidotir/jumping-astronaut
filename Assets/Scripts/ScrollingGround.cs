using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingGround : MonoBehaviour
{

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(-1.5f, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		if (TapController.gameOver == true)
		{
			// stop Update
			rb2d.velocity = Vector2.zero;

		}
	}
}
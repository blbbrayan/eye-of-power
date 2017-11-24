using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour {

	public float speed = 3;
	public float duration = 5;
	public float growX = 0;
	public float growY = 0;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		Vector2 movement = new Vector2 (1, 0);

		rb.AddForce (movement * speed);

		duration -= Time.deltaTime;
		if (duration <= 0)
			Destroy (gameObject);

		gameObject.transform.localScale += new Vector3 (growX, growY, 0);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialXSpeed = 35f;
    public float initialYSpeed = 10f;

    public Rigidbody2D _rb2d;

	private void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		ResetPosition();
		Invoke("AddStartingForce", 1.5f);
	}

	public void ResetPosition()
	{
		_rb2d.velocity = Vector2.zero;
		_rb2d.position = Vector2.zero;
	}

	public void AddStartingForce()
    {
        float randX = Random.value < 0.5f ? -1f : 1f;
        float randY = Random.value < 0.5f ? -1f : 1f;
        _rb2d.AddForce(new Vector2(this.initialXSpeed * randX, this.initialYSpeed * randY)); 
    }

	public void AddForce(Vector2 force)
	{
		_rb2d.AddForce(force);
	}
}

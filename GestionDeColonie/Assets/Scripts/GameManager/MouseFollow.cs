using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
	Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	Camera rb;
	Vector3 position = new Vector3(0f, 0f,0f);

	private void Start()
	{
		rb = GetComponent<Camera>();
	}

	private void Update()
	{
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
	}

	private void FixedUpdate()
	{
		rb.transform.position+=position;
	}
}

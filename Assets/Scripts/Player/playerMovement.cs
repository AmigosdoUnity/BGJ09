using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public byte speed;

	public byte jumpSpeed;

	private Rigidbody2D rb;

	private RaycastHit2D hit;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 vel = rb.velocity;

		vel.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime * 20;

		hit = Physics2D.Raycast (transform.position, Vector3.down, transform.localScale.y / 2 + 0.1f, 1 << 8);

		if (Input.GetAxisRaw("Vertical") > 0)
		{
			if (hit.collider != null)
			{
				vel.y = jumpSpeed * Time.deltaTime;
			}
		}


		rb.velocity = vel;
	}
}

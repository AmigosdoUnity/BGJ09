using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	private Rigidbody2D rb;

	private int dir = 1;

	private SpriteRenderer sr;

	public byte speed;

	// Use this for initialization
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();

		sr = transform.GetChild(0).GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Movimento
		Vector3 t = rb.velocity;
		t.x = dir * speed * Time.deltaTime * 5;
		
		rb.velocity = t;
		///////// end Movimento

		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * dir, sr.bounds.size.x/2, 1 << 8);

		Debug.DrawRay (transform.position, Vector3.right * dir);

		if (hit.collider != null)
		{
			dir = -dir;
		}
	}

	public int getDir()
	{
		return dir;
	}
}

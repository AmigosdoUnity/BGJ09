using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public byte speed;

	public byte jumpSpeed;

	private Rigidbody2D rb;

	private RaycastHit2D hit;

	private Collider2D c;

	private Vector3 s;
	private Vector3 ts;

	public string state = "ground";
	public SpriteAnimator animator;
	private bool walking = false;
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		c = gameObject.GetComponent<PolygonCollider2D> ();

		s = transform.localScale;
		ts = s;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Velocidade
		Vector3 vel = rb.velocity;

		//// state machine

		if( state == "ground" )
		{
			vel.y = -0.2f;
			vel.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime * 20;
			if( !walking  )if( Input.GetAxis ("Horizontal")!= 0 )
			{
				animator.Play( "Walk" );
				walking = true;
			}
			if( walking  )if( Input.GetAxis ("Horizontal") == 0 )
			{
				animator.Play( "Idle" );
				walking = false;
			}

			if( Input.GetKeyDown( KeyCode.Space))
			{
				state = "mine";
				animator.Play( "PickAxe" );
			}
			else if ( (Input.GetAxisRaw("Vertical") > 0)  )
			{
				vel.y = jumpSpeed * Time.deltaTime * 50;
				state = "air";
			}
			else if( ! c.IsTouchingLayers(1 << 8) )
			{
				state = "air";
			}
		}
		if( state == "air" )
		{
			vel.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime * 20;
			if( c.IsTouchingLayers(1 << 8) )
				state = "ground";
			if( Input.GetKeyDown( KeyCode.Space))
			{
				state = "mine";
				animator.Play( "PickAxe" );
			}
		}
		if( state == "mine" )
		{
			vel.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime * 10;
			if( animator.done )
			{
				state = "air";
				animator.Play( "Idle" );
				walking = false;
			}
		}
		rb.velocity = vel;
		////////// end Velocidade

		// Posiçao ajuste
		Vector3 p = transform.position;

		if (p.x < -53.9f)
			p.x = -53.9f;
		else if (p.x > -46.1f)
			p.x = -46.1f;

		transform.position = p;
		////////// end Posiçao ajuste


		// Sprite pela mov
		if( state != "mine" )
		{
			if (Input.GetAxisRaw ("Horizontal") < 0)
				ts.x = -s.x;
			else if (Input.GetAxisRaw ("Horizontal") > 0)
				ts.x = s.x;
				
			transform.localScale = ts;
		}
		////////// end Sprite pela mov
	}
}

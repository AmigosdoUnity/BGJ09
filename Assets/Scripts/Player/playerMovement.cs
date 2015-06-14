using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public byte speed;

	public byte jumpSpeed;

	private Rigidbody2D rb;

	private RaycastHit2D hit;

	private CircleCollider2D c;

	private Vector3 s;
	private Vector3 ts;

	public string state = "ground";

	private SpriteRenderer sr;

	public SpriteAnimator animator;
	private bool walking = false;
	private int mineType = 1;
	public GameObject WinPanel;

	void MineTransition()
	{
		if( Input.GetAxisRaw("Vertical") < 0 )
		{
			animator.Play( "Shovel" );
			mineType = 1;
		}
		else
		{
			animator.Play( "PickAxe" );
			mineType = 0;
		}
	}

	void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		c = gameObject.GetComponent<CircleCollider2D> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();

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
			vel.x = -0.05f * transform.localScale.x;
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
				MineTransition();
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

			RaycastHit2D hit = Physics2D.Raycast(c.bounds.center - new Vector3(0,c.bounds.extents.y,0), Vector2.down, 0.05f, 1 << 8);

			if (hit.collider != null)
				state = "ground";

			if( Input.GetKeyDown( KeyCode.Space))
			{
				state = "mine";
				MineTransition();
			}
		}
		if( state == "mine" )
		{
			vel.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime * 10;
			if( animator.AccessEvent() )
			{
				int cont = 0;
				while( cont < 5 )
				{
					Vector2 orig;
					Vector2 dir;

					if(mineType == 0)
					{
						dir.y = 0;
						dir.x = transform.localScale.x;
						orig.x = transform.position.x + transform.localScale.x*0.09f;
						orig.y = transform.position.y + 0.25f - (0.07f*cont);
					}
					else
					{
						dir.y = -1;
						dir.x = 0;
						orig.x = transform.position.x ;
						orig.y = transform.position.y - transform.localScale.y*0.17f  ;
					}
					hit = Physics2D.Raycast( orig, dir,  0.03f );

					if( hit.collider != null )
					{
						if( hit.collider.gameObject.tag == "Dirt")
						if( hit.collider.gameObject.GetComponent<Indestructible>() == null )
						{
							GameObject.Destroy( hit.collider.gameObject );
						}

						if( hit.collider.gameObject.tag == "Pig" )
						{
							WinPanel.SetActive (true);
							disableMovement();
						}
					}
					cont++;
				}
			}
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

	public void disableMovement()
	{
		rb.velocity = Vector3.zero;
		enabled = false;
	}
}

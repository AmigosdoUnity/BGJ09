using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	private Rigidbody2D rb;

	private int largura, altura;
	
	private Vector3 startPosition;
	
	private int dir = 1;

	public byte speed;

	// Use this for initialization
	void Start ()
	{
		largura = 2;

		startPosition = transform.position;

		rb = gameObject.GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Movimento
		Vector3 t = rb.velocity;
		t.x = dir * speed * Time.deltaTime * 5;
		
		rb.velocity = t;
		
		if (transform.position.x - startPosition.x > largura * 0.3f)
		{
			dir = -1;
		} else if (transform.position.x - startPosition.x < 0)
		{
			dir = 1;
		}
		///////// end Movimento
	}

	public void setPatrol(Vector3 sp, int l, int a)
	{
		startPosition = sp;
		largura = l;
		altura = a;
	}

	public int getDir()
	{
		return dir;
	}
}

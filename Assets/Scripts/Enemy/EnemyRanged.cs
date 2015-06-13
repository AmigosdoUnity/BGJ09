using UnityEngine;
using System.Collections;

public class EnemyRanged : MonoBehaviour {

	public byte speed;

	public GameObject projetil;

	private int largura, altura;

	private Vector3 startPosition;

	private Rigidbody2D rb;

	private int dir = 1;

	private float timeCount = 0;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		largura = 2;
		startPosition = transform.position;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Movimento
		Vector3 t = rb.velocity;
		t.x = dir * speed * Time.deltaTime * 20;

		rb.velocity = t;

		if (transform.position.x - startPosition.x > largura * 0.3f)
		{
			dir = -1;
		} else if (transform.position.x - startPosition.x < 0)
		{
			dir = 1;
		}
		///////// end Movimento

		// Projetil
		if (timeCount > 2)
		{
			timeCount = 0;
			GameObject obj = GameObject.Instantiate(projetil, transform.position + new Vector3(sr.bounds.size.x * dir,0,0), Quaternion.identity) as GameObject;
			obj.GetComponent<Projetil>().setDirection(dir);
		}

		timeCount += Time.deltaTime;
		///////// end Projetil
	}

	void setPatrol(Vector3 sp, int l, int a)
	{
		startPosition = sp;
		largura = l;
		altura = a;
	}
}

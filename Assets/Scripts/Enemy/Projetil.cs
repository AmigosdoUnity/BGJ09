using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	public byte speed;

	private float timeCount = 0;

	private int dir = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Velocidade
		Vector3 p = transform.position;

		p.x += dir * Time.deltaTime * speed / 10;

		transform.position = p;
		///////// end Velocidade


		// Timer
		if (timeCount > 2)
		{
			timeCount = 0;
			GameObject.Destroy(gameObject);
		}
		timeCount += Time.deltaTime;
		//////// end Timer
	}

	public void setDirection(int d)
	{
		dir = d;
	}
}

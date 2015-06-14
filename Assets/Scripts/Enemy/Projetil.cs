using UnityEngine;
using System.Collections;

public class Projetil : MonoBehaviour {

	public byte speed;

	public Transform player;

	private float timeCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Velocidade
		Vector3 p = transform.position;

		p += (player.position - transform.position).normalized * Time.deltaTime * speed / 10;

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

	public void setPlayer(Transform p)
	{
		player = p; 
	}
}

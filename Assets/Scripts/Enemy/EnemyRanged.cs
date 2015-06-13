using UnityEngine;
using System.Collections;

public class EnemyRanged : MonoBehaviour {

	public GameObject projetil;

	public Transform player;

	private float timeCount = 0;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Projetil
		if (timeCount > 2)
		{
			timeCount = 0;
			GameObject obj = GameObject.Instantiate(projetil, transform.position + (player.position - transform.position).normalized * 3 * sr.bounds.size.x /2, Quaternion.identity) as GameObject;

			obj.GetComponent<Projetil>().setPlayer(player);
		}

		timeCount += Time.deltaTime;
		///////// end Projetil
	}
}

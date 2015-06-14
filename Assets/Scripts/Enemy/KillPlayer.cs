using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.layer == 8)
		{
			GameObject.Destroy(gameObject);
		} else if (c.gameObject.name == "Player")
		{
			c.transform.GetComponent<playerDeath>().playerDied();
			GameObject.Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "Player")
		{
			c.transform.GetComponent<playerDeath>().playerDied();
		}
	}
}

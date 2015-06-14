using UnityEngine;
using System.Collections;

public class playerDeath : MonoBehaviour {

	public Transform t;

	public void playerDied()
	{
		transform.position = t.position;
	}
}

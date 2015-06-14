using UnityEngine;
using System.Collections;

public class playerDeath : MonoBehaviour {

	public Transform t;

	private GameObject DiePanel;

	void Start()
	{
		DiePanel = GameObject.FindGameObjectWithTag ("UI").transform.FindChild("DiePanel").gameObject;
	}

	public void playerDied()
	{
		DiePanel.SetActive (true);
		gameObject.GetComponent<playerMovement> ().disableMovement();
		transform.position = t.position;
	}

	public void resetPlayer()
	{
		transform.position = t.position;
	}
}

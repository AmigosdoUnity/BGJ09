using UnityEngine;
using System.Collections;

public class playerInteract : MonoBehaviour {

	public GameObject store;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			store.SetActive(!store.activeSelf);
		}
	}
}

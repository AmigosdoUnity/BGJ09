using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutSceneController : MonoBehaviour {

	public GameObject player;

	public Image baloon;

	public Text text;

	public string[] s = new string[5];

	public int count;

	// Use this for initialization
	void Start () 
	{
		player.GetComponent<playerMovement> ().disableMovement ();
	}
	
	public void setNextText()
	{
	}
}

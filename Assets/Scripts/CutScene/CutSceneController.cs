using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CutSceneController : MonoBehaviour {

	public GameObject player;

	public RectTransform baloon;

	public Text text;

	public GameObject controlText;
	public GameObject resetButton;
	public GameObject resetMapButton;

	private RectTransform tt;

	private string[] s = new string[4]
	{
		"Hey, I wanna buy some bacon!",
		"Oh! Im sorry, we're out of bacon!",
		"But dont worry! In this hole there's a pig",
		"Go get your own bacon."
	};

	private int[] i = new int[4]
	{
		1,
		-1,
		1,
		1,
	};

	private int count = 0;

	// Use this for initialization
	void Start () 
	{
		text.text = s [0];
		player.GetComponent<playerMovement> ().disableMovement ();

		tt = text.GetComponent<RectTransform>();
	}
	
	public void setNextText()
	{
		count++;

		if (count < 4)
		{
			text.text = s [count];

			if (i[count] == -1)
			{
				Vector3 t = baloon.localScale;

				t.x = -t.x;

				baloon.localScale = t;

				tt.localScale = t;
			}
		}else
		{
			Vector3 t = player.transform.localScale;
			t.x = -t.x;

			player.transform.localScale = t;

			player.GetComponent<playerMovement>().enabled = true;

			transform.parent.gameObject.SetActive(false);
			controlText.SetActive(true);
			resetButton.SetActive(true);
			resetMapButton.SetActive(true);
		}
	}
}

using UnityEngine;
using System.Collections;

public class GenerateGround : MonoBehaviour {

	public GameObject dirt;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		sr = dirt.GetComponent<SpriteRenderer> ();
		generateGround ();
	}

	private void generateGround()
	{
		// Cobertura
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 7; j++)
			{
				Vector3 t = transform.position;

				t.x += j * sr.bounds.size.x;
				t.y -= i * sr.bounds.size.y;

				GameObject obj = GameObject.Instantiate(dirt, t, Quaternion.identity) as GameObject;

				obj.transform.parent = transform;
			}
		}
	}
}

using UnityEngine;
using System.Collections.Generic;

public class GenerateGround : MonoBehaviour {

	public GameObject dirt;
	
	public List<Espaço> e = new List<Espaço>();

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		sr = dirt.GetComponent<SpriteRenderer> ();
		generateGround ();
	}

	private void generateGround()
	{
		int randL = 0;
		int randA = 0;
		int randP = 0;

		int tL = 0;
		int tA = 0;

		// Dirt
		for (int i = 0; i < 80; i++)
		{
			if (tA < 1 && i % 4 == 0)
			{
				randL = Random.Range(5, 10);
				randA = Random.Range(2, 4);
				randP = Random.Range(0, 28 - randL);

				tL = randL;
				tA = randA;
				Debug.Log(randA + " e " + randL);
			} else if (tA > 0)
			{
				tL = randL;
			}
			tA--;

			for (int j = 0; j < 28; j++)
			{
				if (j < randP || tL == 0)
				{
					Vector3 t = transform.position;

					t.x += j * (sr.bounds.size.x-0.003f);
					t.y -= i * (sr.bounds.size.y-0.003f);

					GameObject obj = GameObject.Instantiate(dirt, t, Quaternion.identity) as GameObject;

					obj.transform.parent = transform;
				} else if (j >= randP)
				{
					tL--;
				}

				if (tA == 1 && j == randP)
				{
					Vector3 t = transform.position;

					t.x += j * (sr.bounds.size.x-0.003f);
					t.y -= i * (sr.bounds.size.y-0.003f);

					Espaço te = new Espaço(t, randA, randL);

					e.Add(te);
				}
			}
		}
		///////// end Dirt
	}
}

using UnityEngine;
using System.Collections.Generic;

public class GenerateGround : MonoBehaviour {

	public GameObject dirt;
	
	public List<Monstro> m = new List<Monstro>();

	public List<GameObject> mP = new List<GameObject> ();

	public int AlturaMax = 80;

	public Transform MonsterFolder;

	public Transform player;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		sr = dirt.GetComponent<SpriteRenderer> ();
		Random.seed = System.DateTime.Now.Second;
		generateGround ();
		generateMonsters ();
	}

	private void generateGround()
	{
		int randL = 0;
		int randA = 0;
		int randP = 0;

		int tL = 0;
		int tA = 0;

		// Dirt
		for (int i = 0; i < AlturaMax; i++)
		{
			if (tA < 1 && i % 5 == 0)
			{
				randL = Random.Range(5, 10);
				randA = Random.Range(3, 5);
				randP = Random.Range(1, 27 - randL);

				tL = randL;
				tA = randA;

				if (i+randA >= AlturaMax)
				{
					tL = 0;
					tA = 0;
				}

			} else if (tA > 0)
			{
				tL = randL;
			}
			tA--;

			for (int j = 0; j < 28; j++)
			{
				if (j < randP || tL == 0)
				{
					if (Random.Range(0,4)%4 == 0 && j < 22 && i < AlturaMax-3)
						tL = Random.Range (3, 6);


					Vector3 t = transform.position;

					t.x += j * (sr.bounds.size.x-0.003f);
					t.y -= i * (sr.bounds.size.y-0.003f);

					GameObject obj = GameObject.Instantiate(dirt, t, Quaternion.identity) as GameObject;

					obj.transform.parent = transform;
				} else if (j >= randP && tL > 0)
				{
					tL--;
				}

				if (tA == 0 && j == randP)
				{
					Vector3 t = transform.position;

					t.x += j * (sr.bounds.size.x-0.003f);
					t.y -= i * (sr.bounds.size.y-0.003f);

					Monstro tm = new Monstro(t, randA, randL);

					m.Add(tm);
				}
			}
		}
		///////// end Dirt
	}

	private void generateMonsters()
	{
		int tam = m.Count;

		int[] tipos = new int[mP.Count];

		for (int i = 0; i < tam; i++)
		{
			GameObject obj = GameObject.Instantiate(mP[Random.Range(0,mP.Count)], m[i].position, Quaternion.identity) as GameObject;

			obj.transform.parent = MonsterFolder;

			EnemyPatrol p = obj.GetComponent<EnemyPatrol>();
			EnemyRanged r = obj.GetComponent<EnemyRanged>();

			if (p != null)
			{
				p.setPatrol(obj.transform.position, m[i].largura, m[i].alt);
			}

			if (r != null)
			{
				r.player = player;
			}
		}

	}
}

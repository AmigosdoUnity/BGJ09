using UnityEngine;
using System.Collections.Generic;

public class Monstro {

	public Vector3 position;

	public int alt, largura;

	public Monstro (Vector3 _p, int _a, int _l)
	{
		position = _p;
		alt = _a;
		largura = _l;
	}
}

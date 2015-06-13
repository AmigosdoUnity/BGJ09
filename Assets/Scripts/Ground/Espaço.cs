using UnityEngine;
using System.Collections;

public class Espaço {

	public Vector3 position;

	public int alt, largura;

	public Espaço (Vector3 _p, int _a, int _l)
	{
		position = _p;
		alt = _a;
		largura = _l;
	}
}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;


	// Update is called once per frame
	void Update () {

		Vector3 temp = new Vector3 (target.position.x, target.position.y, 0);
		temp.z = transform.position.z;


		transform.position = temp;
	}
}

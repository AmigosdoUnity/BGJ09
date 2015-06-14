#pragma strict

var musicObj:GameObject;

function Start()
{
	GameObject.DontDestroyOnLoad( musicObj );
}
function Update () {
	if( Input.GetKeyDown( KeyCode.Space ))
	{
		Application.LoadLevel(1);
	}
}
﻿#pragma strict

function Update () {
	if( Input.GetKeyDown( KeyCode.Space ))
	{
		Application.LoadLevel(0);
	}
}
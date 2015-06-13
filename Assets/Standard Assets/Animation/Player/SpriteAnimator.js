#pragma strict
var sprt:SpriteRenderer;   
var curAnim:SpriteAnimation;   // current animation
var curFrame:int;     /// current frame
var anim:SpriteAnimation[];  ////// animation list
var speed:float; //// animation speed
var timer:float; /// contador
var autoPlay:int= -1;   ///// which animation will play automatically
var done:boolean = false;    /////////// animation reach its end
var event:boolean = false;
var canEvent:boolean = false;

function AccessEvent(  ):boolean
{
	if( event )
	{
		event = false;
		canEvent = false;
		return true;
	}
	return false;
}
function GetAnimation( nome:String):int
{
	var cont:int = 0;
	while(cont < anim.Length)
	{
		if( anim[ cont ].nome == nome ){ return cont; }
		cont++;
	}
	return -1;
}
function Play( s:String, alt:boolean )
{
	var i:int = GetAnimation( s );
	if(i >= 0)
	{
		Play( i );
	}
	else Debug.Log("Animassao n existe 2 +"+s);
}               
function Play( i:int )
{
	curAnim = anim[ i ]; 
	curFrame = 0;     
	sprt.sprite = curAnim.frame[curFrame];   ///// 
	timer = 0;
	done = false;
	event = false;
	canEvent = true;
}
function Play( s:String )
{
	var i:int = GetAnimation( s );
	if(i >= 0) Play( i );
	else Debug.Log("Animassao n existe +"+s);
}
function Start()
{
	anim = gameObject.GetComponents.<SpriteAnimation>( );
	if( autoPlay >= 0 )
	{
		Play( autoPlay );
	}
}

function Update()
{
	if( curAnim != null)
	{
		if(timer >= 0)
			timer += Time.deltaTime*speed*curAnim.speed;
		
		var tmpbool:boolean = false;
		if( curFrame < curAnim.time.Length )
		{
			if(timer > curAnim.time[curFrame] ){tmpbool = true;}
		}
		else if(timer > 1 ){tmpbool = true;}
		
		if(tmpbool)
		{
			timer = 0;
			curFrame ++;
			if( curFrame == curAnim.frame.Length )
			{
				if(  curAnim.style == "normal" ){ curFrame--;timer = -1; done = true; }
				else if( curAnim.style == "loop" ){ curFrame = 0; }
			}
			sprt.sprite = curAnim.frame[curFrame];
		}
		if( curAnim.eventFrame >= 0 )
		if( curFrame == curAnim.eventFrame )
		if(canEvent)
			event = true;
	}
}
#pragma strict

public var myTextFile : TextAsset;

var points : Vector4[];
var balls : GameObject[];

private var counter : int;

function Start () {
    
	setupPoints();
}
//
//function Update () {
//	
//	updatePoints();
//	
//}


function setupPoints () {

    points = new Vector4[60000];

	var stringArray = myTextFile.text.Split("\n"[0]);
	
	for ( var i = 0; i < 60000; i ++ ) {

		var point = stringArray[i].Split(","[0]);
		var vec = new Vector4(parseFloat(point[0]),parseFloat(point[1]),parseFloat(point[2]),parseFloat(point[3]));
		points[i] = vec;
	}

	 
	gameObject.Find("cloudManager").SendMessage("drawAnim",points);


}


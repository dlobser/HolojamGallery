#pragma strict

public var myTextFile : TextAsset;

public var ball : GameObject;
public var cam : Transform;

var points : Vector3[];
var balls : GameObject[];
var scales : float[];

private var counter : int;

function Start () {
    
	setupPoints();
}

function Update () {
	
	updatePoints();
	
}


function updatePoints(){

	var q = 0;
	
	for ( var i = counter; i < counter+5000; i ++ ) {
		balls[q].transform.position = points[i];
		balls[q].transform.localScale = new Vector3(scales[i],scales[i],scales[i]);
		balls[q].transform.rotation = cam.transform.parent.transform.localRotation;
//		balls[q].transform.LookAt(Camera.mainCamera.transform.position);
	 	q++;
	}
	
	counter+=5000;
	if(counter>50000)
		counter=0;
		
}

function setupPoints () {

	balls = new GameObject[5000];
    points = new Vector3[80000];
    scales = new float[80000];

	var stringArray = myTextFile.text.Split("\n"[0]);
	for ( var i = 0; i < 55000; i ++ ) {

		var point = stringArray[i].Split(","[0]);
		var vec = new Vector3(parseFloat(point[0]),parseFloat(point[1]),parseFloat(point[2]));
		points[i] = vec;
		scales[i] = parseFloat(point[3])*5;
	}

	for ( i = 0; i < 5000; i ++ ) {
		var clone : GameObject = GameObject.Instantiate(ball,vec,Quaternion.identity);
	 	balls[i] = clone;
 	}
	 
	GameObject.Find("particleTestForPoles").SendMessage("Start",points);


}


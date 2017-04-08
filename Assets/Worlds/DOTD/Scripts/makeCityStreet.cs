using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class makeCityStreet : MonoBehaviour {

	public GameObject building;
	public GameObject[] window;
	
	List<GameObject> buildings;

	public int amount = 10;
	public Vector3 buildingMax = Vector3.one;
	public Vector3 buildingMin = Vector3.one;

	public Vector2 windowSizeMin = Vector2.one;
	public Vector2 windowSizeMax = Vector2.one;
	public Vector2 windowBorderMin = Vector2.one;
	public Vector2 windowBorderMax = Vector2.one;

	public float buildingZOffset = 5;
	public float buildingYOffset = -5;

	public float startPos = 0;
	public float endPos = 100f;
	public float speed = 1;

	public bool leftRight = true;


	// Use this for initialization
	void Start () {
		buildings = new List<GameObject>();
		Vector3 offset = new Vector3(endPos,0,0);

		//for (int i = 0; i < amount; i++) {
		//	while(offset.x<endPos-((windowSizeMax.x+windowBorderMax.x)*buildingMax.x)*3)
				offset += makeBuilding(offset);
                while (buildings[buildings.Count - 1].transform.position.x > startPos)
                {
                    Vector3 o = makeBuilding(new Vector3(buildings[findClosest()].transform.localPosition.x, 0, 0));
                    buildings[buildings.Count - 1].transform.position -= new Vector3(o.x, 0, 0);
                    //buildings[buildings.Count - 1].transform.localScale = new Vector3(sc, sc, sc);
                }

		//}w
				buildings.RemoveAt (buildings.Count - 1);

                for (int i = 0; i < buildings.Count; i++)
                {
                    moveBuilding m = buildings[i].AddComponent<moveBuilding>();
                    m.endPos = this.endPos;
                    m.startPos = this.startPos;
                    m.speed = this.speed;
                }
	}

	void Update () {

		for (int i = 0; i < buildings.Count; i++) {
            moveBuilding m = buildings[i].GetComponent<moveBuilding>();
            m.endPos = this.endPos;
            m.startPos = this.startPos;
            m.speed = this.speed;
		}
	}
	
	Vector3 makeBuilding(Vector3 offset){
		Vector3 min = buildingMin;
		Vector3 max = buildingMax;
		
		Vector2 windowSize = new Vector2(
			Random.Range(windowSizeMin.x,windowSizeMax.x),
			Random.Range(windowSizeMin.y,windowSizeMax.y));
		
		Vector2 windowBorder = new Vector2(
			Random.Range(windowBorderMin.x,windowBorderMax.x),
			Random.Range(windowBorderMin.y,windowBorderMax.y));
		
		Vector2 numWindow = new Vector2(
			Mathf.Round(Random.Range(min.x,max.x)),
			Mathf.Round(Random.Range(min.y,max.y)));
		
		Vector3 scaleToWindow = new Vector3(
			numWindow.x*(windowSize.x+windowBorder.x),
			numWindow.y*(windowSize.y+windowBorder.y),
			Random.Range(min.z,max.z));
		
		GameObject b = Instantiate(building) as GameObject;
		b.GetComponent<Renderer> ().enabled = true;
		if(leftRight)
			moveVerts(b,new Vector3(.5f,.5f,-.5f));
		else
			moveVerts(b,new Vector3(.5f,.5f,.5f));
		GameObject thisBuilding = new GameObject();
		

		float zScale = Random.Range(buildingMin.z,buildingMax.z);
		scaleVerts (b, new Vector3 (scaleToWindow.x, scaleToWindow.y, zScale)+new Vector3(windowBorder.x,windowBorder.y,0));

//		moveVerts(b,new Vector3(0,0,-zScale));
		b.transform.parent = thisBuilding.transform;
		
		
		for(int j = 0 ; j < numWindow.x ; j++){
			for(int k = 0 ; k < numWindow.y ; k++){

				GameObject w = Instantiate(window[(int)Mathf.Floor(Random.Range(0,window.Length))])as GameObject;
				w.GetComponent<Renderer>().enabled = true;
				moveVerts (w,new Vector3(.5f,.5f,0));
				scaleVerts (w,new Vector3(windowSize.x,windowSize.y,1));
				moveVerts (w,new Vector3(windowBorder.x,windowBorder.y,0));
				float zMove = -.1f;
				if(leftRight){
					zMove*=-1;
					flipNormals(w);
				}
				scaleUVs(w);
				moveVerts (w,new Vector3((j/numWindow.x)*scaleToWindow.x,(k/numWindow.y)*scaleToWindow.y,zMove));
				w.transform.parent = thisBuilding.transform;
			}
		}
		thisBuilding.transform.localPosition = offset;
		thisBuilding.transform.Translate (new Vector3 (0, buildingYOffset, buildingZOffset));
		thisBuilding.transform.parent = transform;
		buildings.Add (thisBuilding);
		return new Vector3(scaleToWindow.x,0,0)+new Vector3(windowBorder.x,0,0);

	}

	void scaleVerts(GameObject obj,Vector3 scale){
		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh;
		Vector3[] verts = mesh.vertices;
		for (int i = 0; i < mesh.vertices.Length; i++) {
			verts[i] = Vector3.Scale(verts[i],scale);
		}
		mesh.vertices = verts;
		mesh.RecalculateNormals ();
		mesh.RecalculateBounds();
	}
	void moveVerts(GameObject obj,Vector3 offset){
		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh;
		Vector3[] verts = mesh.vertices;
		for (int i = 0; i < mesh.vertices.Length; i++) {
			verts[i]+=offset;
		}
		mesh.vertices = verts;
		mesh.RecalculateNormals ();
		mesh.RecalculateBounds();
	}

	void setUVs(GameObject obj){
		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh;
		Vector2[] UV = mesh.uv;
		float r = Random.value;
		for (int i =0; i < UV.Length; i++) {
			UV[i] = new Vector2(r,r);
		}
		mesh.uv = UV;
	}

	void scaleUVs(GameObject obj){
		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh;
		Vector2[] UV = mesh.uv;
		float r = Random.value;
		float sc = Random.Range (.001f, .01f);
		for (int i =0; i < UV.Length; i++) {
			UV[i] = Vector2.Scale(UV[i],new Vector2(sc,sc));
			UV[i]+=new Vector2(r,r);
		}
		mesh.uv = UV;
	}

	void setUVs(GameObject obj,Vector2 pos){
		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh;
		Vector2[] UV = mesh.uv;
		for (int i =0; i < UV.Length; i++) {
			UV[i] = pos;
		}
		mesh.uv = UV;
	}


	void flipNormals(GameObject obj){

		Mesh mesh = obj.GetComponent<MeshFilter> ().mesh;
		
		Vector3[] normals = mesh.normals;
		for (int i=0; i<normals.Length; i++)
			normals [i] = -normals [i];
		mesh.normals = normals;
		
		for (int m=0; m<mesh.subMeshCount; m++) {
			int[] triangles = mesh.GetTriangles (m);
			for (int i=0; i<triangles.Length; i+=3) {
				int temp = triangles [i + 0];
				triangles [i + 0] = triangles [i + 1];
				triangles [i + 1] = temp;
			}
			mesh.SetTriangles (triangles, m);
		}
	}

    int findClosest()
    {
        int index = 0;
        float min = 1e6f;
        for (int i = 0; i < buildings.Count; i++)
        {
            if (Mathf.Abs(buildings[i].transform.position.x) + startPos < min)
            {
                min = Mathf.Abs(buildings[i].transform.position.x);
                index = i;
            }
        }

        return index;
    }

    int findFarthest()
    {
        int index = 0;
        float min = 1e6f;
        for (int i = 0; i < buildings.Count; i++)
        {
            if (Mathf.Abs(buildings[i].transform.position.x) - endPos < min)
            {
                min = Mathf.Abs(buildings[i].transform.position.x);
                index = i;
            }
        }

        return index;
    }
	
	// Update is called once per frame

}

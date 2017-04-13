using UnityEngine;
using System.Collections;

public class particleTestForPoles : MonoBehaviour {

	public SpriteManager spManager;
//	public Transform cam;
	public GameObject gClient;
	public float pointScale = 1f;
	public int amount;

	public TextAsset[] myTextFiles;
	public Color[] colors;
	public float[] sizes;

	Sprite[] clients;
	GameObject[] xForms; 
	Vector3[] initPositions;
	Vector4[] points;
	int counter;

	bool init = false;

	
	void setupPoints () {
		
		points = new Vector4[60000*myTextFiles.Length];
//		colors = new Color[myTextFiles.Length];

		int i = 0;

		foreach (TextAsset myTextFile in myTextFiles) {

			string[] stringArray = myTextFile.text.Split (new char[] {'\n'});
		
			for (int q = 0; q < 60000; q++, i++) {
			
				string[] point = stringArray [q].Split (new char[] {','});
				points [i] = new Vector4 (float.Parse (point [0]), float.Parse (point [1]), float.Parse (point [2]), float.Parse (point [3]));
			}
		}
		
	}

	public void drawAnim(){

//		points = pnts;
		int len = 1;
		clients = new Sprite[len*amount];
		xForms = new GameObject[len*amount];
		initPositions = new Vector3[len * amount];

		counter = 0;

		for (int i = 0; i < amount; i++) {
//			GameObject lamp = new GameObject();//pole.Find("lamp/bulb").gameObject;
//			Vector3 p = Random.insideUnitSphere*50f;//new Vector3(Random.Range(-2,2),Random.Range(0,15),Random.Range(-2,2));
//			initPositions[i] = p;

			xForms [i] = Instantiate (gClient, points[i], Quaternion.identity) as GameObject;
			clients [i] = spManager.AddSprite (xForms [i], points[i].w*pointScale, points[i].w*pointScale, new Vector2 (0f, 0f), new Vector2 (1f,1f), Vector3.zero, true);
			spManager.SetBillboarded (clients [i]);
		}

		init = true;

	}

	void Start () {
		spManager.transform.position = new Vector3 (0f, 1f, 0f);
		setupPoints ();
		drawAnim ();
	}

	Color getColor(int index){

		if (colors.Length > 0 && index<colors.Length) {
			return colors[index];
		} else
			return Color.white;

	}

	float getSize(int index){
		if (sizes.Length > 0 && index<sizes.Length) {
			return sizes[index];
		} else
			return 1f;
	}
	
	void Update () {

		if (init) {

			int q = 0;

			for(int j = 0 ; j < myTextFiles.Length ; j++){

				for (int i = counter; i < counter+amount/myTextFiles.Length; i++) {

					int off = 60000*j;

					Color col = getColor (j);

					clients[q].SetColor(col);

//					if(j==1)
//						clients[q].SetColor(new Color(.7f,.9f,1f));
//					else if(j==2)
//						clients[q].SetColor(new Color(.3f,.4f,7f));
//					else
//						clients[q].SetColor(new Color(3f,.8f,1f));

					xForms [q].transform.position = new Vector3 (points [i+off].x, points [i+off].y, points [i+off].z);
					clients [q].SetSizeXY (points [i+off].w * pointScale * getSize (j), points [i+off].w * pointScale * getSize (j));
					spManager.TransformBillboarded (clients [q]);
					q++;

//					}
//					else{
//						clients[q].SetColor(new Color(.8f,1f,1f));
//						xForms [q].transform.position = new Vector3 (points [i+60000].x, points [i+60000].y, points [i+60000].z);
//						clients [q].SetSizeXY (points [i+60000].w * pointScale, points [i+60000].w * pointScale);
//						spManager.TransformBillboarded (clients [q]);
//						q++;
//					}
				
				}

			}
			counter += amount/myTextFiles.Length;
			if (counter + amount > 60000) {
				counter = 0;

			}


		}
	}

}

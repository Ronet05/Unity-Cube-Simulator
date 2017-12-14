using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CubeController : MonoBehaviour {

	private Transform[] centerP ;
	private Transform[] cornerP ;
	private Transform[] edgeP;
	private Transform cube_3x3x3;
	
	private float sensitivityX = 15.0f;
	private float sensitivityY = 15.0f;
    [HideInInspector]
	public int[] rotationSpeeds;
   
	private int speed = 10;
	private int count = 10;
	private Transform cameraTm;
	private bool rotate = false;
	private bool rotateInit = false;

	private List<int> scrambleList;
	private List<bool> scrambleReverseList;
	private bool scramble = false;
	
	private int selection = -1;
	
    public enum speedList {
        _1 = 0,_2 = 1,_3 = 2,_5 = 3,_6 = 4,_9 = 5,_10 = 6,_15 = 7,_18 = 8,_30 = 9,_45 = 10,_90 = 11
    }

    public speedList speedOption;

    [HideInInspector]
    public int selectedItemIndex;
	
	private GameObject reverseObj;
	public bool reverse = false;
	
	private Cube2D cube2d;
	private string[,] face;
	
	[SerializeField]
	public Text timeText;
	private float time = 0.0f;

	private AudioController audioCon;
	
	private int state = -1;
	private bool stateOddOrEven = false;
	private int countState = 0;

	private bool solveMode = false;
	private List<int> solveMoveList;
	private List<bool> solveMoveReverseList;
    public Text solved;
	public int moves;

	void Start () {  

		cube2d = new Cube2D ();
		
		initPieces ();

		initETC ();
		
		initSpeedList ();

	}
	
	private void initETC(){
		
		cube_3x3x3 = GameObject.Find ("Cube 3x3x3").transform;
		reverseObj = GameObject.Find("reverse");

		scrambleList = new List<int>();
		scrambleReverseList = new List<bool>();

		solveMoveList = new List<int> ();
		solveMoveReverseList = new List<bool> ();

		cameraTm = Camera.main.transform;

		if (GameObject.Find ("Passport") != null)
			audioCon = GameObject.Find ("Passport").GetComponent<AudioController> ();
		else
			audioCon = null;

        selectedItemIndex = (int)speedOption;
     
	}

	private void initPieces(){

		centerP = new Transform[6];
		cornerP = new Transform[8];
		edgeP = new Transform[12];
		for (int i = 0; i < 6; i++) {
			centerP[i] = GameObject.FindGameObjectWithTag ("Center Piece " + (i + 1)).transform;
		}

		for (int i = 0; i < 8; i++) {
			cornerP[i] = GameObject.FindGameObjectWithTag ("Corner Piece " + (i + 1)).transform;
		}

		for (int i = 0; i < 12; i++) {
			edgeP[i] = GameObject.FindGameObjectWithTag ("Edge Piece " + (i + 1)).transform;
		}
	}

	private void centerPSpacing(Transform centerPie , float space){
		float x = centerPie.localPosition.x;
		float y = centerPie.localPosition.y;
		float z = centerPie.localPosition.z;

		if(Mathf.Abs(x) > Mathf.Max(Mathf.Abs(y),Mathf.Abs(z))){
			x += x > 0 ? space : -space;
		}else if(Mathf.Abs(y) > Mathf.Abs(z)){
			y += y > 0 ? space : -space;
		}else{
			z += z > 0 ? space : -space;
		}
		centerPie.localPosition = new Vector3(x,y,z);
	}

	private void cornerPSpacing(Transform cornerPie , float space){
		float x = cornerPie.localPosition.x;
		float y = cornerPie.localPosition.y;
		float z = cornerPie.localPosition.z;
				
		y += y > 0 ? space : -space;
		
		z += z > 0 ? space : -space;

		cornerPie.localPosition = new Vector3(x,y,z);
	}

	private float incr = 1.1f;
	private void edgePSpacing(Transform edgePie , float space){

		edgePie.position = (edgePie.position - centerP [selection].position).normalized * (incr) + centerP [selection].position;
		incr += space > 0 ? 0.01f : -0.01f;
	}
	
	private void initSpeedList(){
		rotationSpeeds = new int[]{1,2,3,5,6,9,10,15,18,30,45,90};		
	}

	void Update () {

		if (scramble && !rotate)
			if(scrambleList.Count > 0){
				selection = scrambleList[0];
				scrambleList.RemoveAt(0);
				reverse = scrambleReverseList[0];
				scrambleReverseList.RemoveAt(0);
				rotate = true;
			} else {
				scramble = false;
				rotate = false;
				reverse = scrambleReverseList[0];
				scrambleReverseList.RemoveAt(0);
			}

		if (solveMode && !rotate) {
			if(solveMoveList.Count > 0){
				selection = solveMoveList[0];
				solveMoveList.RemoveAt(0);
				reverse = solveMoveReverseList[0];
				solveMoveReverseList.RemoveAt(0);
				rotate = true;
			}else{
				solveMode = false;
				rotate = false;
				reverse = solveMoveReverseList[0];
				solveMoveReverseList.RemoveAt(0);
			}
		}

		controls ();
		rotation ();
	}

	private void controls(){
		if (Input.GetKeyDown (KeyCode.R) && !rotate) {
			selection = 0;
			rotate = true;
		} else if (Input.GetKeyDown (KeyCode.L) && !rotate) {
			selection = 2;
			rotate = true;
		} else if (Input.GetKeyDown (KeyCode.U) && !rotate) {
			selection = 5;
			rotate = true;
		} else if (Input.GetKeyDown (KeyCode.D) && !rotate) {
			selection = 4;
			rotate = true;
		} else if (Input.GetKeyDown (KeyCode.F) && !rotate) {
			selection = 3;
			rotate = true;
		} else if (Input.GetKeyDown (KeyCode.B) && !rotate) {
			selection = 1;
			rotate = true;
		} else if (Input.GetKeyDown (KeyCode.LeftControl) && !rotate) {
			if (!reverse) {
				if (reverseObj != null)
					reverseObj.GetComponentInChildren<Text> ().text = "Reverse On";
				reverse = true;
			} else if (reverse) {
				if (reverseObj != null)
					reverseObj.GetComponentInChildren<Text> ().text = "Reverse Off";
				reverse = false;
			}
		} else if (Input.GetKeyDown (KeyCode.S) && !rotate) { 
            SolveCube();
		}
	}

	private void rotation(){
		
		if (Input.GetMouseButton (1)) { 
			float rotationX = Input.GetAxis ("Mouse X") * sensitivityX;
			float rotationY = Input.GetAxis ("Mouse Y") * sensitivityY;
			transform.Rotate (cameraTm.up, -Mathf.Deg2Rad * rotationX * Time.deltaTime * 5000,Space.World);
			transform.Rotate (cameraTm.right, Mathf.Deg2Rad * rotationY * Time.deltaTime * 5000,Space.World);
		}
		
		if (rotate) {
			if(!rotateInit){
				face = cube2d.getFace(selection);
				
				for(int i = 0;i < 3;i++){
					for(int j = 0;j < 3;j++){
						GameObject.FindWithTag(face[i,j]).transform.parent = centerP[selection];
					}
				}

				cube2d.Rotate(selection);
				if(reverse){
					cube2d.Rotate(selection);
					cube2d.Rotate(selection);
				}
				
				count = speed = rotationSpeeds [selectedItemIndex]; 
				rotateInit = true;

				if(audioCon != null && audioCon.enableSFX)
					audioCon.sfxsource.PlayOneShot(audioCon.rubikturnsfx);

				state = 90 / speed;
				stateOddOrEven = state % 2 == 0 ? false : true;
			}
			
			centerP [selection].Rotate(new Vector3(reverse ? -speed : speed, 0 , 0));
			countState++;

			if(count >= 90){
				resetParents();
				rotateInit = false;
				rotate = false;
				count = 0;
				countState = 0;

				if(cube2d.isSolved()){
                    if(solved != null)
                        solved.enabled = true;
				}else{
                    if (solved != null)
                        solved.enabled = false;
				}
			}

			count += speed;
		}

	}

	private void debugTiles(){
		string msg = "\t\t\t\t";
		string [,] orange = cube2d.GetOrangeFaceTiles();
		string [,] green = cube2d.GetGreenFaceTiles();
		string [,] white = cube2d.GetWhiteFaceTiles();				
		string [,] blue = cube2d.GetBlueFaceTiles();
		string [,] red = cube2d.GetRedFaceTiles();
		string [,] yellow = cube2d.GetYellowFaceTiles();
		
		for(int i = 0;i < 3;i++){
			for(int j = 0;j < 3;j++){
				msg += orange[i,j] + " ";
			}
			msg += "\n\t\t\t\t";
		}
		
		msg += "\n";
		for(int i = 0;i < 3;i++){
			for(int j = 0;j < 9;j++){
				if(j < 3)
					msg += green[i,j] + " ";
				else if(j > 2 && j < 6)
					msg += white[i,j - 3] + " ";
				else
					msg += blue[i,j - 6] + " ";
				if(j == 2 || j == 5) msg += "\t\t";
			}
			msg += "\n";
		}
		
		msg += "\n\t\t\t\t";
		for(int i = 0;i < 3;i++){
			for(int j = 0;j < 3;j++){
				msg += red[i,j] + " ";
			}
			msg += "\n\t\t\t\t";
		}
		
		msg += "\n\t\t\t\t";
		for(int i = 0;i < 3;i++){
			for(int j = 0;j < 3;j++){
				msg += yellow[i,j] + " ";
			}
			msg += "\n\t\t\t\t";
		}
		print (msg);
	}
	
	private void resetParents(){
		for(int i = 0; i < 3; i++)
			for(int j = 0; j < 3; j++)
				GameObject.FindWithTag(face[i,j]).transform.parent = cube_3x3x3;
	}
	
	public void onButtonClick(string button){
		int result;
		if (!rotate && int.TryParse (button, out result)) {
			selection = result;
			rotate = true;
		} else {
			if(button.Equals("reset")){
				Application.LoadLevel(0);
			}else if(!rotate && button.Equals("reverse")){
				if(!reverse){
					reverseObj.GetComponentInChildren<Text>().text = "Reverse On";
					reverse = true;
				}else if(reverse){
					reverseObj.GetComponentInChildren<Text>().text = "Reverse Off";
					reverse = false;
				}
			}else if(!rotate && button.Equals("scramble")){
				scramble = true;
				for(int i = 0;i < 30;i++){
					scrambleList.Add(Random.Range(0 , 6));	
					scrambleReverseList.Add(Random.Range(0 , 2) == 1 ? true : false);
				}
				scrambleReverseList.Add(reverse); 
			}
		}
	}

    public void SolveCube() {
        
        solveMode = true;
        moves = cube2d.solveCube();
		solved.text = moves.ToString () + " moves!";

        while (cube2d.moveList.Count > 0) {
            string temp = cube2d.moveList[0];
            cube2d.moveList.RemoveAt(0);
            solveMoveReverseList.Add(temp.StartsWith("-") ? true : false);

            int f = 0;

            if (temp.Contains("F")) {
                f = 3;
            } else if (temp.Contains("B")) {
                f = 1;
            } else if (temp.Contains("D")) {
                f = 4;
            } else if (temp.Contains("R")) {
                f = 0;
            } else if (temp.Contains("L")) {
                f = 2;
            } else if (temp.Contains("U")) {
                f = 5;
            }
            solveMoveList.Add(f);
        }
		solveMoveReverseList.Add(reverse);
    }
		
}
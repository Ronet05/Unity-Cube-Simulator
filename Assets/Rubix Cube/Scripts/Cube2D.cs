using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube2D{

	private string[,] cube1 = new string[3,3];
	private string[,] cube2 = new string[3,3];
	private string[,] cube3 = new string[3,3];

	private string[,] cubeA = new string[3,3];
	private string[,] cubeB = new string[3,3];
	private string[,] cubeC = new string[3,3];

	public Cube2D () {
		initArray();
		init2DTilesCube ();
	}
	
	private void initArray(){
		
		cube2[1,2] = "Center Piece 1";
		cube3[1,1] = "Center Piece 2";
		cube2[1,0] = "Center Piece 3";
		cube1[1,1] = "Center Piece 4";
		cube2[2,1] = "Center Piece 5";
		cube2[0,1] = "Center Piece 6";
		
		cube3[0,2] = "Corner Piece 1";
		cube1[0,2] = "Corner Piece 2";
		cube1[2,2] = "Corner Piece 3";
		cube3[2,2] = "Corner Piece 4";
		cube3[0,0] = "Corner Piece 5";
		cube3[2,0] = "Corner Piece 6";
		cube1[0,0] = "Corner Piece 7";
		cube1[2,0] = "Corner Piece 8";
		
		cube2[0,2] = "Edge Piece 1";
		cube2[2,2] = "Edge Piece 2";
		cube3[1,2] = "Edge Piece 3";
		cube1[1,2] = "Edge Piece 4";
		cube2[0,0] = "Edge Piece 5";
		cube2[2,0] = "Edge Piece 6";
		cube1[1,0] = "Edge Piece 7";
		cube3[1,0] = "Edge Piece 8";
		cube3[0,1] = "Edge Piece 9";
		cube3[2,1] = "Edge Piece 10";
		cube1[2,1] = "Edge Piece 11";
		cube1[0,1] = "Edge Piece 12";		
		
		cube2[1,1] = "Void";

	}

	public string[,] getFace(int face){
		if (face == 0) {
			return getBlueFace();
		} else if (face == 1) {
			return getOrangeFace();
		} else if (face == 2) {
			return getGreenFace();
		} else if (face == 3) {
			return getRedFace();
		} else if (face == 4) {
			return getYellowFace();
		} else if (face == 5) {
			return getWhiteFace();
		}
		return null;
	}
	
	public string[,] getRedFace(){
		string[,] arr = new string[3,3];
		for(int i = 0;i < 3;i++)
			for(int j = 0;j < 3;j++)
				arr[i,j] = cube1[i,j];	
		return arr;
	}
	
	public string[,] getOrangeFace(){
		string [,] arr = new string[3,3];
		for(int i = 0;i < 3;i++)
			for(int j = 0;j < 3;j++)
				arr[i,j] = cube3[i,j];	
		return arr;
	}
	
	public string[,] getBlueFace(){
		string [,] arr = new string[3,3];
		arr[0,0] = cube1[0,2]; arr[0,1] = cube2[0,2]; arr[0,2] = cube3[0,2];
		arr[1,0] = cube1[1,2]; arr[1,1] = cube2[1,2]; arr[1,2] = cube3[1,2];
		arr[2,0] = cube1[2,2]; arr[2,1] = cube2[2,2]; arr[2,2] = cube3[2,2];
		return arr;
	}
	
	public string[,] getGreenFace(){
		string [,] arr = new string[3,3];
		arr[0,0] = cube1[0,0]; arr[0,1] = cube2[0,0]; arr[0,2] = cube3[0,0];
		arr[1,0] = cube1[1,0]; arr[1,1] = cube2[1,0]; arr[1,2] = cube3[1,0];
		arr[2,0] = cube1[2,0]; arr[2,1] = cube2[2,0]; arr[2,2] = cube3[2,0];
		return arr;
	}
	
	public string[,] getWhiteFace(){
		string [,] arr = new string[3,3];
		arr[0,0] = cube1[0,0]; arr[0,1] = cube2[0,0]; arr[0,2] = cube3[0,0];
		arr[1,0] = cube1[0,1]; arr[1,1] = cube2[0,1]; arr[1,2] = cube3[0,1];
		arr[2,0] = cube1[0,2]; arr[2,1] = cube2[0,2]; arr[2,2] = cube3[0,2];
		return arr;
	}
	
	public string[,] getYellowFace(){
		string [,] arr = new string[3,3];
		arr[0,0] = cube1[2,0]; arr[0,1] = cube2[2,0]; arr[0,2] = cube3[2,0];
		arr[1,0] = cube1[2,1]; arr[1,1] = cube2[2,1]; arr[1,2] = cube3[2,1];
		arr[2,0] = cube1[2,2]; arr[2,1] = cube2[2,2]; arr[2,2] = cube3[2,2];
		return arr;
	}
	
	public void Rotate(int face){
		if(face == 3)
		{
			string temp = cube1[0,0];
			cube1[0,0] = cube1[2,0];
			cube1[2,0] = cube1[2,2];
			cube1[2,2] = cube1[0,2];
			cube1[0,2] = temp;
			
			temp = cube1[0,1];
			cube1[0,1] = cube1[1,0];
			cube1[1,0] = cube1[2,1];
			cube1[2,1] = cube1[1,2];
			cube1[1,2] = temp;		

			rotate2DTRed();
		} 
		else if(face == 0)
		{
			string temp = cube1[0,2];
			cube1[0,2] = cube1[2,2];
			cube1[2,2] = cube3[2,2];
			cube3[2,2] = cube3[0,2];
			cube3[0,2] = temp;
			
			temp = cube2[0,2];
			cube2[0,2] = cube1[1,2];
			cube1[1,2] = cube2[2,2];
			cube2[2,2] = cube3[1,2];
			cube3[1,2] = temp;

			rotate2DTBlue();
		}
		else if(face == 1)
		{
			string temp = cube3[0,2];
			cube3[0,2] = cube3[2,2];
			cube3[2,2] = cube3[2,0];
			cube3[2,0] = cube3[0,0];
			cube3[0,0] = temp;
			
			temp = cube3[0,1];
			cube3[0,1] = cube3[1,2];
			cube3[1,2] = cube3[2,1];
			cube3[2,1] = cube3[1,0];
			cube3[1,0] = temp;

			rotate2DTOrange();
		}
		else if(face == 2)
		{
			string temp = cube3[0,0];
			cube3[0,0] = cube3[2,0];
			cube3[2,0] = cube1[2,0];
			cube1[2,0] = cube1[0,0];
			cube1[0,0] = temp;
			
			temp = cube2[0,0];
			cube2[0,0] = cube3[1,0];
			cube3[1,0] = cube2[2,0];
			cube2[2,0] = cube1[1,0];
			cube1[1,0] = temp;

			rotate2DTGreen();
		}
		else if(face == 5)
		{
			string temp = cube1[0,0];
			cube1[0,0] = cube1[0,2];
			cube1[0,2] = cube3[0,2];
			cube3[0,2] = cube3[0,0];
			cube3[0,0] = temp;
			
			temp = cube2[0,0];
			cube2[0,0] = cube1[0,1];
			cube1[0,1] = cube2[0,2];
			cube2[0,2] = cube3[0,1];
			cube3[0,1] = temp;

			rotate2DTWhite();
		}
		else if(face == 4)
		{
			string temp = cube1[2,0];
			cube1[2,0] = cube3[2,0];
			cube3[2,0] = cube3[2,2];
			cube3[2,2] = cube1[2,2];
			cube1[2,2] = temp;
			
			temp = cube1[2,1];
			cube1[2,1] = cube2[2,0];
			cube2[2,0] = cube3[2,1];
			cube3[2,1] = cube2[2,2];
			cube2[2,2] = temp;

			rotate2DTYellow();
		}
	}

	private string[,] white  , FSWhite  , whiteB;
	private string[,] red    , FSRed    , redB;
	private string[,] blue   , FSBlue   , blueB;
	private string[,] orange , FSOrange , orangeB;
	private string[,] green  , FSGreen  , greenB;
	private string[,] yellow , FSYellow , yellowB;

	private void init2DTilesCube(){
		white   =	new string[3, 3]; FSWhite 	= new string[3, 3]; whiteB   = new string[3, 3];
		red     =	new string[3, 3]; FSRed 	= new string[3, 3]; redB     = new string[3, 3];
		blue    =	new string[3, 3]; FSBlue	= new string[3, 3]; blueB    = new string[3, 3];
		orange  =   new string[3, 3]; FSOrange  = new string[3, 3]; orangeB  = new string[3, 3];
		green   =	new string[3, 3]; FSGreen 	= new string[3, 3]; greenB   = new string[3, 3];
		yellow  =	new string[3, 3]; FSYellow	= new string[3, 3]; yellowB  = new string[3, 3];

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++ ) {
				white[i,j]  = FSWhite[i,j]  = "white";
				red[i,j]    = FSRed[i,j]    = "red"   ;
				blue[i,j]   = FSBlue[i,j]   = "blue"   ;
				orange[i,j] = FSOrange[i,j] = "orange";
				green[i,j]  = FSGreen[i,j]  = "green"  ;
				yellow[i,j] = FSYellow[i,j] = "yellow";
			}
		}
	}

	private void rotate2DTWhite(){

		string[] temp = new string[3];

		for (int i = 0; i < 3; i++)
			temp [i] = red [0, i]; 
		
		for (int i = 0; i < 3; i++)
			red [0, i] = blue [0, i];

		for (int i = 0; i < 3; i++)
			blue [0, i] = orange [0, i];

		for (int i = 0; i < 3; i++)
			orange [0, i] = green [0, i];

		for (int i = 0; i < 3; i++)
			green [0, i] = temp [i];

		temp[0] = white[0,0];
		white[0,0] = white[2,0];
		white[2,0] = white[2,2];
		white[2,2] = white[0,2];
		white[0,2] = temp[0];
		
		temp[0] = white[0,1];
		white[0,1] = white[1,0];
		white[1,0] = white[2,1];
		white[2,1] = white[1,2];
		white[1,2] = temp[0];
	}

	private void rotate2DTYellow(){
		string[] temp = new string[3];
		for (int i = 0; i < 3; i++)
			temp [i] = orange [2, i]; 
		
		for (int i = 0; i < 3; i++)
			orange [2, i] = blue [2, i];
		
		for (int i = 0; i < 3; i++)
			blue [2, i] = red [2, i];
		
		for (int i = 0; i < 3; i++)
			red [2, i] = green [2, i];
		
		for (int i = 0; i < 3; i++)
			green [2, i] = temp [i];
		
		temp[0] = yellow[0,0];
		yellow[0,0] = yellow[2,0];
		yellow[2,0] = yellow[2,2];
		yellow[2,2] = yellow[0,2];
		yellow[0,2] = temp[0];
		
		temp[0] = yellow[0,1];
		yellow[0,1] = yellow[1,0];
		yellow[1,0] = yellow[2,1];
		yellow[2,1] = yellow[1,2];
		yellow[1,2] = temp[0];
	}

	private void rotate2DTRed(){
		string[] temp = new string[3];
		for (int i = 0; i < 3; i++)
			temp [i] = yellow [0, i];
		
		for (int i = 0; i < 3; i++)
			yellow [0, i] = blue [2 - i, 0];
		
		for (int i = 0; i < 3; i++)
			blue [2 - i, 0] = white [2, 2 - i];
		
		for (int i = 0; i < 3; i++)
			white [2, 2 - i] = green [i, 2];
		
		for (int i = 0; i < 3; i++)
			green [i, 2] = temp [i];
		
		
		temp[0] = red[0,0];
		red[0,0] = red[2,0];
		red[2,0] = red[2,2];
		red[2,2] = red[0,2];
		red[0,2] = temp[0];
		
		temp[0] = red[0,1];
		red[0,1] = red[1,0];
		red[1,0] = red[2,1];
		red[2,1] = red[1,2];
		red[1,2] = temp[0];
	}

	private void rotate2DTOrange(){
		string[] temp = new string[3];
		for (int i = 0; i < 3; i++)
			temp [i] = yellow [2, i];
		
		for (int i = 0; i < 3; i++)
			yellow [2, i] = green [i , 0];
		
		for (int i = 0; i < 3; i++)
			green [i, 0] = white [0, 2 - i];
		
		for (int i = 0; i < 3; i++)
			white [0, 2 - i] = blue [2 - i , 2];
		
		for (int i = 0; i < 3; i++)
			blue [2 - i, 2] = temp [i];
		
		temp[0] = orange[0,0];
		orange[0,0] = orange[2,0];
		orange[2,0] = orange[2,2];
		orange[2,2] = orange[0,2];
		orange[0,2] = temp[0];
		
		temp[0] = orange[0,1];
		orange[0,1] = orange[1,0];
		orange[1,0] = orange[2,1];
		orange[2,1] = orange[1,2];
		orange[1,2] = temp[0];
	}

	private void rotate2DTBlue(){
		string[] temp = new string[3];
		for (int i = 0; i < 3; i++)
			temp [i] = yellow [i, 2];
		
		for (int i = 0; i < 3; i++)
			yellow [i, 2] = orange [2 - i, 0];
		
		for (int i = 0; i < 3; i++)
			orange [2 - i, 0] = white [i, 2];
		
		for (int i = 0; i < 3; i++)
			white [i, 2] = red [i, 2];
		
		for (int i = 0; i < 3; i++)
			red [i, 2] = temp [i];
		
		
		temp[0] = blue[0,0];
		blue[0,0] = blue[2,0];
		blue[2,0] = blue[2,2];
		blue[2,2] = blue[0,2];
		blue[0,2] = temp[0];
		
		temp[0] = blue[0,1];
		blue[0,1] = blue[1,0];
		blue[1,0] = blue[2,1];
		blue[2,1] = blue[1,2];
		blue[1,2] = temp[0];
	}

	private void rotate2DTGreen(){
		string[] temp = new string[3];
		for (int i = 0; i < 3; i++)
			temp [i] = yellow [i, 0];
		
		for (int i = 0; i < 3; i++)
			yellow [i, 0] = red [i, 0];
		
		for (int i = 0; i < 3; i++)
			red [i, 0] = white [i, 0];
		
		for (int i = 0; i < 3; i++)
			white [i, 0] = orange [2 - i, 2];
		
		for (int i = 0; i < 3; i++)
			orange [2 - i, 2] = temp [i];
		
		temp[0] = green[0,0];
		green[0,0] = green[2,0];
		green[2,0] = green[2,2];
		green[2,2] = green[0,2];
		green[0,2] = temp[0];
		
		temp[0] = green[0,1];
		green[0,1] = green[1,0];
		green[1,0] = green[2,1];
		green[2,1] = green[1,2];
		green[1,2] = temp[0];
	}

	public string[,] GetWhiteFaceTiles(){ 
		return white;
	}

	public string[,] GetRedFaceTiles(){
		return red;
	}

	public string[,] GetYellowFaceTiles(){
		return yellow;
	}

	public string[,] GetOrangeFaceTiles(){
		return orange;
	}

	public string[,] GetBlueFaceTiles(){
		return blue;
	}

	public string[,] GetGreenFaceTiles(){
		return green;
	}

	public bool isSolved(){
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++){
				if(orange[i,j] != FSOrange[i,j]){
					return false;
				}else if(green[i,j] != FSGreen[i,j]){
					return false;
				}else if(white[i,j] != FSWhite[i,j]){
					return false;
				}else if(blue[i,j] != FSBlue[i,j]){
					return false;
				}else if(red[i,j] != FSRed[i,j]){
					return false;
				}else if(yellow[i,j] != FSYellow[i,j]){
					return false;
				}
			}
		}
		return true;
	}

	public int solveCube(){

		for (int i = 0; i < 3; i++) {
			for(int j = 0; j < 3;j++){
				cubeA[i,j] = cube1[i,j];
				cubeB[i,j] = cube2[i,j];
				cubeC[i,j] = cube3[i,j];

				whiteB[i,j]  = white[i,j];
				redB[i,j]    = red[i,j];
				blueB[i,j]   = blue[i,j];
				orangeB[i,j] = orange[i,j];
				greenB[i,j]  = green[i,j];
				yellowB[i,j] = yellow[i,j];
			}
		}
		solveCross ();
		solveF2L ();
		solveOLL ();
		solvePLL ();

		for (int i = 0; i < 3; i++) {
			for(int j = 0; j < 3;j++){
				cube1[i,j] = cubeA[i,j];
				cube2[i,j] = cubeB[i,j];
				cube3[i,j] = cubeC[i,j];

				white[i,j]  = whiteB[i,j];
				red[i,j]    = redB[i,j];
				blue[i,j]   = blueB[i,j];
				orange[i,j] = orangeB[i,j];
				green[i,j]  = greenB[i,j];
				yellow[i,j] = yellowB[i,j];
			}
		}

		return moveList.Count;
	}

	public List<string> edgeSolveCubies = new List<string>();
	public List<string> moveList = new List<string>();

	private void solveCross(){

		if (cube2 [0, 2] != "Edge Piece 1") {
			edgeSolveCubies.Add ("Edge Piece 1");
		} else {
			if (white [1, 2] != "white" && blue [0, 1] != "blue") {
				edgeSolveCubies.Add ("Edge Piece 1");
			}
		}
		if (cube2 [0, 0] != "Edge Piece 5") {
			edgeSolveCubies.Add ("Edge Piece 5");
		} else {
			if (white[1,0] != "white" && green[0 , 1] != "green")
				edgeSolveCubies.Add ("Edge Piece 5");
		}
		if (cube3 [0, 1] != "Edge Piece 9") {
			edgeSolveCubies.Add ("Edge Piece 9");
		} else {
			if (white[0,1] != "white" && orange[0 , 1] != "orange")
				edgeSolveCubies.Add ("Edge Piece 9");
		}

		if (cube1 [0, 1] != "Edge Piece 12") {
			edgeSolveCubies.Add ("Edge Piece 12");
		} else {
			if (white [2, 1] != "white" && red[0 , 1] != "red")
				edgeSolveCubies.Add ("Edge Piece 12");
		}

		while (edgeSolveCubies.Count > 0) {
			string piece = edgeSolveCubies[0];
			edgeSolveCubies.RemoveAt(0);

			string arrName = "";
			int x = -1 , y = -1;
			bool flag = false;
			for(int i = 0;i < 3;i++){
				for(int j = 0;j < 3;j++){
					if(cube1[i,j] == piece){
						x = i; y = j;
						arrName = "cube1";
						flag = true;
						break;
					}else if(cube2[i,j] == piece){
						x = i; y = j;
						arrName = "cube2";
						flag = true;
						break;
					}else if(cube3[i,j] == piece){
						x = i; y = j;
						arrName = "cube3";
						flag = true;
						break;
					}
				}
				if(flag) break;
			}

			if(arrName == "cube1"){
				if(x == 0 && y == 1){ 
					if(red[0,1] == "white"){
						moveList.Add("F"); Rotate(3);
						moveList.Add("-R"); Rotate(0); Rotate(0); Rotate(0);
						moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
						moveList.Add("R"); Rotate(0);

					}else{
						moveList.Add("F"); Rotate(3);
						moveList.Add("F"); Rotate(3);
					}

				}else if(x == 1 && y == 0){
					
					if(red[1,0] == "white"){
						moveList.Add("L"); Rotate(2);
						moveList.Add("D"); Rotate(4);
						moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
					}else{
						moveList.Add("-F"); Rotate(3);Rotate(3);Rotate(3);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
						moveList.Add("F");Rotate(3);
						moveList.Add("D");Rotate(4);
						

					}
				}else if(x == 2 && y == 1){
					// check yellow/red faces (already down but check white tile position)

					if(red[2,1] == "white"){
						moveList.Add("F");Rotate(3);
						moveList.Add("L"); Rotate(2);
						moveList.Add("D");Rotate(4);
						moveList.Add("D");Rotate(4);
						moveList.Add("-L"); Rotate(2); Rotate(2); Rotate(2);
						moveList.Add("-F");Rotate(3); Rotate(3);Rotate(3);
						moveList.Add("-D");Rotate(4);Rotate(4);Rotate(4);
					}else{

					}

				}else if(x == 1 && y == 2){
					// check blue/red faces and take it down
					if(red[1 , 2] == "white"){
						moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
						moveList.Add("R");Rotate(0);
					}else{
						moveList.Add("F");Rotate(3);
						moveList.Add("D");Rotate(4);
						moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					}
				}
			}else if(arrName == "cube2"){

				if(x == 0 && y == 0){ 
					if(green[0 , 1] == "white"){
						moveList.Add("L");Rotate(2);
						moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
						moveList.Add("F");Rotate(3);
						moveList.Add("D"); Rotate(4);



					}else{
						moveList.Add("L");Rotate(2);
						moveList.Add("L");Rotate(2);
						moveList.Add("D"); Rotate(4);



					}
				}else if(x == 0 && y == 2){
					if(blue[0 , 1] == "white"){
						moveList.Add("-R");Rotate(0);Rotate(0);Rotate(0);
						moveList.Add("F");Rotate(3);
						moveList.Add("D"); Rotate(4);
						moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);



					}else{
						moveList.Add("R");Rotate(0);
						moveList.Add("R");Rotate(0);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);



					}
				}else if(x == 2 && y == 0){
					if(green[2 , 1] == "white"){
						moveList.Add("-L");Rotate(2);Rotate(2);Rotate(2);
						moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
						moveList.Add("F");Rotate(3);
						moveList.Add("D"); Rotate(4);
						moveList.Add("L");Rotate(2);

				

					}else{
						moveList.Add("D"); Rotate(4);

					

					}	
				}else if(x == 2 && y == 2){
					if(blue[2 , 1] == "white"){
						moveList.Add("R");Rotate(0);
						moveList.Add("F");Rotate(3);
						moveList.Add("D"); Rotate(4);
						moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
						moveList.Add("-R");Rotate(0);Rotate(0);Rotate(0);



					}else{
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);

					

					}	
				}
			}else if(arrName == "cube3"){
				if(x == 0 && y == 1){ 
					if(orange[0 , 1] == "white"){
						moveList.Add("B");Rotate(1);
						moveList.Add("-L");Rotate(2);Rotate(2);Rotate(2);
						moveList.Add("D"); Rotate(4);
						moveList.Add("L");Rotate(2);
					}else{
						moveList.Add("B");Rotate(1);
						moveList.Add("B");Rotate(1);
						moveList.Add("D"); Rotate(4);
						moveList.Add("D"); Rotate(4);
					}
				}else if(x == 1 && y == 0){
					if(orange[1 , 2] == "white"){
						moveList.Add("-L");Rotate(2);Rotate(2);Rotate(2);
						moveList.Add("D"); Rotate(4);
						moveList.Add("L");Rotate(2);
					}else{
						moveList.Add("B");Rotate(1);
						moveList.Add("D"); Rotate(4);
						moveList.Add("D"); Rotate(4);
						moveList.Add("-B");Rotate(1);Rotate(1);Rotate(1);
					}
					
				}else if(x == 2 && y == 1){
					if(orange[2 , 1] == "white"){
						moveList.Add("-B");Rotate(1);Rotate(1);Rotate(1);
						moveList.Add("-L");Rotate(2);Rotate(2);Rotate(2);
						moveList.Add("D"); Rotate(4);
						moveList.Add("L");Rotate(2);
						moveList.Add("B");Rotate(1);
					}else{
						moveList.Add("D"); Rotate(4);
						moveList.Add("D"); Rotate(4);
					}
					
				}else if(x == 1 && y == 2){
					if(orange[1 , 0] == "white"){
						moveList.Add("R");Rotate(0);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
						moveList.Add("-R");Rotate(0);Rotate(0);Rotate(0);
					}else{
						moveList.Add("-B");Rotate(1);Rotate(1);Rotate(1);
						moveList.Add("D"); Rotate(4);
						moveList.Add("D"); Rotate(4);
						moveList.Add("B");Rotate(1);
					}
				}
			}
			solveRYEdge();
		}	
	}

	private void solveRYEdge(){

		if(red [2 , 1] != "red"){
			if(red [2 , 1] == "blue"){
				moveList.Add("D"); Rotate(4);
				moveList.Add("R"); Rotate(0);
				moveList.Add("R"); Rotate(0);
			}else if(red [2 , 1] == "orange"){
				moveList.Add("D"); Rotate(4);
				moveList.Add("D"); Rotate(4);
				moveList.Add("B"); Rotate(1);
				moveList.Add("B"); Rotate(1);
			}else if(red [2 , 1] == "green"){
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("L"); Rotate(2);
				moveList.Add("L"); Rotate(2);
			}
		}else{
			moveList.Add("F"); Rotate(3);
			moveList.Add("F"); Rotate(3);
		}
	}


	public List<string> cornerSolveCubies = new List<string>();

	private void solveF2L(){

		if (cube3 [0, 2] != "Corner Piece 1") {
			cornerSolveCubies.Add ("Corner Piece 1");
		} else {
			if (white [0, 2] != "white" && blue [0, 2] != "blue" && orange[0,0] != "orange") {
				cornerSolveCubies.Add ("Corner Piece 1");
			}
		}

		if (cube1 [0, 2] != "Corner Piece 2") {
			cornerSolveCubies.Add ("Corner Piece 2");
		} else {
			if (white [2, 2] != "white" && red [0, 2] != "red" && blue[0,0] != "blue") {
				cornerSolveCubies.Add ("Corner Piece 2");
			}
		}

		if (cube3 [0, 0] != "Corner Piece 5") {
			cornerSolveCubies.Add ("Corner Piece 5");
		} else {
			if (white [0, 0] != "white" && orange [0, 2] != "orange" && green[0,0] != "green") {
				cornerSolveCubies.Add ("Corner Piece 5");
			}
		}

		if (cube1 [0, 0] != "Corner Piece 7") {
			cornerSolveCubies.Add ("Corner Piece 7");
		} else {

			if ((white [2, 0] != "white") && (green [0, 2] != "green") && (red[0,0] != "red")) {
				cornerSolveCubies.Add ("Corner Piece 7");
			}
		}
			
		while (cornerSolveCubies.Count > 0) {
			string piece = cornerSolveCubies[0];
			cornerSolveCubies.RemoveAt(0);
			string arrName = "";
			int x = -1, y = -1;
			bool flag = false;
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					if (cube1 [i, j] == piece) {
						x = i;
						y = j;
						arrName = "cube1";
						flag = true;
						break;
					} else if (cube2 [i, j] == piece) {
						x = i;
						y = j;
						arrName = "cube2";
						flag = true;
						break;
					} else if (cube3 [i, j] == piece) {
						x = i;
						y = j;
						arrName = "cube3";
						flag = true;
						break;
					}
				}
				if (flag)
					break;
			}

			if(arrName == "cube1"){
				if(x == 0 && y == 0){
					moveList.Add("L"); Rotate(2);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);

				}else if(x == 0 && y == 2){
					moveList.Add("F");Rotate(3);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);

				}else if(x == 2 && y == 0){
					moveList.Add("D"); Rotate(4);
				}
			}else if(arrName == "cube3"){
				if(x == 0 && y == 0){
					moveList.Add("B"); Rotate(1);
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);

				}else if(x == 0 && y == 2){
					moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("B"); Rotate(1);
				}else if(x == 2 && y == 0){
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);

				}else if(x == 2 && y == 2){
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				}
			}

			if(piece == "Corner Piece 1"){
				moveList.Add("D"); Rotate(4);
				if(orange[2,0] == "white"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("R"); Rotate(0);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);

				}else if(blue[2,2] == "white"){
					moveList.Add("R"); Rotate(0);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);

				}else if(yellow[2,2] == "white"){
					moveList.Add("R"); Rotate(0);
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("R"); Rotate(0);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
				}
			}else if(piece == "Corner Piece 2"){

				if(red[2,2] == "white"){
					moveList.Add("F");Rotate(3);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
				}else if(blue[2,0] == "white"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("F");Rotate(3);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
				}else if(yellow[0,2] == "white"){
					moveList.Add("F");Rotate(3);
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("F");Rotate(3);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
				}
			}else if(piece == "Corner Piece 5"){
				moveList.Add("D"); Rotate(4);
				moveList.Add("D"); Rotate(4);

				if(green[2,0] == "white"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("B"); Rotate(1);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);

				}else if(orange[2,2] == "white"){
					moveList.Add("B"); Rotate(1);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);


				}else if(yellow[2,0] == "white"){
					moveList.Add("B"); Rotate(1);
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("B"); Rotate(1);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
				}
			}else if(piece == "Corner Piece 7"){
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);

				if(red[2,0] == "white"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("L"); Rotate(2);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);

				}else if(green[2,2] == "white"){
					moveList.Add("L"); Rotate(2);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);

				}else if(yellow[0,0] == "white"){
					moveList.Add("L"); Rotate(2);
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					moveList.Add("L"); Rotate(2);
					moveList.Add("D"); Rotate(4);
					moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
				}
			}
		}
			
		if (cube3 [1, 2] != "Edge Piece 3") {
			edgeSolveCubies.Add ("Edge Piece 3");

		} else {
			if(blue[1,2] != "blue" && orange[1,0] != "orange"){
				moveList.Add("D"); Rotate(4);
				moveList.Add("R"); Rotate(0);
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);

				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
				moveList.Add("D"); Rotate(4);
				moveList.Add("B"); Rotate(1);

				moveList.Add("D"); Rotate(4);
				moveList.Add("D"); Rotate(4);
				
				moveList.Add("D"); Rotate(4);
				moveList.Add("R"); Rotate(0);
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);

				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
				moveList.Add("D"); Rotate(4);
				moveList.Add("B"); Rotate(1);
			}
		}

		if (cube1 [1, 2] != "Edge Piece 4") {
			edgeSolveCubies.Add ("Edge Piece 4");
		} else {
			if(red[1,2] != "red" && blue[1,0] != "blue"){

				edgeRBInsertion(false);

				moveList.Add("D"); Rotate(4);
				moveList.Add("D"); Rotate(4);

				edgeRBInsertion(false);
			}
		}

		if (cube1 [1, 0] != "Edge Piece 7") {
			edgeSolveCubies.Add ("Edge Piece 7");

		} else {
			if(green[1,2] != "green" && red[1,0] != "red"){
				moveList.Add("D"); Rotate(4);
				moveList.Add("L"); Rotate(2);
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
				
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
				moveList.Add("D"); Rotate(4);
				moveList.Add("F");Rotate(3);

				moveList.Add("D"); Rotate(4);
				moveList.Add("D"); Rotate(4);
				
				moveList.Add("D"); Rotate(4);
				moveList.Add("L"); Rotate(2);
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
				
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
				moveList.Add("D"); Rotate(4);
				moveList.Add("F");Rotate(3);
			}
		}

		if (cube3 [1, 0] != "Edge Piece 8") {
			edgeSolveCubies.Add ("Edge Piece 8");

		} else {
			if(orange[1,2] != "orange" && green[1,0] != "green"){
				moveList.Add("D"); Rotate(4);
				moveList.Add("B"); Rotate(1);
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);

				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
				moveList.Add("D"); Rotate(4);
				moveList.Add("L"); Rotate(2);

				moveList.Add("D"); Rotate(4);
				moveList.Add("D"); Rotate(4);
				
				moveList.Add("D"); Rotate(4);
				moveList.Add("B"); Rotate(1);
				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);

				moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
				moveList.Add("D"); Rotate(4);
				moveList.Add("L"); Rotate(2);
			}
		}

		while (edgeSolveCubies.Count > 0) {
			string piece = edgeSolveCubies[0];
			edgeSolveCubies.RemoveAt(0);

			string arrName = "";
			int x = -1, y = -1;
			if(cube1[2,1] == piece){
				x = 2; y = 1;
				arrName = "cube1";
			}else if(cube1[1,0] == piece){
				x = 1; y = 0;
				arrName = "cube1";
			}else if(cube1[1,2] == piece){
				x = 1; y = 2;
				arrName = "cube1";
			}else if(cube2[2,2] == piece){
				x = 2; y = 2;
				arrName = "cube2";
			}else if(cube2[2,0] == piece){
				x = 2; y = 0;
				arrName = "cube2";
			}else if(cube3[2,1] == piece){
				x = 2; y = 1;
				arrName = "cube3";
			}else if(cube3[1,0] == piece){
				x = 1; y = 0;
				arrName = "cube3";
			}else if(cube3[1,2] == piece){
				x = 1; y = 2;
				arrName = "cube3";
			}

			if(arrName == "cube1"){
				if(x == 1){
					if(y == 0){
						edgeGRInsertion(true);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					}else if(y == 2){
						edgeRBInsertion(false);
						moveList.Add("D"); Rotate(4);
					}
				}

				if(red[2,1] == "red"){
					// cubie is at the right position.
				}else if(red[2,1] == "blue"){
					moveList.Add("D"); Rotate(4);
				}else if(red[2,1] == "green"){
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				}else if(red[2,1] == "orange"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
				}
			} else if(arrName == "cube2"){
				if(x == 2 && y == 0){
					if(green[2,1] == "red"){
						moveList.Add("D"); Rotate(4);
					}else if(green[2,1] == "blue"){
						moveList.Add("D"); Rotate(4);
						moveList.Add("D"); Rotate(4);
					}else if(green[2,1] == "green"){
						//the cubie is at the correct position
					}else if(green[2,1] == "orange"){
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					}
				}else if(x == 2 && y == 2){
					if(blue[2,1] == "red"){
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					}else if(blue[2,1] == "blue"){
						//the cubie is at the correct position
					}else if(blue[2,1] == "green"){
						moveList.Add("D"); Rotate(4);
						moveList.Add("D"); Rotate(4);
					}else if(blue[2,1] == "orange"){
						moveList.Add("D"); Rotate(4);
					}
				}
			} else if(arrName == "cube3"){
				if(x == 1){
					if(y == 0){
						edgeOGInsertion(false);
						moveList.Add("D"); Rotate(4);

					}else if(y == 2){
						
						edgeBOInsertion(true);
						moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					}
				}

				if(orange[2,1] == "red"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
				}else if(orange[2,1] == "blue"){
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
				}else if(orange[2,1] == "green"){
					moveList.Add("D"); Rotate(4);
				}else if(orange[2,1] == "orange"){
					//the cubie at the correct position
				}
			}

			if(piece == "Edge Piece 3"){
				if(cube3[2,1] == piece){
					edgeBOInsertion(false);
				}else if(cube2[2,2] == piece){
					edgeBOInsertion(true);
				}
			}else if(piece == "Edge Piece 4"){
				if(cube1[2,1] == piece){
					edgeRBInsertion(true);
				}else if(cube2[2,2] == piece){
					edgeRBInsertion(false);
				}
			}else if(piece == "Edge Piece 7"){
				if(cube1[2,1] == piece){
					edgeGRInsertion(false);
				}else if(cube2[2,0] == piece){
					edgeGRInsertion(true);
				}
			}else if(piece == "Edge Piece 8"){
				if(cube3[2,1] == piece){
					edgeOGInsertion(true);
				}else if(cube2[2,0] == piece){
					edgeOGInsertion(false);
				}
			}
		}
	}

	private void edgeRBInsertion(bool reverse){
		if (!reverse) {
			moveList.Add("D"); Rotate(4);
			moveList.Add("F");Rotate(3);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
			
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
			moveList.Add("D"); Rotate(4);
			moveList.Add("R"); Rotate(0);

		} else {
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
			moveList.Add("D"); Rotate(4);
			moveList.Add("R"); Rotate(0);

			moveList.Add("D"); Rotate(4);
			moveList.Add("F");Rotate(3);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
		}
	}

	private void edgeBOInsertion(bool reverse){
		if (!reverse) {
			moveList.Add("D"); Rotate(4);
			moveList.Add("R"); Rotate(0);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);

			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
			moveList.Add("D"); Rotate(4);
			moveList.Add("B"); Rotate(1);
		} else {
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
			moveList.Add("D"); Rotate(4);
			moveList.Add("B"); Rotate(1);

			moveList.Add("D"); Rotate(4);
			moveList.Add("R"); Rotate(0);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
		}
	}

	private void edgeOGInsertion(bool reverse){
		if (!reverse) {
			moveList.Add("D"); Rotate(4);
			moveList.Add("B"); Rotate(1);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);

			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
			moveList.Add("D"); Rotate(4);
			moveList.Add("L"); Rotate(2);
		} else {
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
			moveList.Add("D"); Rotate(4);
			moveList.Add("L"); Rotate(2);

			moveList.Add("D"); Rotate(4);
			moveList.Add("B"); Rotate(1);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-B"); Rotate(1);Rotate(1);Rotate(1);
		}
	}

	private void edgeGRInsertion(bool reverse){
		if (!reverse) {
			moveList.Add("D"); Rotate(4);
			moveList.Add("L"); Rotate(2);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);

			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
			moveList.Add("D"); Rotate(4);
			moveList.Add("F");Rotate(3);
		} else {
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
			moveList.Add("D"); Rotate(4);
			moveList.Add("F");Rotate(3);

			moveList.Add("D"); Rotate(4);
			moveList.Add("L"); Rotate(2);
			moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
			moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
		}
	}


	private void solveOLL(){

		int yellowCount = 0;

		if (yellow [0, 1] == "yellow" && yellow [1, 0] == "yellow" && yellow [2, 1] == "yellow" && yellow [1, 2] == "yellow") {
			// the yellow cross is already made. Nothing needs to be done.
		} else {
			
			if(yellow [0, 1] == "yellow") ++yellowCount;
			if(yellow [1, 0] == "yellow") ++yellowCount;
			if(yellow [2, 1] == "yellow") ++yellowCount;
			if(yellow [1, 2] == "yellow") ++yellowCount;

			if(yellowCount > 1){
				if(yellow [0, 1] == "yellow" && yellow [2, 1] == "yellow"){
					yellowCrossEdgeAlgo();
				}else if( yellow [1, 0] == "yellow" && yellow [1, 2] == "yellow"){
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
				}else if(yellow [0, 1] == "yellow" && yellow [1, 0] == "yellow"){
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
				}else if(yellow [2, 1] == "yellow" && yellow [1, 0] == "yellow"){
					moveList.Add("D"); Rotate(4);
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
				}else if(yellow [2, 1] == "yellow" && yellow [1, 2] == "yellow"){
					moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
					yellowCrossEdgeAlgo();
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
				}else if(yellow [0, 1] == "yellow" && yellow [1, 2] == "yellow"){
					yellowCrossEdgeAlgo();
					moveList.Add("D"); Rotate(4);
					yellowCrossEdgeAlgo();
				}
			}else{
				yellowCrossEdgeAlgo();
				yellowCrossEdgeAlgo();
				moveList.Add("D"); Rotate(4);
				yellowCrossEdgeAlgo();
			}
		}

        yellowCount = 0;
        string y = "yellow";

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (yellow[i, j] == y)
                    yellowCount++;
		
        if (yellowCount == 5) {
            
			if (red[2, 0] == y && red[2, 2] == y && orange[2, 0] == y && orange[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                yellowCrossCornerAlgo1();
			} else if (green[2, 0] == y && green[2, 2] == y && blue[2, 0] == y && blue[2, 2] == y) {
                yellowCrossCornerAlgo1();
                yellowCrossCornerAlgo1();
			}
			else if (red[2, 0] == y && red[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
            } else if (blue[2, 0] == y && blue[2, 2] == y) {
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
            } else if (orange[2, 0] == y && orange[2, 2] == y) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
            } else if (green[2, 0] == y && green[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
            }
        } else if (yellowCount == 6) {
            if (blue[2, 0] == y && orange[2, 0] == y && green[2, 0] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
            } else if (red[2, 0] == y && orange[2, 0] == y && green[2, 0] == y) {
                yellowCrossCornerAlgo1();
            } else if (blue[2, 0] == y && red[2, 0] == y && green[2, 0] == y) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
            } else if (blue[2, 0] == y && orange[2, 0] == y && red[2, 0] == y) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
            }
            else if (blue[2, 2] == y && orange[2, 2] == y && green[2, 2] == y) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo2();
            } else if (red[2, 2] == y && orange[2, 2] == y && green[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo2();
            } else if (blue[2, 2] == y && orange[2, 2] == y && red[2, 2] == y) {
                yellowCrossCornerAlgo2();
            } else if (blue[2, 2] == y && red[2, 2] == y && green[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo2();
            }

        } else if (yellowCount == 7) {
            if (red[2, 0] == y && red[2, 2] == y) {
                yellowCrossCornerAlgo1();
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo2();
            } else if (blue[2, 0] == y && blue[2, 2] == y) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo2();
            } else if (orange[2, 0] == y && orange[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo2();
            } else if (green[2, 0] == y && green[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo2();
            }
			else if (red[2, 2] == y && orange[2, 0] == y) {
                yellowCrossCornerAlgo1();
                yellowCrossCornerAlgo2();
            } else if (blue[2, 2] == y && green[2, 0] == y) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
                yellowCrossCornerAlgo2();
            } else if (red[2, 0] == y && orange[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                yellowCrossCornerAlgo2();
            } else if (blue[2, 0] == y && green[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                yellowCrossCornerAlgo2();
            }
            else if (red[2, 2] == y && green[2, 0] == y) {
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo2();
            } else if (red[2, 0] == y && blue[2, 2] == y) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo2();

            } else if (blue[2, 0] == y && orange[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo2();

            } else if (orange[2, 0] == y && green[2, 2] == y) {
                moveList.Add("D"); Rotate(4);
                yellowCrossCornerAlgo1();
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                yellowCrossCornerAlgo2();
            }
        }
	}

	private void yellowCrossEdgeAlgo(){
		moveList.Add("R"); Rotate(0);
		moveList.Add("F");Rotate(3);
		moveList.Add("D"); Rotate(4);
		moveList.Add("-F");Rotate(3);Rotate(3);Rotate(3);
		moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
		moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
	}

	private void yellowCrossCornerAlgo1(){
		moveList.Add("L"); Rotate(2);
		moveList.Add("D"); Rotate(4);
		moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
		moveList.Add("D"); Rotate(4);
		moveList.Add("L"); Rotate(2);
		moveList.Add("D"); Rotate(4);
		moveList.Add("D"); Rotate(4);
		moveList.Add("-L"); Rotate(2);Rotate(2);Rotate(2);
	}

	private void yellowCrossCornerAlgo2(){
		moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
		moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
		moveList.Add("R"); Rotate(0);
		moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
		moveList.Add("-R"); Rotate(0);Rotate(0);Rotate(0);
		moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
		moveList.Add("-D"); Rotate(4);Rotate(4);Rotate(4);
		moveList.Add("R"); Rotate(0);
	}

	private void solvePLL(){
		if (red[2, 0] != red[2, 2] && blue[2, 0] != blue[2, 2] && orange[2, 0] != orange[2, 2] && green[2, 0] != green[2, 2]) {
            if (cube1[2, 0] == "Corner Piece 4") {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
            } else if (cube1[2, 2] == "Corner Piece 4") {
                moveList.Add("D"); Rotate(4);
            } else if (cube3[0, 2] == "Corner Piece 4") {
                //correct
            } else if (cube3[2, 2] == "Corner Piece 4") {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
            }
            cornerPermutationAlgorithm();
        }

       	if(red[2, 0] == red[2, 2] && blue[2, 0] != blue[2, 2]){
            moveList.Add("D"); Rotate(4);
            moveList.Add("D"); Rotate(4);
            cornerPermutationAlgorithm();
        } else if (blue[2, 0] == blue[2, 2] && orange[2, 0] != orange[2, 2]) {
            moveList.Add("D"); Rotate(4);
            cornerPermutationAlgorithm();
        } else if (orange[2, 0] == orange[2, 2] && green[2, 0] != green[2, 2]) {
            //correct
            cornerPermutationAlgorithm();
        } else if (green[2, 0] == green[2, 2] && red[2, 0] != red[2, 2]) {
            moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
            cornerPermutationAlgorithm();
        }

        if (red[2, 0] == red[2, 2] && red[2,0] != red[2,1] &&
            blue[2, 0] == blue[2, 2] && blue[2, 0] != blue[2, 1] &&
            orange[2, 0] == orange[2, 2] && orange[2, 0] != orange[2, 1] &&
            green[2, 0] == green[2, 2] && green[2,0] != green[2,1]) { 
			edgePermutationAlgorithm1();
        }
        
        if (red[2, 0] == red[2, 2] && red[2, 0] == red[2, 1] &&
            blue[2, 0] == blue[2, 2] && blue[2, 0] == blue[2, 1] &&
            orange[2, 0] == orange[2, 2] && orange[2, 0] == orange[2, 1] &&
            green[2, 0] == green[2, 2] && green[2, 0] == green[2, 1]) {
            finalTurn();
        } else {
            if (red[2, 0] == red[2, 1] && red[2, 0] == red[2, 2]) {
                moveList.Add("D"); Rotate(4);
                moveList.Add("D"); Rotate(4);
                if (red[2, 1] == blue[2, 0]) {
                    edgePermutationAlgorithm1();
                } else {
                    edgePermutationAlgorithm2();
                }
            } else if (blue[2, 0] == blue[2, 1] && blue[2, 0] == blue[2, 2]) {
                moveList.Add("D"); Rotate(4);
                
                if (red[2, 1] == blue[2, 0]) {
                    edgePermutationAlgorithm1();
                } else {
                    edgePermutationAlgorithm2();
                }
            } else if (orange[2, 0] == orange[2, 1] && orange[2, 0] == orange[2, 2]) {
                
                if (red[2, 1] == blue[2, 0]) {
                    edgePermutationAlgorithm1();
                } else {
                    edgePermutationAlgorithm2();
                }
            } else if (green[2, 0] == green[2, 1] && green[2, 0] == green[2, 2]) {
                moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
                if (red[2, 1] == blue[2, 0]) {
                    edgePermutationAlgorithm1();
                } else {
                    edgePermutationAlgorithm2();
                }
            }
        }
        
		finalTurn();
	}

    private void finalTurn() {
        if (red[2, 1] == "red") {
            //correct position (solved)
        } else if (red[2, 1] == "blue") {
            moveList.Add("D"); Rotate(4);
        } else if (red[2, 1] == "orange") {
            moveList.Add("D"); Rotate(4);
            moveList.Add("D"); Rotate(4);
        } else if (red[2, 1] == "green") {
            moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
        }
    }

    private void cornerPermutationAlgorithm() {
        moveList.Add("-L"); Rotate(2); Rotate(2); Rotate(2);
        moveList.Add("F"); Rotate(3);
        moveList.Add("-L"); Rotate(2); Rotate(2); Rotate(2);
        moveList.Add("B"); Rotate(1);
        moveList.Add("B"); Rotate(1);
        moveList.Add("L"); Rotate(2);
        moveList.Add("-F"); Rotate(3); Rotate(3); Rotate(3);
        moveList.Add("-L"); Rotate(2); Rotate(2); Rotate(2);
        moveList.Add("B"); Rotate(1);
        moveList.Add("B"); Rotate(1);
        moveList.Add("L"); Rotate(2);
        moveList.Add("L"); Rotate(2);
    }

    
    private void edgePermutationAlgorithm1() {
        moveList.Add("F"); Rotate(3);
        moveList.Add("F"); Rotate(3);
        moveList.Add("D"); Rotate(4);
        moveList.Add("R"); Rotate(0);
        moveList.Add("-L"); Rotate(2); Rotate(2); Rotate(2);
        moveList.Add("F"); Rotate(3);
        moveList.Add("F"); Rotate(3);
        moveList.Add("-R"); Rotate(0); Rotate(0); Rotate(0);
        moveList.Add("L"); Rotate(2);
        moveList.Add("D"); Rotate(4);
        moveList.Add("F"); Rotate(3);
        moveList.Add("F"); Rotate(3);
    }

    
    private void edgePermutationAlgorithm2() {
        moveList.Add("F"); Rotate(3);
        moveList.Add("F"); Rotate(3);
        moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
        moveList.Add("R"); Rotate(0);
        moveList.Add("-L"); Rotate(2); Rotate(2); Rotate(2);
        moveList.Add("F"); Rotate(3);
        moveList.Add("F"); Rotate(3);
        moveList.Add("-R"); Rotate(0); Rotate(0); Rotate(0);
        moveList.Add("L"); Rotate(2);
        moveList.Add("-D"); Rotate(4); Rotate(4); Rotate(4);
        moveList.Add("F"); Rotate(3);
        moveList.Add("F"); Rotate(3);
    }
}

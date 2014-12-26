using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public Transform BrickPrefab = null;
	public int GridWidth = 16;
	public int GridHeight = 20;
	private bool[,] Grid = null;

	int GetGridWidth()
	{
		return Grid.GetLength (0);
	}

	int GetGridHeight()
	{
		return Grid.GetLength (1);
	}

	void CreateBrick(int x,int y)
	{
		Grid [x, y] = true;
		Transform Brick = (Transform)Instantiate(BrickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		Brick.parent = GameObject.Find ("World").transform;
		var Script = Brick.GetComponent<TestAnimate>();
		Script.Init ( x, y, GetGridWidth (), GetGridHeight() );
	}

	// Use this for initialization
	void Start () {

		//	turn off offscreen (editor time) stuff
		GameObject.Find ("OffScreen").SetActive (false);

		Grid = new bool[GridWidth, GridHeight];

		CreateBrick (0, 0);
		CreateBrick (1, 1);
		CreateBrick (2, 2);
		CreateBrick (3, 3);
		CreateBrick (4, 4);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

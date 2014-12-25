using UnityEngine;
using System.Collections;

public class TestAnimate : MonoBehaviour {

	public int GridX = 0;
	public int GridY = 0;
	private float Timer = 10.0f;

	public void Init(int x,int y,int Width,int Height)
	{
		GridX = x;
		GridY = y;
		this.renderer.material.SetInt("_GridX", GridX);
		this.renderer.material.SetInt("_GridY", GridY);
		this.renderer.material.SetInt("_GridWidth", Width);
		this.renderer.material.SetInt("_GridHeight", Height);
	}

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		Timer -= 1.0f;
		if (Timer < 0.0f) {
			Timer += 10.0f;
			GridX ++;
		}
		this.renderer.material.SetInt("_GridX", GridX);
		this.renderer.material.SetInt("_GridY", GridY);
	}
}

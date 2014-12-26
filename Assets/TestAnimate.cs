using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
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
		Bounds InfBounds = new Bounds(Vector3.zero, Vector3.one * float.MaxValue);
		gameObject.GetComponent<MeshFilter> ().mesh.bounds = InfBounds;
	}


	// Update is called once per frame
	void Update () {
		if ( !Application.isPlaying()) )
			return;

		Timer -= 1.0f;
		if (Timer < 0.0f) {
			Timer += 10.0f;
			GridX ++;
		}
		this.renderer.material.SetInt("_GridX", GridX);
		this.renderer.material.SetInt("_GridY", GridY);
	}
}

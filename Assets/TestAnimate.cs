using UnityEngine;
using System.Collections;

public class TestAnimate : MonoBehaviour {

	private float GridX = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GridX += 0.01f;
		int GridXi = (int)GridX;
		Debug.Log (GridXi);
		this.renderer.material.SetFloat("_GridX", GridXi);
	}
}

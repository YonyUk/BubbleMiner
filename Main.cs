using UnityEngine;
using System.Collections;
using Generators;

public class Main : MonoBehaviour {

	Generator generator;
	public int rows;
	public int cols;
	public int iterations;
	public int types;
	public float probability;
	// Use this for initialization
	void Start () {
		generator = new Generator (rows, cols, types, iterations,probability);
		generator.Generate ();
		PrintMap ();
	}
	void PrintMap(){
		for (int i = 0; i < rows; i++) {
			string row = "";
			for (int j = 0; j < cols; j++)
				row += generator.Map[i,j] + " ";
			Debug.Log(row);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}

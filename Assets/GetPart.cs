using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPart : MonoBehaviour
{
	public static GameObject pivot0;
	public static GameObject pivot1;

	public static GameObject target_pivot;
	public GameObject[] pivots = new GameObject[] {pivot0, pivot1};

    public static GameObject articulation0;
    public static GameObject articulation1;
    public static GameObject articulation2;

    public static GameObject target_art;
    public GameObject[] articulations = new GameObject[] {articulation0, articulation1}; 

    public static GameObject part0;
	public static GameObject part1;

	public int counter = 0;
	public static GameObject target;
    public GameObject[] parts = new GameObject[] {part0, part1};
    // Start is called before the first frame update
    void Start() {

		target_art = articulations[0];

    	target = parts[0];
    }


    // Update is called once per frame
    void Update() {

    	if (Input.GetKeyUp(KeyCode.A)) {
			if(counter < parts.Length-1) {
				counter += 1;
			}
			else {
				counter = 0;
			}
			target_art = articulations[counter];
			target = parts[counter];
		}

		if (Input.GetKey(KeyCode.Z)) {
			target.transform.RotateAround(target_art.transform.position, Vector3.right, -40 * Time.deltaTime);
			for(int i=counter+1; i < parts.Length; i++) { //GameObject articulation in articulations.Take(counter+1:)
				pivots[i].transform.position = Vector3.MoveTowards(pivots[i].transform.position, articulations[i].transform.position, 1);
			}
		}

		if (Input.GetKey(KeyCode.S)) {
			target.transform.RotateAround(target_art.transform.position, Vector3.right, 40 * Time.deltaTime);
			for(int i=counter+1; i < parts.Length; i++) { //GameObject articulation in articulations.Take(counter+1:)
				pivots[i].transform.position = Vector3.MoveTowards(pivots[i].transform.position, articulations[i].transform.position, 1);
			}
		}
		//articulation2.transform.position = transform.position;
    }
}

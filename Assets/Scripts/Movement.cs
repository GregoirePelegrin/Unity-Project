using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public List<GameObject> Parties = new List<GameObject>();
	private int currentIndex;
	public GameObject articulationCourante;


    void Start()
    {
    	this.currentIndex = 0;
    }

    void Update()
    {
    	this.articulationCourante = this.Parties[currentIndex];
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
			this.currentIndex ++;
			if(this.currentIndex == this.Parties.Capacity){
				this.currentIndex = 0;
			}
		} else if(Input.GetKeyDown(KeyCode.KeypadMinus)){
			this.currentIndex --;
			if(this.currentIndex == -1){
				this.currentIndex = this.Parties.Capacity - 1;
			}
		} else if(Input.GetKey(KeyCode.LeftArrow)){
			change(-Time.deltaTime);
		} else if(Input.GetKey(KeyCode.RightArrow)){
			change(Time.deltaTime);
		}
    }

    void change(float delta){
    	Pivot p = this.articulationCourante.GetComponent<Pivot>();
		if(p != null){
			p.move(delta);
		} else {
			this.articulationCourante.GetComponent<Glissiere>().move(delta);
		}
    }

    float degToRad(float _deg){
    	return _deg / 360 * (Mathf.PI * 2);
    }

    float radToDeg(float _rad){
    	return _rad / (2 * Mathf.PI) * 360;
    }
}

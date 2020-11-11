using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glissiere : ArticulationClass
{
	public GameObject arm;
	private Global global;
	private Movement movement;
	public int longueurSegment;
	private float translationIncrement;
	public GameObject prec;

    public bool x;
    public bool y;
    public bool z;

    void Start(){
    	this.arm = this.transform.parent.gameObject;
    	this.global = this.arm.GetComponent<Global>();
    	this.movement = this.arm.GetComponent<Movement>();
		this.longueurSegment = this.global.longueurSegment;
		this.translationIncrement = this.global.translationIncrement;

		List<GameObject> list = this.movement.Parties;
		for(int i=0; i<list.Capacity; i++){
			if(this.gameObject == list[i]){
				if(i == 0){
					this.prec = GameObject.Find("Origine");
					break;
				} else {
					this.prec = list[i-1];
					break;
				}
			}
		}
    }

    public override void move(float delta){
    	Debug.Log("GlissiereUpdate");
    }
}

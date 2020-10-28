using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Calculation : MonoBehaviour
{

	int[,] identity = new int[,] { {1,0,0,0}, {0,1,0,0}, {0,0,1,0}, {0,0,0,1}};
	float[,] position = new float[,] { {1,0,0,0}, {0,1,0,1}, {0,0,1,0}, {0,0,0,1} };
	public GameObject part0;


    void Start()
    {
    	part0.transform.position = new Vector3(position[0,3],position[1,3],position[2,3]);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
        	// X axis rotation transformation matrice
        	float angle = (30 * Mathf.PI)/180;
        	float[,] T01 = new float[,] { {1,0,0,0}, {0,Mathf.Cos(angle),-Mathf.Sin(angle),0}, {0,Mathf.Sin(angle),Mathf.Cos(angle),0}, {0,0,0,1}};

        	float[,] T00 = new float[4,4];
        	float temp = 0;
        	for(int i = 0; i < position.GetLength(0); i++) {
				for(int j = 0; j < position.GetLength(1); j++) {
					temp = 0;
                    for (int k = 0; k < 4; k++) {
                        temp += position[i, k] * T01[k, j];
                    }
                    T00[i, j] = temp;
				}
			}

        	for(int i = 0; i < position.GetLength(0); i++) {
				for(int j = 0; j < position.GetLength(1); j++) {
					position[i,j] = T00[i,j];
				}
			}

        	part0.transform.position = new Vector3(position[0,3],position[1,3],position[2,3]);
        }
    }
}

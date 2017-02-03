using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

	void Update () {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	}
}

using UnityEngine;
using System.Collections;
#pragma strict
public class DestroyByBoundary : MonoBehaviour {

		
	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}

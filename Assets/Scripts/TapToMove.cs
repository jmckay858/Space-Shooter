using UnityEngine;
using System.Collections;

public class TapToMove : MonoBehaviour {

	//flag to ceck if the user has tapped / clicked
	//Set to tru on click. reset to false on reaching a destination
	private bool flag = false;
	// destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the game object
	public float yAxis;

	void Start() {
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;
	}

	//Update is called once per frame
	void Update() {
		// check if the screen is touched / clicked
			if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || (Input.GetMouseButtonDown (0))) {
				//declare a variable of RaycastHit struct
				RaycastHit hit;
				//Create a Ray on the tapped / clicked position
				Ray ray;
				//for Unity Editor
				#if UNITY_EDITOR
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
				ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				#endif
				//Check if the ray hits any collider
				if (Physics.Raycast (ray, out hit)) {
					//set flag to indicate to move gameObject
					flag = true;
					//save the click / tap position
					endPoint = hit.point;
					//as we do not want to change the y axis value based on touch position reset it to original y axis
					endPoint.y = yAxis;
					Debug.Log (endPoint);
				}
			}
			if (flag && !Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
				gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance (gameObject.transform.position, endPoint))));
				
			} else if (flag && Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
				flag = false;
				Debug.Log ("I am Here");
			}

	}
}

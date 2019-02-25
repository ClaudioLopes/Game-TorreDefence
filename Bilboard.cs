using UnityEngine;
using System.Collections;

public class Bilboard : MonoBehaviour {

	void Update () {
		transform.rotation = Camera.main.transform.rotation;
	}
}

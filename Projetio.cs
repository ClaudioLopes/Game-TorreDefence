using UnityEngine;
using System.Collections;

public class Projetio : MonoBehaviour {

	public float velocidade = 10;
	public Transform alvo;

	void Update () {
		if (alvo != null) {
			transform.position = Vector3.MoveTowards (transform.position, alvo.FindChild ("Alvo").position, velocidade * Time.deltaTime);
			transform.LookAt (alvo.FindChild ("Alvo").position);
		} else {
			Destroy (gameObject);
		}

	}
}

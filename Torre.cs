using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject bala;
	public GameObject spawBala;
	public float coolDown = 1.0f;
	public int custo;

	GameObject alvo;
	float tempo = 0.0f;

	void Start () {
		InvokeRepeating ("BuscaAlvo", 0.0f, 0.5f);
	}

	void Update () {
		if (alvo) {
			transform.LookAt (new Vector3(alvo.transform.position.x, transform.position.y, alvo.transform.position.z));

			if (tempo >= coolDown) {
				tempo = 0.0f;
				GameObject b = (GameObject) Instantiate (bala, spawBala.transform.position, Quaternion.Euler(90,0,0));
				b.GetComponent <Projetio> ().alvo = this.alvo.transform;
			}
		}
		tempo += Time.deltaTime;
	}

	void BuscaAlvo(){
		float distanciaMaisProx = Mathf.Infinity;

		GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");

		foreach(GameObject inimigo in inimigos){
			float distancia = Vector3.Distance (transform.position, inimigo.transform.position);
			if(distanciaMaisProx > distancia){
				alvo = inimigo;
				distanciaMaisProx = distancia;
			}
		}
	}
}

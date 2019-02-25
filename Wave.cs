using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	float tempoEntreInimigos = 0.5f;
	float cronometro = 0.0f;

	public GameObject inimigo;
	public int quantidadeInimigos;

	void Update () {

		if(cronometro >= tempoEntreInimigos){
			cronometro = 0.0f;
			Instantiate (inimigo,transform.position,Quaternion.identity);
			quantidadeInimigos--;
		}
		cronometro += Time.deltaTime;

		if(quantidadeInimigos == 0){
			this.enabled = false;
		}
	}
}

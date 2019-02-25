using UnityEngine;
using System.Collections;

public class OrigemInimigos : MonoBehaviour {

	public GameObject inimigo;
	public float tempoSpawn = 5.0f;
	public int ondas = 5;
	public int qtdPorOnda = 1;
	float tempoDecorrido = 0.0f;

	void Update () {

		if(ondas > 0){

			if(tempoDecorrido >= tempoSpawn){

				Wave onda = gameObject.AddComponent <Wave> () as Wave;
				onda.inimigo = inimigo;
				onda.quantidadeInimigos = qtdPorOnda;

				tempoDecorrido = 0.0f;
				ondas--;
				qtdPorOnda++;

			}

		}

		tempoDecorrido += Time.deltaTime;
	}
}

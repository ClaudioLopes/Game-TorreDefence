using UnityEngine;
using System.Collections;

public class AddTorre : MonoBehaviour {

	public GameObject torre;

	Renderer m_renderer;
	Color corOriginal;
	GameMeneger gerenciadorDeJogo;
	ButtonMeneger gerenciadorBotoes;
	int custo;

	void Start(){
		m_renderer = GetComponent<Renderer> ();
		corOriginal = m_renderer.material.color;
		gerenciadorDeJogo = GameObject.FindGameObjectWithTag ("GameManeger").GetComponent<GameMeneger> ();
		gerenciadorBotoes = GameObject.Find ("ButtonMeneger").GetComponent<ButtonMeneger>();
		custo = torre.transform.GetChild (0).gameObject.GetComponent<Torre> ().custo;
	}

	void OnMouseDown(){
		if(gerenciadorDeJogo.dinheiro >=  custo){
			gerenciadorDeJogo.DecrementaDinheiro(custo);
			Instantiate (torre, transform.position, Quaternion.identity);
			gerenciadorBotoes.EscondeSlots ();
			Destroy (gameObject);
		}
	}

	void OnMouseOver(){
		if (gerenciadorDeJogo.dinheiro < custo) {
			m_renderer.material.color = new Color (1.0f, 0.0f, 0.0f, 0.3f);
		} else {
			m_renderer.material.color = new Color (0.0f, 1.0f, 0.0f, 0.3f);
		}
	}

	void OnMouseExit(){
		m_renderer.material.color = corOriginal;
	}
		
}

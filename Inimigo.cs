using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour {

	public int velocidade = 5;
	public int valor;
	public int dano = 1;
	public int hpMax = 3;

	GameObject caminho;
	Transform[] pontos;
	Transform pontoAtual;
	Animator animator;
	Slider barraHp;

	int indice;
	int hp;

	void Start () {
		IniciaCaminho ();
		pontoAtual = pontos[0];
		indice = 0;
		animator = GetComponent <Animator> ();
		barraHp = transform.GetComponentInChildren<Slider> ();
		barraHp.maxValue = hpMax;
		barraHp.value = hpMax;
		barraHp.minValue = 0;
		hp = hpMax;
	}

	void Update () {
		
		transform.position = Vector3.MoveTowards (transform.position, pontoAtual.position, velocidade * Time.deltaTime);
		transform.LookAt(pontoAtual.position);

		if(transform.position == pontoAtual.position){
			if (indice >= pontos.Length) {
				Destroy (gameObject);
				GameObject.FindGameObjectWithTag ("GameManeger").GetComponent<GameMeneger> ().DecrementaSaude(dano);
			} else {
				pontoAtual = pontos [indice++];
			}
		}
	}

	void IniciaCaminho (){
		caminho = GameObject.Find ("_caminho");
		int filhos = caminho.transform.childCount;
		pontos = new Transform[filhos];
		for(int i = 0; i < filhos; i++){
			pontos [i] = caminho.transform.GetChild (i);
		}
	}

	void OnTriggerEnter(Collider info){
		if (info.gameObject.tag == "bala") {
			Destroy (info.gameObject);
			hp--;
			barraHp.value = hp;
			if (hp == 0) {
				GameObject.FindGameObjectWithTag ("GameManeger").GetComponent<GameMeneger> ().IncrementaDinheiro (valor);
				animator.SetBool ("estaVivo", false);
				Invoke ("DestroiInimigo", 1.0f);
			} 
		}
	}

	void DestroiInimigo(){
		Destroy (gameObject);
	}
}

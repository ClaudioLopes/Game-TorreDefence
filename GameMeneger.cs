using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMeneger : MonoBehaviour {
	public int saudeInicial = 3;
	public int dinheiroInicial = 50;
	public int vidasInicial = 3;
	public int dinheiro = 50;
	public int vidas = 3;
	public int saude = 3;
	public Text dinheiroText;
	public Text saudeText;
	public Text vidasText;
	public static GameMeneger instancia = null;
	public GameObject slots;

	void Awake(){
		if (instancia == null) {
			instancia = this;
		} else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		inicializa ();

	}

	void inicializa(){
		slots = GameObject.Find ("_slots");
		slots.SetActive (false);
		inicializaUI ();
	}
		
	public void IncrementaDinheiro(int dinheiroRecebido){
		dinheiro += dinheiroRecebido;
		dinheiroText.text = "Dinheiro: " + dinheiro.ToString ();
	}

	public void DecrementaDinheiro(int dinheiroRecebido){
		dinheiro -= dinheiroRecebido;
		dinheiroText.text = "Dinheiro: " + dinheiro.ToString ();
	}

	public void DecrementaSaude(int dano){
		saude -= dano;
		if (saude < 0) {
			vidas = vidas - 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			Invoke ("inicializaUI", 0.1f);
			vidasText.text = "Vida: " + vidas.ToString ();
		}
		saudeText.text = "Saude: " + saude.ToString ();
	}

	void inicializaUI(){
		saude = saudeInicial;
		dinheiro = dinheiroInicial;

		vidasText = GameObject.Find ("TextVidas").GetComponent<Text>();
		saudeText = GameObject.Find ("TextSaude").GetComponent<Text>();
		dinheiroText = GameObject.Find ("TextDinheiro").GetComponent<Text>();

		vidasText.text = "Vida: " + vidas.ToString ();
		saudeText.text = "Saude: " + saudeInicial.ToString ();
		dinheiroText.text = "Dinheiro: " + dinheiroInicial.ToString ();
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour {

	public Toggle musica;

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	public void NewGame(){
		SceneManager.LoadScene ("faseTeste 1");
	}

	public void Opcoes(){
		SceneManager.LoadScene ("opcoes");
	}

	public void Sair(){
		Application.Quit ();
	}

	public void VoltarMenuPrincipal(){
		if(!musica.isOn){
			//para a musica
		}
		SceneManager.LoadScene ("menuPrincipal");
	}
}

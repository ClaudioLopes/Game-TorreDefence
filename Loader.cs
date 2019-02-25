using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject gameManeger;

	void Awake(){
		if(GameMeneger.instancia == null){
			Instantiate (gameManeger);
		}
	}
}

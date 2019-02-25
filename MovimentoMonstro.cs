using UnityEngine;
using System.Collections;

public class MovimentoMonstro : MonoBehaviour {

	public float velocidade = 3.0f;
	public Animator anim;
	bool attack = false;

	void Start () {
	
	}

	void Update () {
		attack = false;
		
		float movimento = Input.GetAxis ("Vertical");
		transform.Translate (0, 0, movimento * velocidade * Time.deltaTime);

		if (Input.GetKey ("a")) {
			attack = true;
		}

		anim.SetFloat ("movimento", movimento);
		anim.SetBool ("Attack", attack);
	}
}

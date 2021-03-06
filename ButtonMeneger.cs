using UnityEngine;
using System.Collections;

public class ButtonMeneger : MonoBehaviour {

	bool slotsAtivado = false;

	void Update(){
		if (slotsAtivado  && Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if (hit.transform.gameObject.tag == "Chao") {
					EscondeSlots ();
				}
			}
		}
	}

	public void MostaSlots(){
		GameMeneger.instancia.slots.SetActive (true);
		slotsAtivado = true;

	}

	public void EscondeSlots(){
		GameMeneger.instancia.slots.SetActive (false);
		slotsAtivado = false;
	}
}

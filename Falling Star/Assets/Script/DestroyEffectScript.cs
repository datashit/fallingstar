using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DestroyObject(this.gameObject, 5f);

    }

}

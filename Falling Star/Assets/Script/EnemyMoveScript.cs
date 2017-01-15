using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {
    
    public float Speed = -5f;
    public float Ydestroy = -7f;
    private Vector3 movePosition;
	// Update is called once per frame
	void Update () {
        movePosition.Set(0,  Speed * Time.deltaTime, 0);
        this.transform.position += movePosition; 
	}

    private void LateUpdate()
    {
        if(this.transform.position.y <= Ydestroy)
        {
            Destroy(gameObject);
        }
    }

}

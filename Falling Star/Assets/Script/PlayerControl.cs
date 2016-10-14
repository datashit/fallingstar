using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed = 3.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


#if UNITY_EDITOR
        if(Input.GetMouseButton(0))
        {
           Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;       
            this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime * speed);
        }
#else
            foreach (Touch parmak in Input.touches)
        {
                Debug.Log("parmak aktif");
                  Vector3 pos = Camera.main.ScreenToWorldPoint(parmak.position);
            pos.z = 0;
            this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime * speed); 
        }
#endif

    }
}

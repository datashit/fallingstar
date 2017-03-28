using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : BaseBehaviour{
    
    public float Speed = -5f;
    private Vector3 movePosition;

    public void Awake()
    {
        Speed = PlayerControl.Instance.VerticalSpeed;
        Observer.AddListener(PlayerControl.PlayerInfo.VERTICAL_SPEED_CHANGE , this, SpeedChange);
    }

    private void SpeedChange(ObservParam obj)
    {
        Speed = (float)obj.data;
    }

    // Update is called once per frame
    void Update () {
        movePosition.Set(0,  Speed * Time.deltaTime, 0);
        this.transform.position += movePosition; 
	}


    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : BaseBehaviour
{

    public float speed = 3.5f;
    private float rotate = 2.5f;
    private Vector3 pos;
    private GameManager gameManager;


    private bool firstPosition = false;


    // Use this for initialization
    void Start()
    {
        pos = this.transform.position;
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.PlayGame)
        {
            if (!firstPosition)
            {
                firstPosition = true;
                pos.y = -0.5f;
            }


            if (Input.GetKeyDown(KeyCode.Mouse0) && this.transform.position.y > -0.51f)
            {
                rotate *= -1;
                pos = new Vector3(rotate, pos.y);
                pos.z = 0;
                pos.x = Mathf.Clamp(pos.x, -2.35f, 2.35f);
            }
            this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime * speed);
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Enemy"):
                LostGame();
                break;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Orb"):
                OrbTrigger(collision.gameObject);
                break;
        }
    }

    private void OrbTrigger(GameObject obj)
    {
        Destroy(obj);
        OrbManager.Instance.AddOrb(1);
    }


    public void Default()
    {
        pos.x = 0;
    }
    private void LostGame()
    {
        UpdateOrbPoint();
        gameManager.Reload_Game();
        Default();
        
    }

    private void UpdateOrbPoint()
    {
        OrbManager.Instance.UpdateTotalOrb();
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : BaseBehaviour
{

    public float speed = 3.5f;
    private float rotate = 2.5f;
    private bool direction = false;
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
                pos.y = -0.5f;
            }


            if (Input.GetKeyDown(KeyCode.Mouse0) && this.transform.position.y > -0.51f)
            {
                direction = !direction; // True ise Sağ / False ise Sol
                firstPosition = true;

                pos.z = 0;
            }
            else if(this.transform.position.y < -0.51f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, pos, speed * Time.deltaTime);
                return;
            }

            if (firstPosition)
            {
                if (direction)
                {
                    pos.Set(speed * Time.deltaTime, 0, 0);
                    MovePlayer(pos);
                }
                else
                {
                    pos.Set(-speed * Time.deltaTime, 0, 0);
                    MovePlayer(pos);
                }
            }
        }
        else
        {
            firstPosition = false;
        }


    }

    private void  MovePlayer(Vector3 pos)
    {
        pos += this.transform.position;
        pos.Set(Mathf.Clamp(pos.x, -2.35f, 2.35f), pos.y, pos.z);
        this.transform.position = pos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Enemy"):
                LostGame();
                break;
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
        int lostOrbCount = OrbManager.Instance.getOrb;
        UpdateOrbPoint();
        gameManager.Lost_Game(lostOrbCount);
        Default();
        
    }

    private void UpdateOrbPoint()
    {
        OrbManager.Instance.UpdateTotalOrb();
    }

}

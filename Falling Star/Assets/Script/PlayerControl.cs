using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : BaseBehaviour
{

    public float VerticalSpeed = -5f;
    public float HorizantalSpeed = 3.5f;
    private float rotate = 2.5f;
    private bool direction = false;
    private bool DestroyEff = false;
    private Vector3 pos;
    private GameManager gameManager;
    public GameObject Skin;
    public GameObject DestroyEffect;

    


    private bool firstPosition = false;

    public enum PlayerInfo
    {
        VERTICAL_SPEED_CHANGE
    }

    public void Set_Vertical_Speed(float speed)
    {
        this.VerticalSpeed = speed;
        Observer.SendMessage(PlayerInfo.VERTICAL_SPEED_CHANGE, speed);
    }

    private static PlayerControl instance = null;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;


        DontDestroyOnLoad(instance);
    }



    public static PlayerControl Instance
    {
        get
        {
            return instance;
        }
    }
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
            if(DestroyEff)
            {
                DestroyEff = false;
                Hide();
                Instantiate(DestroyEffect, this.transform);    
            }
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
                this.transform.position = Vector3.Lerp(this.transform.position, pos, HorizantalSpeed * Time.deltaTime);
                return;
            }

            if (firstPosition)
            {
                if (direction)
                {
                    pos.Set(HorizantalSpeed * Time.deltaTime, 0, 0);
                    MovePlayer(pos);
                }
                else
                {
                    pos.Set(-HorizantalSpeed * Time.deltaTime, 0, 0);
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
                DestroyEff = true;
                Invoke("LostGame",4);
                break;
            case ("Orb"):
                OrbTrigger(collision.gameObject);
                break;
        }
    }

    void Visible(bool val)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = val;
        Skin.active = val;
    }

    void Hide()
    {
        Visible(false);

    }

    void Show()
    {
        Visible(true);
    }
    private void OrbTrigger(GameObject obj)
    {
        obj.SetActive(false);
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
        Show();
        
    }

    private void UpdateOrbPoint()
    {
        OrbManager.Instance.UpdateTotalOrb();
    }

}

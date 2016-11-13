using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : BaseBehaviour
{

    public float speed = 3.5f;
    private float rotate = 2.5f;
    private Vector3 pos;
    private GameManager gameManager;
    private uint OrbPointCounter = 0;
    private int OrbPoint;

    private bool firstPosition = false;

    public enum PlayerInfo
    {
        ORB_SCORE_CHANGE,
        TOTAL_ORB_SCORE_CHANGE
    }

    public void Awake()
    {
        OrbPoint = PlayerPrefs.GetInt("OrbPoint", 0);
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
        OrbPointCounter++;
        SetScoreText(OrbPointCounter);
        Debug.Log(OrbPointCounter);


    }
    private void SetScoreText(uint Score)
    {
        Observer.SendMessage(PlayerInfo.ORB_SCORE_CHANGE, Score);
    }

    public void Default()
    {
        pos.x = 0;
    }
    private void LostGame()
    {
        gameManager.Reload_Game();
        Default();
        UpdateOrbPoint();
    }

    private void UpdateOrbPoint()
    {
        OrbPoint += (int)OrbPointCounter;
        PlayerPrefs.SetInt("OrbPoint", OrbPoint);
        Observer.SendMessage(PlayerInfo.TOTAL_ORB_SCORE_CHANGE, OrbPoint);
        OrbPointCounter = 0;
        SetScoreText(OrbPointCounter);
    }
}

using UnityEngine;
using System.Collections;

public class ShipChangeSprite : MonoBehaviour {

    public Sprite[] ShipSprite;

	// Use this for initialization
	void Awake () {

        RandomShipColor();

    }

    void RandomShipColor()
    {
        if(ShipSprite != null)
        {
            int shipIndex = Random.Range(0, ShipSprite.Length );
            this.GetComponent<SpriteRenderer>().sprite = ShipSprite[shipIndex];
        }
        

    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    int speedFactor = 15;
    float maxSpeed = 6.0f;
    float animationRate = 1.0f / 10.0f;

    private float counter;
    private int animationCounter;
    private int sizeValue;
    Rigidbody2D rigidBody;
    Sprite[] sprites;

	// Use this for initialization
	void Start () {
        counter = 0;
        animationCounter = 0;
        sizeValue = 0;
        rigidBody = this.GetComponent<Rigidbody2D>();
        sprites = Resources.LoadAll<Sprite>("Assets/Animation/Player_sheet");

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * maxSpeed * Time.deltaTime, 0, 0));
        counter += Time.deltaTime;

        /* Moving right */
        if (Input.GetAxisRaw("Horizontal") > 0) {
            if (counter > animationRate) {
                counter = 0f;
                animationCounter = (animationCounter + 1) % 8;
                ChangeSprite(animationCounter);
            }
        }
        /* Moving left */
        else if (Input.GetAxisRaw("Horizontal") < 0) {
            
        }
        /* Standing still */
        else if (Input.GetAxisRaw("Horizontal") == 0) {

        }
	}

    private void ChangeSprite(int i) {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }
}

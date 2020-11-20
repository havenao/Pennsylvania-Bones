using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteDown;
    public Sprite spriteUp;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Right
        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            ChangeSprite(spriteRight);
            //this.transform.parent.GetComponent<ObjectSpawner>().playerX += 1;
        }
        //Left
        else if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            ChangeSprite(spriteLeft);
            //this.transform.parent.GetComponent<ObjectSpawner>().playerX -= 1;
        }
        //Down
        else if (Input.GetAxisRaw("Vertical") == -1f)
        {
            ChangeSprite(spriteDown);
            //this.transform.parent.GetComponent<ObjectSpawner>().playerY -= 1;
        }
        //Right
        else if (Input.GetAxisRaw("Vertical") == 1f)
        {
            ChangeSprite(spriteUp);
            //this.transform.parent.GetComponent<ObjectSpawner>().playerY += 1;
        }
    }
    void ChangeSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
    }
}


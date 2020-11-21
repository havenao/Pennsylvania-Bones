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
        }
        //Left
        else if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            ChangeSprite(spriteLeft);
        }
        //Down
        else if (Input.GetAxisRaw("Vertical") == -1f)
        {
            ChangeSprite(spriteDown);
        }
        //Right
        else if (Input.GetAxisRaw("Vertical") == 1f)
        {
            ChangeSprite(spriteUp);
        }
    }
    void ChangeSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool atExit = false;
    //private Level level;




    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //pull player to move point
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //Collision Check
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                //Collision Check
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }

        if (atExit)
        {
            if (Input.GetAxisRaw("Vertical") == -1f)
            {
                FindObjectOfType<GameManager>().playerWon = true;
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        if(gameObject.GetComponent<Status>().health <= 0)
        {
            FindObjectOfType<GameManager>().playerWon = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    //Collision will reset grid space to available, destroy object. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Level level = GameObject.Find("Level(Clone)").GetComponent<Level>();

        if (collision.gameObject.CompareTag("Flame"))
        {
            //Reset flame's grid space to empty
            level.objectGrid[collision.gameObject.GetComponent<Flame>().x, collision.gameObject.GetComponent<Flame>().y] = 0;
            Destroy(collision.gameObject);

            anim.Play("Burn", -1, 0f);
            gameObject.GetComponent<Status>().TakeDamage();
        }

        if (collision.gameObject.CompareTag("Stairs"))
        {
            Destroy(level.gameObject);
            GameObject.Find("LevelManager").GetComponent<LevelManager>().NewLevel();
        }

        if (collision.gameObject.CompareTag("FireAxe"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Artifact"))
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<Status>().GetArtifact();
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            if(gameObject.GetComponent<Status>().health < 5)
            {
                gameObject.GetComponent<Status>().HealDamage();
                Destroy(collision.gameObject);
            }
        }


        if (collision.gameObject.CompareTag("Exit"))
        {
            atExit = true;
            System.Console.WriteLine("At Exit");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            atExit = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    private Level grids;

    


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
    }

    //Collision will reset grid space to available, destroy object, change player color 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flame"))
        {
            grids = GetComponent<Level>();
            grids.objectGrid[collision.gameObject.GetComponent<Flame>().x, collision.gameObject.GetComponent<Flame>().y] = 0;
            Destroy(collision.gameObject);

            anim.Play("Burn", -1, 0f);
            this.GetComponent<Status>().health -= 1;
           
        }

        if (collision.gameObject.CompareTag("Stairs"))
        {
            grids = GetComponent<Level>();
            grids.objectGrid[collision.gameObject.GetComponent<Stairs>().x, collision.gameObject.GetComponent<Stairs>().y] = 0;
            Destroy(collision.gameObject);

            this.GetComponent<Status>().level += 1;
        }
    }

}

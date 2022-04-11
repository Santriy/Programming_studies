using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this code is a bit of a mess, but it's basically a player controller script with animation controls and other things that I was testing on.


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public string[] TagList = { "Floor", "Platform" };

    public Rigidbody2D movementRig;
    public float speed;
    public float runSpeedMultiplier;

    public bool collidedWithCutsceneTrigger;
    public static bool disableControls;
    public bool controlsDisabled;

    public bool jumpPressed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private BoxCollider2D boxCollider2d;

    private List<Collider2D> _touchingColliders = new List<Collider2D>();

    private SpriteRenderer pSprite;
    private Animator myAnimator;
    public float x;
    public bool movementAnimOn = true;
    public static bool facingLeft = false;
    public bool rotationLocked = false;

    //public float distToPushableObject;
    //public float minPushDistance;




    private Vector2 spawnPoint;
    public static float storedYPos;

    public static bool cameraFollowArea;

    public GameObject fallDetector;

    public GameObject healthBar;

    public GameObject animationRig;

    public GameObject water;



    private void Awake()
    {
        movementRig = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        fallDetector = GameObject.FindGameObjectWithTag("FallDetector");
        water = GameObject.FindGameObjectWithTag("Water");
        myAnimator = animationRig.GetComponent<Animator>();
    }

    void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        water.transform.position = new Vector2(transform.position.x, water.transform.position.y);

        x = Input.GetAxis("Horizontal");

        controlsDisabled = disableControls;

        if (disableControls)
        {
            myAnimator.SetFloat("X", 0);
        }
        

        if (movementRig.velocity.y < 0)
        {
            movementRig.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (movementRig.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            movementRig.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Casting ray");
            CastRay();
        }





        if (!disableControls)
        {
            if (!Input.GetKey(KeyCode.W))
            {
                myAnimator.SetBool("LookingUp", false);
            }
            else
            {
                myAnimator.SetBool("LookingUp", true);
            }

            if (!Input.GetKey(KeyCode.S))
            {
                myAnimator.SetBool("LookingDown", false);
            }
            else
            {
                myAnimator.SetBool("LookingDown", true);
            }

            //if (PushedObject() != null)
            //{
                
            //    distToPushableObject = Vector2.Distance(transform.position, PushedObject().transform.position);

            //    if (distToPushableObject <= minPushDistance)
            //    {
            //        if (Input.GetKey(KeyCode.E))
            //        {
            //            rotationLocked = true;
            //            Pushing();
            //        }
            //        else if (!Input.GetKey(KeyCode.E))
            //        {
            //            rotationLocked = false;
            //            PushedObject().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //            PushedObject().transform.parent = null;
            //        }
            //    }
            //    else
            //    {
            //        PushedObject().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //    }
            //}

        }
        else
        {
            //myAnimator.SetFloat("X", 0);
        }


        //grounded = _touchingColliders.Count > 0;

        if (movementAnimOn && !disableControls)
        {
            if (!disableControls)
            {
                float x = Input.GetAxis("Horizontal");
                if (Input.GetButton("Vertical"))
                {
                    myAnimator.SetFloat("X", 0);
                }
                else
                {
                    myAnimator.SetFloat("X", x);
                }
            }



            if (!rotationLocked)
            {
                if (x > 0)
                {
                    TurnRight();
                }

                else if (x < 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0); //Turns player left
                    facingLeft = true;
                }
                else
                {
                    return;
                }
            }

        }

 
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        water.transform.position = new Vector2(transform.position.x, water.transform.position.y);
    }

    void FixedUpdate()
    {




        if (!disableControls)
        {
            if (Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Running();
                }
                else
                {
                    Walking();
                }
            }
            else
            {
                x = 0f;
            }

            if (Input.GetButton("Jump") && grounded())
            {
                Jump();
            }
        }



        if (grounded())
        {
            storedYPos = transform.position.y;
        }
    }


    public void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Debug.Log("Clicked " + hit.collider.gameObject.name);

            if (hit.collider.tag == "Charon")
            {
 
                DialogueTrigger.clicked = true;
            }
        }
    }

    private bool grounded()
    {
        float extraHeightText = .5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText));
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    //public GameObject PushedObject()
    //{
    //    GameObject[] gos;
    //    gos = GameObject.FindGameObjectsWithTag("Pushable");
    //    GameObject closest = null;
    //    float distance = Mathf.Infinity;
    //    Vector3 position = transform.position;
    //    foreach (GameObject go in gos)
    //    {
    //        Vector3 diff = go.transform.position - position;
    //        float curDistance = diff.sqrMagnitude;
    //        if (curDistance < distance)
    //        {
    //            closest = go;
    //            distance = curDistance;
    //        }
    //    }
    //    return closest;
    //}

    //void Pushing()
    //{
    //    PushedObject().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    //    PushedObject().transform.parent = gameObject.transform;
    //}

    void Walking()
    {
        float moveBy = x * speed;
        movementRig.velocity = new Vector2(moveBy, movementRig.velocity.y);
    }

    void Running()
    {
        float moveBy = x * speed * runSpeedMultiplier;
        movementRig.velocity = new Vector2(moveBy, movementRig.velocity.y);
    }

    void TurnRight()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0); //Turns player right
        facingLeft = false;
    }

    void Respawn()
    {
        transform.position = spawnPoint;
    }

    void Checkpoint()
    {
        spawnPoint = new Vector2(transform.position.x, storedYPos);
        Debug.Log("Checkpoint!");
    }

    void TakeDamage()
    {
        healthBar.GetComponent<HealthController>().DealDamage();
        Debug.Log("Took Damage");
        Respawn();
    }

    void Jump()
    {
        movementRig = GetComponent<Rigidbody2D>();
        movementRig.velocity = new Vector2(movementRig.velocity.x, jumpForce);
        //grounded = false;
    }

    public void WalkRight()
    {
        disableControls = true;
        x = 1f;
        float moveBy = x * speed;
        movementRig.velocity = new Vector2(moveBy, movementRig.velocity.y);
        myAnimator.SetFloat("X", x);
    }

    public void Stop()
    {
        disableControls = false;
        x = 0f;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Hazard")
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CutsceneTrigger")
        {
            collidedWithCutsceneTrigger = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "FollowArea")
        {
            cameraFollowArea = true;
        }
        else if (collision.tag == "SteadyArea")
        {
            cameraFollowArea = false;
        }
        else if (collision.tag == "FallDetector")
        {
            TakeDamage();
            Respawn();
        }
        else if (collision.tag == "Checkpoint")
        {
            Checkpoint();
        }

    }

    //    private void OnCollisionExit2D(Collision2D collision)
    //    {
    //        foreach (string TagToTest in TagList)
    //        {
    //            if (collision.collider.tag == TagToTest)
    //            {
    //                _touchingColliders.Remove(collision.collider);
    //                if (collision.collider.tag == "Platform")
    //                {
    //                    transform.parent = null;

    //                }
    //            }
    //        }
    //    }
}



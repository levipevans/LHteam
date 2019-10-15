using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    //Config variables
    [SerializeField] float speed = 1;               // \
    [SerializeField] float attack = 1;              //  \
    [SerializeField] float attackSpeed = 100;       //   } Self Explanitory variables
    [SerializeField] float attackRange = 1;         //  /
    [SerializeField] float healthPoints = 5;        // /

    float startingHP;
    
    unit colUnit;                                   // Making the collision unit accessible throughout the class
    int i=0;
    //State
    Vector3 moveVector;                             // Making the movement vector (x,y,z) accessible
    Rigidbody2D rb;                                 // Making The physics body accessible
    SpriteRenderer SpriteR;
    Color originalColor;
    Color healthColor;
    bool mouseEntered = false;

    void Start()
    {
        startingHP = 5;
        SpriteR = GetComponent<SpriteRenderer>();
        originalColor = SpriteR.color;
        rb = GetComponent<Rigidbody2D>();           // set the rigidbody equal to that game object this script is attached to
        moveVector = new Vector3 (speed, 0f, 0f);   // change moveVectors x-value in order to get horizontal movement
    }

    // Update is called once per frame
    void Update()
    {
        HealthColorUpdate();
        NoHealthTheDie();
        rb.velocity = moveVector;                   // move at speed units horizontaly
        attackEnemy();                              // call method attackEnemy
    }

    private void HealthColorUpdate()
    {
        healthColor = new Color(Mathf.Clamp01((startingHP - healthPoints) / startingHP), Mathf.Clamp01(healthPoints / startingHP), 0.1f);
        if (mouseEntered == true)
        {
            SpriteR.color = healthColor;
        }
        else
        {
            SpriteR.color = originalColor;
        }
    }

    private void NoHealthTheDie()
    {
        // If this game object loses all its health then destroy the game object and make it inactive (inactive to avoid latency between when it is dead and when it is destroyed)
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void attackEnemy()
    {
        if (colUnit)                                // if colUnit is equal to anything
        {
            if (i >= attackSpeed)                   // if you have waited for attack speed length
            {
                colUnit.healthPoints -= attack;     // remove attack from enemy health
                i = 0;                              // reset waiting time
            }
            else
            {
                i++;                                // increment wait
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gameObject.tag == col.gameObject.tag)    // if this object and the object it collided with have the same tag (player or enemy) then do nothing
        {

        }
        else
        {
            colUnit = col.gameObject.GetComponent<unit>(); // otherwise set colUnit to the unit script on the object we collided with
        }
        
    }

    private void OnMouseEnter()
    {
        mouseEntered = true;
    }
    private void OnMouseExit()
    {
        mouseEntered = false;
    }
}

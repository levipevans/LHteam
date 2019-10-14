using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float attack = 1;
    [SerializeField] float attackSpeed = 100;
    [SerializeField] float attackRange = 1;
    [SerializeField] float healthPoints = 5;
    // Start is called before the first frame update
    unit colUnit;
    int i=0;
    //State
    Vector3 moveVector;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVector = new Vector3 (speed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
        rb.velocity = moveVector;
        attackEnemy();
    }

    private void attackEnemy()
    {
        if (colUnit)
        {
            if (i >= attackSpeed)
            {
                colUnit.healthPoints -= attack;
                i = 0;
            }
            else
            {
                i++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gameObject.tag == col.gameObject.tag)
        {

        }
        else
        {
            colUnit = col.gameObject.GetComponent<unit>();
        }
        
    }
}

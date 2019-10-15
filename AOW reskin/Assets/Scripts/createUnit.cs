using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createUnit : MonoBehaviour
{
    //static
    static float timer;                                                                                                         //static to make the delay constant accrosed all unit instances
    //config
    [SerializeField] GameObject unit;
    [SerializeField] GameObject unitHolder;
    [SerializeField] Vector3 Vector;
    [SerializeField] GameObject loader;
    [SerializeField] float waitTime = 300;
    // Start is called before the first frame update
    void Start()
    {
        //Check the tag and check the age: is it the correct unit type?
    }

    private void Update()
    {
        timer++;
        loader.transform.localScale = new Vector3(Mathf.Clamp((timer / waitTime)*2,0,2), loader.transform.localScale.y);        // visualize delay
    }

    public void instantiateUnit()
    {
        if(timer >= waitTime)
        {
            timer = 0;
            Instantiate(unit, Vector, new Quaternion(0f, 0f, 0f, 0f), unitHolder.transform);                                    //if the delay is over create clone of unit prefab at starting position
        }
        
    }
}

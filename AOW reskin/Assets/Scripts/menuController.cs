using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{
    //config
    [SerializeField] GameObject  Menu;            //add a menuController object as a variable
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hideShowMenu()
    {
        Menu.SetActive(!Menu.activeInHierarchy);        // toggle the menu between hidden and visible
    }
}

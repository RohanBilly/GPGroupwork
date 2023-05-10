using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool open;
    private bool moving;
    private int steps;

    
    private void Start()
    {
       
        moving = false;
        steps = 0;
        
    }

    
    private void FixedUpdate()
    {
        if(open == true && moving == true)
        {
            if (steps == 89)
            {
                moving = false;
                steps = 0;
            }
            transform.Rotate(0, 1, 0);
            steps = steps + 1;
        }
        if (open == false && moving == true)
        {
            if (steps == 89)
            {
                moving = false;
                steps = 0;
                
            }
            transform.Rotate(0, -1, 0);
            steps = steps + 1;
            
        }
    }

    public void Toggle()
    {
        Debug.Log(open);
        if (open == false && moving == false)
        {
            moving = true;
            open = true;
        }else if (open == true && moving == false)
        {
            moving = true;
            open = false;
        }

    }
    
}

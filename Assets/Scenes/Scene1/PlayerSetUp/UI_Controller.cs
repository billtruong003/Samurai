using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public bool leftClick = false;
    public bool rightClick = false;
    public bool runClick = false;
    public bool attackClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Left_Trigger()
    {
        leftClick = true;
    }
    public void Left_Exit()
    {
        leftClick = false;
    }
    public void Right_Trigger()
    {
        rightClick = true;
    }
    public void Right_Exit()
    {
        rightClick = false;
    }
    public void Run_Trigger()
    {
        runClick = true;
    }
    public void Run_Exit()
    {
        runClick = false;
    }
    public void Attack_Trigger()
    {
        attackClick = true;
    }
    public void Attack_Exit()
    {
        attackClick = false;
    }
}

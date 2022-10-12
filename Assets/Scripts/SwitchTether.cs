using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTether : MonoBehaviour
{
    
    public Transform newTether;
    public SwingController swing;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            swing.pendulum.SwitchTether(newTether.transform.position);
        }
    }
    
}

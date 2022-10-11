using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyer : MonoBehaviour
{
   
    private void Awake() 
    {
    var objs = GameObject.FindGameObjectsWithTag("music");
    var menu = GameObject.FindGameObjectsWithTag("pausemenu");
        if (objs.Length > 1)
    {
        Destroy(this.gameObject);
    }
        if (menu.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
    DontDestroyOnLoad(this.gameObject);
}
  
}

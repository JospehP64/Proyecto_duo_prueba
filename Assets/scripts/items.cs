using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class items : MonoBehaviour
{
    int VidaItem = 120;
    bool ItemsStartsToRott = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            ;
            
            if (i >= 500)
            {
                ItemsStartsToRott = true;
            }
            else
            {
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemsStartsToRott == true)
        {
            for (int i = 0; i < 1200; i++)
            {
                Debug.Log("tiempo de vida de objeto: " + i);
                VidaItem++;
                if (VidaItem >= 1200)
                {
                    Destroy(gameObject);
                }
                else
                {
                }
            }
        }
        
    }
}

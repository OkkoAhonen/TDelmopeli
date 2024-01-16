using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public KatsoJaAmpu katsoJaAmpu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            upgradetorni1();
        }
    }

    void upgradetorni1()
    {
        katsoJaAmpu.ampumisVali = katsoJaAmpu.ampumisVali / 2;
    }
}

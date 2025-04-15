using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject missile;
    public gameObject s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15;


    // Start is called before the first frame update
    void Start()
    {
        hpAmount = 200;
    }

    // Update is called once per frame
    void Update()
    {

        //phase 1 patern de balle spread sur la map
        if (hpAmount >= 150)
        {
            this.Phase1();
        }

        //phase 2 boss invinsible - 2 waver qui spawn
        if (hpAmount < 150 && hpAmount >= 80)
        {
            this.Phase2();
        }
        //phase 3 2 waver + rusheur
        if (hpAmount < 80 && hpAmount > 0)
        {
            this.Phase3();
        }
    }

    void Phase1() 
    {

    }
}

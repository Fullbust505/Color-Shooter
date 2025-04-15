using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
<<<<<<< Updated upstream
    public GameObject missile;
    public gameObject s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15;

=======
    public GameObject Boule;
    public GameObject Shooter;
    public GameObject s3, s8, s13;
    private float cooldownp1 = 0.8f, delai = 0.02f;
    float[] coordonnees = {-1f, -0.75f, -0.325f, 0f, 0.325f, 0.75f, 1f};
    private Vector3[] positions_top;
    private Vector3[] positions_mid;
    private Vector3[] positions_bot;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        hpAmount = 200;
        Vector3 Shooter1 = new Vector3(8f, 4f, 0f);
        Vector3 Shooter2 = new Vector3(8f, -4f, 0f);

        Instantiate(Shooter, Shooter1, this.transform.rotation);
        Instantiate(Shooter, Shooter2, this.transform.rotation);


        // Wave du haut
        positions_top = new Vector3[7];
        for (int i = 0; i < 7; i++)
        {
            positions_top[i] = new Vector3(5.8f, coordonnees[i] + 2.5f, 0);
        }

        //Wave du mid
        positions_mid = new Vector3[7];
        for (int i = 0; i < 7; i++)
        {
            positions_mid[i] = new Vector3(5.8f, coordonnees[i], 0);
        }

        //Wave du bas
        positions_bot = new Vector3[7];
        for (int i = 0; i < 7; i++)
        {
            positions_bot[i] = new Vector3(5.8f, coordonnees[i] - 2.5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    void Phase1() 
=======
    void Phase1()
    {
        cooldownp1 -= Time.deltaTime;

        if (cooldownp1 <= 0)
        {
            int chooseWave = Random.Range(1, 4);

            if (chooseWave == 1)
            {
                StartCoroutine(FireWave(positions_top));
            }
            else if (chooseWave == 2)
            {
                StartCoroutine(FireWave(positions_mid));
            }
            else if (chooseWave == 3)
            {
                StartCoroutine(FireWave(positions_bot));
            }
            
            chooseWave = Random.Range(1, 4);

            if (chooseWave == 1)
            {
                StartCoroutine(FireWave(positions_top));
            }
            else if (chooseWave == 2)
            {
                StartCoroutine(FireWave(positions_mid));
            }
            else if (chooseWave == 3)
            {
                StartCoroutine(FireWave(positions_bot));
            }

            cooldownp1 = 0.8f;
        }
    }

    IEnumerator FireWave(Vector3[] positions)
    {
        int chooseDiagonal = Random.Range(1, 3);

        if (chooseDiagonal == 1)
        {
            for (int i = 6; i >= 0; i--)
            {
                Instantiate(Boule, positions[i], this.transform.rotation);
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                Instantiate(Boule, positions[i], this.transform.rotation);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }

    void Phase2()
    {
        Debug.Log("Phase2");
    }

    void Phase3()
>>>>>>> Stashed changes
    {

    }
}

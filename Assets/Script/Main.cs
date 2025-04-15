using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject sp1, sp2, prefabjoueur1, prefabjoueur2;
    public static GameObject Joueur1, Joueur2;
    // Start is called before the first frame update
    void Start()
    {
        Joueur1 = Instantiate(prefabjoueur1, sp1.transform.position, sp1.transform.rotation);
        Joueur2 = Instantiate(prefabjoueur2, sp2.transform.position, sp2.transform.rotation);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

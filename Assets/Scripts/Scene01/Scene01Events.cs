using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01Events : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charHerald;
    public GameObject charSeaManGhost;
    //public GameObject charVictorianGhost

    public GameObject textBox;

    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(2); //How many seconds the Fadein Animation plays will be set here
        fadeScreenIn.SetActive(false);
        charHerald.SetActive(true);
        yield return new WaitForSeconds(2);

        //This is where text functions will go
        textBox.SetActive(true);


        yield return new WaitForSeconds(6);
        charSeaManGhost.SetActive(true);
    }
}

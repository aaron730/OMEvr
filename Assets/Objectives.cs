using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : ObjectiveList
{
    // Start is called before the first frame update



    public Scanner RockScanner;
    private MarsRock rock;
    public Canvas VRScreen;
    public Canvas TwoDScreen;

    private bool OlivineCollected = false;
    private bool GypsumCollected = false;
    private bool BasaltCollected = false;
    private bool GeothiteCollected = false;

    private ArrayList dialogue;


    private void Awake()
    {
        VRScreen.GetComponent<Text>().color = Color.white;
        TwoDScreen.GetComponent<Text>().color = Color.white;
    }
    public override bool CollectRocks()
    {
        if(RockScanner.GetRock().ToString() == MarsRock.RockType.Basalt.ToString())
        {
            BasaltCollected = true;
        }
        if (RockScanner.GetRock().ToString() == MarsRock.RockType.Geothite.ToString())
        {
           
            GeothiteCollected = true;

        }
        if (RockScanner.GetRock().ToString() == MarsRock.RockType.Olivine.ToString())
        {
            OlivineCollected = true;
        }
        if (RockScanner.GetRock().ToString() == MarsRock.RockType.Gypsum.ToString())
        {
            GypsumCollected = true;
        }
            throw new System.NotImplementedException();
    }

    public override bool CompletedCollectRocks()
    {
        if (BasaltCollected && GeothiteCollected && OlivineCollected && GypsumCollected)
            return true;
        else
            return false;
    }
    public override bool SayHello()
    {
        dialogue.Add("Welcome to the Orbital Mars Experience");
        dialogue.Add("To view your progress in completing objectives, please stand in front of the chalkboard!");
        StartCoroutine(displayDialogue(dialogue, 2));

        return true;
    }

    public override bool CompletedSayHello()
    {
        if (SayHello())
            return true;
        else
            return false;
    }

    public IEnumerator displayDialogue(ArrayList dialogue, int nlines)
    {
        int i = 0;
        while(i != nlines - 1)
        {
            VRScreen.GetComponent<Text>().text = dialogue[1].ToString();
            yield return new WaitForSecondsRealtime(3);
        }

        yield return null;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

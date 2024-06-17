using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagManager : MonoBehaviour
{
    public GameObject[] flagsObjects;
    private int numberOfFlagsObjects =0;
    private bool isfirstrun = false;

    private currentGameData m;
    // Start is called before the first frame update
    void Start()
    {
        numberOfFlagsObjects = flagsObjects.Length;
        m = GameObject.Find("GameDataObject").GetComponent<currentGameData>() as currentGameData;
        isfirstrun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isfirstrun) firstRun();
    }

    void firstRun(){
        AssignFlags();
        isfirstrun =false;
    }

      public Sprite getFlagSpriteIndex(int flagIndex){
        return GameData.instance.countrySetPerGame[flagIndex].flag;
    }

    public void AssignFlags(){
        int finalFlagPosition = (int)Random.Range(0,numberOfFlagsObjects);

        switch(finalFlagPosition){
            case 0 :
            flagsObjects[0].GetComponent<SpriteRenderer>().sprite = getFlagSpriteIndex(m.GetSecondFlagIndex());      
            flagsObjects[1].GetComponent<SpriteRenderer>().sprite = getFlagSpriteIndex(m.GetFirstFlagIndex());          
              break;
            case 1 :
            flagsObjects[0].GetComponent<SpriteRenderer>().sprite = getFlagSpriteIndex(m.GetFirstFlagIndex());      
            flagsObjects[1].GetComponent<SpriteRenderer>().sprite = getFlagSpriteIndex(m.GetSecondFlagIndex());    
            break;
        }
    }
}

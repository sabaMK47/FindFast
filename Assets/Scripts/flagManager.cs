using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class flagManager : MonoBehaviour
{
    public GameObject[] flagsObjects;
    public TMP_Text DisplayedText;
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
        StartCoroutine(loopRotation(90f));
        updateDisplayedText();
        isfirstrun =false;
    }

    public void loadNextGame(){
        StartCoroutine(loopRotation(90f));
        m.GetNewCountries();
        updateDisplayedText();
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

            flagsObjects[0].GetComponent<flag>().setFlagIndex(m.GetSecondFlagIndex()); 
            flagsObjects[1].GetComponent<flag>().setFlagIndex(m.GetFirstFlagIndex()); 
              break;
            case 1 :
            flagsObjects[0].GetComponent<SpriteRenderer>().sprite = getFlagSpriteIndex(m.GetFirstFlagIndex());      
            flagsObjects[1].GetComponent<SpriteRenderer>().sprite = getFlagSpriteIndex(m.GetSecondFlagIndex());    

            flagsObjects[0].GetComponent<flag>().setFlagIndex(m.GetFirstFlagIndex()); 
            flagsObjects[1].GetComponent<flag>().setFlagIndex(m.GetSecondFlagIndex()); 
            break;
        }
    }

    IEnumerator loopRotation(float angle){
        float direction = 1f;
        float rotationSpeed = 90.0f;
        float startAngle = angle;
        bool assigned = false;

        while (angle>0){
            float step = Time.deltaTime * rotationSpeed;
            flagsObjects[0].GetComponent<Transform>().Rotate(new Vector3(0,2,0)*step*direction);
            flagsObjects[1].GetComponent<Transform>().Rotate(new Vector3(0,2,0)*step*direction);

            if(angle <= (startAngle / 3) && assigned == false){
                AssignFlags();
                assigned = true;
            }
            angle -=2;
            yield return null;
        }
        flagsObjects[0].GetComponent<Transform>().rotation = Quaternion.identity;
         flagsObjects[1].GetComponent<Transform>().rotation = Quaternion.identity;


    }
    void updateDisplayedText(){
        DisplayedText.text = m.getFlagName(m.GetSecondFlagIndex());
    }
}

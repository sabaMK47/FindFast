using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentGameData : MonoBehaviour
{
    [HideInInspector]
    public int firstFlagIndex=0;
    [HideInInspector]
    public int secondFlagIndex;

    private int prevFinalFlagIndex;
    private int countriesPerGame = 14;
    private bool gameFinished = false;


    

    public void pickCountries(){
        int pickedcountryNumber = 0;

        for (int i=0;i<=GameData.instance.countryDataSet.Length;i++){
            if(pickedcountryNumber >= countriesPerGame)
            break;
            else if(GameData.instance.countryDataSet[i].guess == false){
                GameData.instance.countrySetPerGame[pickedcountryNumber] = GameData.instance.countryDataSet[i];
                pickedcountryNumber++;
            }  
        }
        if(pickedcountryNumber < countriesPerGame-1){
            for (int i=0;i<=GameData.instance.countryDataSet.Length;i++){
            if(pickedcountryNumber >= countriesPerGame)
            break;
            else if(GameData.instance.countryDataSet[i].guess == true){
                GameData.instance.countrySetPerGame[pickedcountryNumber] = GameData.instance.countryDataSet[i];
                pickedcountryNumber++;
            }  
        }
        }

    }

    public void GetNewCountries(){
        prevFinalFlagIndex = secondFlagIndex;
        if(GetNumbersOfFlagsLeft() > 0 ){
            do{
                secondFlagIndex = (int)Random.Range(0,GameData.instance.countrySetPerGame.Length);
            }while(prevFinalFlagIndex == secondFlagIndex || GameData.instance.countrySetPerGame[secondFlagIndex].guess == true) ;

             do{
                firstFlagIndex = (int)Random.Range(0,GameData.instance.countrySetPerGame.Length);
            }while(firstFlagIndex ==secondFlagIndex ) ;

            GameData.instance.countrySetPerGame[secondFlagIndex].beenQuestioned = true;}
            else{
                gameFinished = true;
            }


        }

         private int GetNumbersOfFlagsLeft(){
        int leftFlags = 0;
        for(int i =0;i<GameData.instance.countrySetPerGame.Length;i++){
            if(GameData.instance.countrySetPerGame[i].guess == false) leftFlags ++;
        }
        return leftFlags;
    }

     void Start()
    {
        GameData.instance.AssignArrayOfCountry();
        if(countriesPerGame>=GameData.instance.countryDataSet.Length){  countriesPerGame = GameData.instance.countryDataSet.Length;}
        GameData.instance.countrySetPerGame = new GameData.countrydata[countriesPerGame];
      
        gameFinished = false;
        pickCountries();
        GetNewCountries();
    }

    public void Awake(){
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetFlagNameLength(int flagIndex){
        return GameData.instance.countrySetPerGame[flagIndex].flagname.Length;

    }

    public int GetFirstFlagIndex(){
        return firstFlagIndex;
    }
    public int GetSecondFlagIndex(){
        return secondFlagIndex;
    }

    public void setGuess(){
        GameData.instance.countrySetPerGame[secondFlagIndex].guess = true;
    }

     public Sprite getFlagSpriteIndex(int flagIndex){
        return GameData.instance.countrySetPerGame[flagIndex].flag;
    }

   
}

   

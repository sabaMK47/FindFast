using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [System.Serializable]
     public struct countrydata
    {
        public string flagname;
        public Sprite flag;
        public bool guess;
        public bool beenQuestioned;
    }
  
    
    public countrydata[] countries;
    [HideInInspector]
    public countrydata[] countrySetPerGame;
    [HideInInspector]
    public countrydata[] countryDataSet;

    public static GameData instance;

    private void Awake()
    {
        if(instance == null){
            DontDestroyOnLoad(this);
            instance = this;
        }
        else{Destroy(this);}

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignArrayOfCountry()
    {
        countryDataSet = new countrydata[countries.Length];
        countries.CopyTo(countryDataSet,0);
    }

    
}

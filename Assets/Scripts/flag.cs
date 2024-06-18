using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flag : MonoBehaviour
{

    private flagManager m_flagManager;

    private bool loadnewgame = false;
    private bool buttonpressed = false;

    private currentGameData m_gameData;

    public int selectedFlagIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_flagManager = GameObject.Find("Main Camera").GetComponent<flagManager>() as flagManager;
        m_gameData = GameObject.Find("GameDataObject").GetComponent<currentGameData>() as currentGameData;
    }

    // Update is called once per frame
    void Update()
    {
        if(loadnewgame == true){
            m_flagManager.loadNextGame();
            loadnewgame = false;
        }
    }
  

   private void OnMouseDown(){
    
    if(selectedFlagIndex == m_gameData.GetSecondFlagIndex()){
        m_flagManager.loadNextGame();  
        loadnewgame = false;
    }
    else{
        SceneManager.LoadScene("loseScene");
    }
        loadnewgame = true;    

   }

   public void setFlagIndex(int index){
        selectedFlagIndex = index;
   }


}

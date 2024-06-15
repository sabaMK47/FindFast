using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void Loadscene (string gamescene){
        SceneManager.LoadScene(gamescene);
    }
}

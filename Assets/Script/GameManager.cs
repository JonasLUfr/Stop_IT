using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endUI;
    public Text endMessage;
    public static GameManager instance;
    private EnemySpawner enemySpawner;
    private bool MenuOn  = false;

    void Awake()
    {
        instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }
    public void Win()
    {   
        if(!MenuOn){
            endUI.SetActive(true);
            endMessage.text = "Victoire";
        }
        MenuOn = true;
    }

    public void Failed()
    {   
        if(!MenuOn){
            enemySpawner.Stop();
            endUI.SetActive(true);
            endMessage.text = "Echouer";
        }
        MenuOn = true;
    }


    public void OnButtonRetry()
    {
        MenuOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//obtenir la scene actuelle et reload
    }

    public void OnButtonMenu()
    {
        MenuOn = false;
        SceneManager.LoadScene(0);
    }
}

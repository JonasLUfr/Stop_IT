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

    void Awake()
    {
        instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }
    public void Win()
    { 
        endUI.SetActive(true);
        endMessage.text = "Victoire";
    }

    public void Failed()
    {
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "Echouer";

    }


    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//obtenir la scene actuelle et reload
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}

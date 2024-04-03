using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Creer un tab pour stocker les enemy vont generie
    public EnemyWave[] Enemywaves;

    //Point de commence, associer avec le cube Start sur UnityPanel
    public Transform START;
    //Pause apres chaque Wave
    public float wavesrate = 0.3f;

    //Déterminez le nombre d'ennemis présents.
    public static int CountEnemyAlive = 0;


    private Coroutine coroutine;
    //Commence génèrer des ennemis
    void Start()
    {
        coroutine = StartCoroutine(SpawnEnemy());
    }
    public void Stop() { 
        StopCoroutine(coroutine);
    }
    //Génère des ennemis avec boucle
    IEnumerator SpawnEnemy()
    {
        foreach(EnemyWave enemywave in Enemywaves)
        {
            for(int i = 0; i < enemywave.enemycount; i++ )
            {   
                // Génère des ennemis à la position START en fonction du type de enemyPrefab dans la classe EnemyWave, pas de rotation par défaut.
                GameObject.Instantiate(enemywave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++; //incrementer nb Enemy generer
                //Pause de quelques secondes après la génération
                if(i != enemywave.enemycount-1)  //Évitez d'attendre que apres le dernier soit généré. 
                    yield return new WaitForSeconds(enemywave.rate);
            }

            while(CountEnemyAlive > 0){
                //当仍有敌人存在时，暂停0帧的时间，即为暂停功能
                //Lorsqu'un ennemi est encore présent, la fonction de pause est activée pendant 0 image de temps.
                yield return 0;
            }

            yield return new WaitForSeconds(wavesrate);
        }
        //Verifier si y a encore ennemi ou pas 
        while (CountEnemyAlive > 0)
        {
            yield return 0;
        }
        GameManager.instance.Win();
    }
}

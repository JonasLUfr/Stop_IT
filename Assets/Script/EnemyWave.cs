using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//本文件存放EnemySpawner所需要的值！

[System.Serializable] //本文档所有的值均可被序列化，以便显示在Unity面板上直接调节敌人波次 Wave[] waves

//Prefab将一些能够复用的对象制作成预设体,以便下次直接调用！
//No MonoBehaviour needed, car cet Wave ne pas un Object reel! 
//Enregistre les attributs nécessaires pour chaque vague d'ennemis.
//保存每一波敌人生成所需要的属性
public class EnemyWave
{   //Appelé les préfabriqués des modèles de jeu ennemis.
    public GameObject enemyPrefab;

    //Nombre d'ennemis générés
    public int enemycount;
    //Intervalle de temps pour la génération d'ennemis.
    public float rate;

}


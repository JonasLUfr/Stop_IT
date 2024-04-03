using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //speed des Enemys
    public float speed = 10;
    public float hp = 150;
    public GameObject explosionEffect;

    //定义一个静态数组positions
    private Transform[] positions;

    //pour le UI Slider de Hp
    public Slider hpSlider;
    private float totalHP;

    //Commencer par le indice 0 dans le tab de positions
    private int index = 0;  
    // Start is called before the first frame update
    void Start()
    {
        positions = Waypoints.positions;
        totalHP = hp; //init hp
        hpSlider = GetComponentInChildren<Slider>(); //get silder automatiquement plus pratique
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        
        //避免在敌人到达最后一个位置时，下一个位置不存在的报错！
        if(index > positions.Length - 1) return;
        //得到一个方向向量，用于指示朝着positions数组中indice记录的路径点位置移动
        //positions[index].position - transform.position,即positions数组中下一个位置减去当前位置得到一个方向向量！
        //normaliser le unite
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed, Space.World);

        //判断是否到达下一个目标点位置，否则Enemy将不再移动
        //Vector3.Distance()用于判断两点之间的位置！
        if (Vector3.Distance( positions[index].position, transform.position) < 0.2f)
        {
            index++; //如果到达了下一个目标点，则Indice就该自增，然后去往数组positons中的下一个点
        }

        if (index > positions.Length - 1){
            ReachDestination();
        }
    }

    void ReachDestination()
    {
        GameManager.instance.Failed();
        //Appeler la fonction d'autodestruction dans GameObject pour détruire l'objet qui a atteint la fin.
        GameObject.Destroy(this.gameObject);

    }

    void OnDestroy(){
        //Lorsqu'un ennemi meurt, décrémentez la variable EnemySpawner pour réduire le nombre d'ennemis présents !
        EnemySpawner.CountEnemyAlive--;
    }



    //pour Bullet.cs
    public void TakeDamage(float damage) //not int anymore!
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp/totalHP;
        if(hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Instancier les Effect
        GameObject effect = GameObject.Instantiate(explosionEffect,transform.position,transform.rotation);
        Destroy(effect,0.7f); //attention il faut superier 0.8s au moins car effect duree 0.6s
        Destroy(this.gameObject);
    }
}

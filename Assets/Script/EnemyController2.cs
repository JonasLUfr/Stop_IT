using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    //speed des Enemys
    public float speed = 10;
    //定义一个静态数组positions
    private Transform[] positions;

    //Commencer par le indice 0 dans le tab de positions
    private int index = 0;  
    // Start is called before the first frame update
    void Start()
    {
        positions = Waypoints.positions;
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
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);

        //判断是否到达下一个目标点位置，否则Enemy将不再移动
        //Vector3.Distance()用于判断两点之间的位置！
        if (Vector3.Distance( positions[index].position, transform.position) < 0.2f)
        {
            index++; //如果到达了下一个目标点，则Indice就该自增，然后去往数组positons中的下一个点
        }
    }
}

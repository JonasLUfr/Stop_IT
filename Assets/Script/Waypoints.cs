using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
//定义一个静态数组positions
 public static Transform[] positions;

//唤醒每个路径点
 void Awake(){
    //获取Waypoint下每个子waypoint的坐标，并写入position数组中
    //Obtenir les coordonnées de chaque point sous Waypoint et les écrire dans le tableau de position.
    positions = new Transform[transform.childCount];
    for(int i = 0; i < positions.Length; i++)
    {
        positions[i] = transform.GetChild(i);
    }
 }
}

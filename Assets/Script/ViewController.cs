using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    //摄象机的移动速度默认为x20,每秒移动x20格子！
    //La vitesse de mouvement de la caméra est par défaut de x20, soit un déplacement de x20 carrés par seconde !
    public float Speed = 20;
    public float MouseSpeed = 620; //x620

    // Update is called once per frame
    void Update()
    {
        //capture les x et y pour le camera
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //使用鼠标滚轮放大或缩小Camera的视角，mouse控制的是Y轴
        //Utilisez la molette de la souris pour effectuer un zoom avant et arrière sur la vue de la caméra, la souris contrôle l'axe Y.
        float mouse = Input.GetAxis("Mouse ScrollWheel");

        //Debug解决为什么Y轴移动过慢????发现只有每次移动0.1
        //Déboguer pour résoudre pourquoi l'axe Y se déplace trop lentement ? Je n'ai trouvé que 0,1 par mouvement.
        //Debug.Log(mouse);

        //w,a,s,d移动camera的方式和速度,注意可以加入Space.World使得相机按照世界空间的X,Y轴移动（平移）
        //w,a,s,d la manière et la vitesse de déplacement de la caméra. Notez que Space.World peut être ajouté pour que la caméra se déplace le long de l'axe X,Y dans l'espace mondial (panoramique).
        transform.Translate(new Vector3(h*Speed ,mouse*MouseSpeed ,v*Speed) *Time.deltaTime );


    }
}

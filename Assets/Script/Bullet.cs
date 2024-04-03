using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 40;

    public GameObject explosionEffectPrefab;  //Effets d'explosion de l'ennemi
    private Transform target; //No show in Unity

    public void SetTarget(Transform _target)
    {
        this.target = _target;  //get target from scenario
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Die();
            return;
        }
        transform.LookAt(target.position); 
        //Face à la direction du cible
        transform.Translate( Vector3.forward * speed * Time.deltaTime); 
        //Face à la direction du mouvement
    }

    //Ajouter une logique de détection de déclenchement.
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<EnemyController>().TakeDamage(damage); //Dommages aux ennemis
            Die();
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation); //Explosion de l'ennemi
        Destroy (effect, 1);//Indique que l'effet dure 1 seconde puis est détruit！！
        Destroy(this.gameObject);  //autodestruction
    }
}

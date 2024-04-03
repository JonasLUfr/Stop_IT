using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<GameObject> enemys = new List<GameObject>();
    // Utilisé pour stocker les ennemis qui entrent dans la zone de détection !
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
            // Ajouter des ennemis à la liste en étiquetant chaque étiquette d'ennemi avant.
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
            // supprimer des ennemis à la liste en étiquetant chaque étiquette d'ennemi avant.
        }
    }

    //默认先攻击list中的第一个
    public float attackRateTime = 1; //Attaque une fois par seconde ! Taux d'attaque !
    private float timer = 0;

    public GameObject bulletPrefab; //bullets
    public Transform firePosition;

    //Pour buger les tetes de tour
    public Transform head;

    //Pour Verifier le type de la balle
    public bool useLaser = false;
    public float damageRate = 70; //70-damage/s
    public LineRenderer LaserRenderer; //le balle Laser

    //Lasereffect
    public GameObject LaserEffect;


    void Start()
    {
        timer = attackRateTime; //attack immdiately
    }

    void Update()
    {   
        //movement du tete de tour d'bord
        if(enemys.Count > 0 && enemys[0] != null )
        {
            Vector3 targetPosition = enemys[0].transform.position; //stocker les position des enemy
            targetPosition.y = head.position.y; //Maintenez la tête de la tourelle à la même hauteur que l'ennemi.
            head.LookAt(targetPosition);//Faites en sorte que la tête de la tourelle soit orientée vers l'ennemi.
        }
        
        if (useLaser == false){
            //si c'est pas le Laser:
            timer += Time.deltaTime;  //increment time
            if (enemys.Count > 0 && timer >= attackRateTime)
            {
                timer = 0; //coldtime **not -=attackRateTime
                Attack();
            }
        }
        else if(enemys.Count > 0){  //si on peut attacter
            //Si Laser afficher:
            if(LaserRenderer.enabled == false)
                LaserRenderer.enabled = true;
            LaserEffect.SetActive(true);
            if(enemys[0] == null)
            {
                UpdateEnemys(); 
                //Si le premier élément de la liste des ennemis est vide, mettre à jour la liste des ennemis.
            }
            if(enemys.Count > 0)
            {   //Réglage des positions de départ et d'arrivée du laser
                LaserRenderer.SetPositions(new Vector3[]{firePosition.position,enemys[0].transform.position});
                enemys[0].GetComponent<EnemyController>().TakeDamage(damageRate * Time.deltaTime);  //take damage for each fps
                LaserEffect.transform.position = enemys[0].transform.position; //ajouter l'effect du laser sur l'object enemy
                //Fixbug la direction du LaerEffect en face pas le turret
                Vector3 pos = transform.position;  //get turret position 
                pos.y = enemys[0].transform.position.y;  //sync y avec les enemys
                LaserEffect.transform.LookAt(pos);  //regarder le turret
            }
        }
        else{ //Si pas enmeys
            LaserEffect.SetActive(false);
            LaserRenderer.enabled = false;
        }
    }

    void Attack()
    {   
        //fixbug nullptr quand enemys selfdestroy
        if(enemys[0] == null)
        {
            UpdateEnemys(); 
            //Si le premier élément de la liste des ennemis est vide, mettre à jour la liste des ennemis.
        }
        if(enemys.Count > 0){
            //Aligner la direction de vol des balles avec FirePostion et get bullet!
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            //La cible du verrou est la première de la liste des ennemis.
            bullet .GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }else
        {
            timer = attackRateTime;
            //Réinitialise le compteur pour l'attaque suivante.
        }
    }

   void UpdateEnemys()
   {
        //enemys.RemoveAll(null); 
        //Supprimer tous les éléments vides de la liste des ennemis.
        List<int> emptyIndex = new List<int>(); //creer une nouvelle list pour stocker les nulls
        for(int index = 0 ; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);  //Obtenir les Index de tous les éléments vides/null d'une liste
            }
        }

        for(int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i]-i);
            //Utilisé pour supprimer l'élément vide spécifié par Index dans la liste !
            /*Remarque : -i est utilisé parce que si l'élément avait été supprimé auparavant, 
            les autres éléments de la liste auraient été avancés d'une place ! Il faut donc soustraire i.
             */
        }
   }

}

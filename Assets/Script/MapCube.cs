using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;//sauvegarder le tower qui est deja au dessus de cube
    [HideInInspector]
    public TurretData turretData;
    [HideInInspector]
    public bool isUpgraded = false;
    public GameObject buildEffect;

    private Renderer rend;
    //voir la Doc OnMouseEnter()
    void Start()
    {
        rend = GetComponent<Renderer>();  //Afin d'obtenir le matériau du cube pour qu'il puisse changer de couleur.
    }
    public void BuildTurret(TurretData turretData)
    {   
       this.turretData = turretData;
       isUpgraded = false;
       turretGo = GameObject.Instantiate(turretData.turretPrefab,transform.position,Quaternion.identity);
       GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    public void UpgradeTurret()
    {
        if (isUpgraded == true) return;
        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void DestroyTurret()
    {
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData = null;
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    //Pour changer le couleur de Mapcube
    void OnMouseEnter()
    {   
        //Debug.Log("OnMouseEnter");
        // Vérifier qu'il n'y a pas de tourelle sur le Cube et que la souris n'est pas au-dessus d'une autre interface utilisateur UI.
        if( turretGo == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            rend.material.color = Color.green; //Changez la couleur du Cube
        }
    }
    void OnMouseExit()
    {
        // Reprendre la couleur du cube lorsque la souris est déplacée vers l'extérieur.
        rend.material.color = Color.white; 
    }
}

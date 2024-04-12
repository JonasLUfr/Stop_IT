using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;


    //turret que on est en train de choisir(que on voudrais etablir)
    private TurretData selectedTurretData;//la turret dans UI qui pointe un des données au dessus

    //turret que on est en train de choisir(le turret réel dans la scene
    private MapCube selectedMapCube; // la turret dans 3D

    
    public Text moneyText;
    public Animator moneyAnimator;

    private int money = 1500;
    public GameObject upgradeCanvas;

    private Animator upgradeCanvasAnimator;

    public Button buttonUpgrade;
    void ChangeMoney(int change=0)
    {
        money += change;
        moneyText.text = "$" + money;
    }
    private void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
    }
    void Update()
    {

        if ( Input.GetMouseButtonDown(0))//verifier si il y a une touche
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)//pour verifier si le souris est au dessus d'un element de UI
            {
                ///creer le tower
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//detection de time(transmettre de la pointe au ray )
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));//detection de time avec le couche MapCube
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();//obtenir le mapcube que on clique
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        //peut creer ici 
                        if(money > selectedTurretData.cost)///si on a l'argent, on peut acheter et etablir
                        {
                            ChangeMoney(-selectedTurretData.cost);///moins d'argent
                            mapCube.BuildTurret(selectedTurretData);//c'est MapCube qui s'occupe de creer le tower(pqsse le tache au MapCube)
                        }
                        else 
                        {   
                            //pas aussi money
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (mapCube.turretGo != null) {
                        ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        //upgrade 
                        //if (mapCube.isUpgraded)
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, true);
                        //}
                        //else
                        //{
                        ///   ShowUpgradeUI(mapCube.transform.position, false);
                        /// }
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy) //verifier si c'est le meme turret et si le UI upgrade est bien affichie
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);

                        }

                        selectedMapCube = mapCube;//sauvegarde chaque fois quand on choisi le turret ET mise a jours 
                    }

                
                }
            }
        
        }
    
    }
    //Pour detecter le changement des evenements quand on clique les icons 
    public void OnLaserSelected(bool isOn) { 
        if (isOn)
        {
            selectedTurretData = laserTurretData;

        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;

        }
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;

        }
    }



    void ShowUpgradeUI(Vector3 pos,bool isDisableUpgrade)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable =!isDisableUpgrade;
    }


    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");//affecter d'abord l'animation hide
        yield return new WaitForSeconds(0.8f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgadeButtonDown()///detecter l'appuie de button Evoluer 
    {
        if(money >= selectedMapCube.turretData.costUpgraded)  //pour changer l'argents quand on evoluer le turret
        {
            ChangeMoney(-selectedMapCube.turretData.costUpgraded);
            selectedMapCube.UpgradeTurret();

        }
        else
        {
            moneyAnimator.SetTrigger("Flicker");
        }
        //selectedMapCube.UpgradeTurret();
        StartCoroutine(HideUpgradeUI());
    }

    public void OnDestroyButtonDown()///detecter l'appuie de button Destroy
    {
        selectedMapCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
}


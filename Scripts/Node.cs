using UnityEngine;
using UnityEngine.EventSystems;


//give user visual feedback
//check if user has pressed node then build on node if non-existing
public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor; //visual to show player doesn't have enough funds
    public Vector3 positionOffSet;

    [HideInInspector]  //access from anywhere, just don't want people to change this inside the inspector
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;  

    private Renderer rend;
    private Color startColor; //color 


    BuildManager buildManager;

    void Start()
    {

        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;


    }

    //create a little helper function
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }
    void OnMouseDown()
    {
        //check if hovering over existing ui element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    } //pass to build turret



    void BuildTurret (TurretBlueprint blueprint)
    {
        //check if player has enough money
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Lacking enough money to build");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;  //node.turret = turret that was just built

        turretBlueprint = blueprint; 

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //when turret is built, this happens
        Destroy(effect, 5f);

   
        //display money left
        Debug.Log("Turret built!");
    }

    //upgrade turret
    public void UpgradeTurret()
    {
        //check if player has enough money
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Lacking enough money to upgrade that");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //get rid of the old turret
        Destroy(turret);

        //build new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;  //node.turret = turret that was just built

     

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //when turret is built, this effect happens
        Destroy(effect, 5f);


        isUpgraded = true; //when upgrade is complete switch to true

        //display money left
        Debug.Log("Turret upgraded!");

    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //cool code animation
        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity); //when turret is sold, this effect happens
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;


    }
    //called when mouse enters collider
    //unity callback
    void OnMouseEnter()
    {

        //check if hovering over existing ui element
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!buildManager.CanBuild)  //to highlight different nodes
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else //visual to show player doesn't have enough funds
        {
            rend.material.color = notEnoughMoneyColor; 
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

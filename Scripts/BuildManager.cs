using UnityEngine;

public class BuildManager : MonoBehaviour {

    //make available without a reference
    //static shares by all build managers
    public static BuildManager instance;   //stores reference to itself

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;  //this build manager is put into the instance variable
    }



    public GameObject standardTurretPreFab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;  //when turret is built, this happens


    private TurretBlueprint turretToBuild;


    //property that only allows a get     
    //checks if turretToBuild is != null ONLY
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        //check if player has enough money
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Lacking enough money to build");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;  //node.turret = turret that was just built

        GameObject effect =Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity); //when turret is built, this happens
        Destroy(effect, 5f);

        //display money left
        Debug.Log("Turret built! Money Left: " + PlayerStats.Money);
    }


    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;  //sets the turrets to build here
    }
}

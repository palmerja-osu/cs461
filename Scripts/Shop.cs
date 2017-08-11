using UnityEngine;

public class Shop : MonoBehaviour {


    public TurretBlueprint standardTurret;  //define selected turrets
    public TurretBlueprint missileLauncher;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);  //select turret to build 
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

}


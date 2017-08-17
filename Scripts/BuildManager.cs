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



    public GameObject buildEffect;  //when turret is built, this happens
    public GameObject sellEffect; //turret is sold, this animation happens

    private TurretBlueprint turretToBuild; //pass reference to node
    private Node selectedNode; //nodeUI

    public NodeUI nodeUI;


    //property that only allows a get     
    //checks if turretToBuild is != null ONLY
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

   

    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null; //enable one to disable the other

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret; //sets turret to build on selected area
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
   
}

using UnityEngine;
using UnityEngine.EventSystems;


//give user visual feedback
//check if user has pressed node then build on node if non-existing
public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor; //visual to show player doesn't have enough funds
    public Vector3 positionOffSet;

    [Header("Optional")]  //this is optional for the user to add a pre-built in turret to assist gamer with a handicap during a level

    public GameObject turret;

    private Renderer rend;
    private Color startColor; //color 


    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
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


        if (!buildManager.CanBuild)
            return;



        if (turret != null)
        {
            Debug.Log("something already exists, cannot build here");
            return;
        }

        buildManager.BuildTurretOn(this);    

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

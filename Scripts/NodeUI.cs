using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;
    private Node target;

    public Text upgradeCost; //set upgrade
    public Button upgradedButton; //non-interactable button

    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradedButton.interactable = true;
        }
        else
        {
            //allow to upgrade only once
            upgradeCost.text = "DONE";
            upgradedButton.interactable = false;  //fade out animation if currently upgraded
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    //upgrade turret
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //whenever we upgrade an opject, the menu closes instead of Hide(); which hides the UI
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode(); //after selling turret on node, deselect node
    }
}

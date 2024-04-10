using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node Target;
    public GameObject UI;
    public Text upgradeCost;
    public Text sellCost;
    public Button upgradeButton;
    public Button sellButton;
    public void SetTarget(Node target)
    {
        this.Target = target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done!";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$" + target.turretBluePrint.sellCost;
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        // Debug.Log("Upgrade turret clicked");
        Target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        Target.SellTurret();
        Hide();
    }
}

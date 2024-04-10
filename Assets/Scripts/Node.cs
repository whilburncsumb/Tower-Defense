using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private GameObject currentTurret;
    
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;

    [HideInInspector] 
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;
    
    private Color startColor;
    private Renderer rend;
    
    BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        

        if (turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }
        if (!_buildManager.CanBuild)
        {
            return;
        }

        // _buildManager.BuildTurretOn(this);
        BuildTurret(_buildManager.GetTurretToBuild());
    }

    public void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            // Debug.Log("Not enough munny to build that. lol");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBluePrint = blueprint;

        GameObject effect = Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            // Debug.Log("Not enough munny to upgrade that.");
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost;
        
        //Destroy old turret
        Destroy(turret);
        
        //Build the new one
        GameObject _turret = Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.sellCost;
        Destroy(turret);
        turretBluePrint = null;
        isUpgraded = false;
        GameObject effect = Instantiate(_buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_buildManager.CanBuild)
            return;
        if (_buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughMoneyColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

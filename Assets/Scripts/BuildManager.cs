using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject buildEffect;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager in scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    
    public bool HasMoney
    {
        get { return PlayerStats.Money>=turretToBuild.cost; }
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough munny to build that. lol");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
        
        Debug.Log("Turret build, Money left: " + PlayerStats.Money);
    }
}

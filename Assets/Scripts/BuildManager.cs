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
        
        Debug.Log("Turret build, Money left: " + PlayerStats.Money);
    }
}

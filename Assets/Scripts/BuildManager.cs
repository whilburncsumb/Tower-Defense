using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

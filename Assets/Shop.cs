using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileTurret;
    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        _buildManager.SelectTurretToBuild(standardTurret);
    }
    
    public void SelectMissileTurret()
    {
        Debug.Log("Missile turret selected");
        _buildManager.SelectTurretToBuild(missileTurret);
    }
}

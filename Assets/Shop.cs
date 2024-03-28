using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret selected");
        _buildManager.SetTurretToBuild(_buildManager.standardTurretPrefab);
    }
    
    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile turret selected");
        _buildManager.SetTurretToBuild(_buildManager.missileTurretPrefab);
    }
}

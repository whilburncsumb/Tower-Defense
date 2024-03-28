using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private GameObject currentTurret;
    
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    public Vector3 positionOffset;
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (currentTurret != null)
        {
            Debug.Log("Cannot build here");
            return;
        }
        
        //build a turret
        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        currentTurret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

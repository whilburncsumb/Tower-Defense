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

    [Header("Optional")] 
    public GameObject turret;
    
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
        if (!_buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Cannot build here");
            return;
        }

        _buildManager.BuildTurretOn(this);
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

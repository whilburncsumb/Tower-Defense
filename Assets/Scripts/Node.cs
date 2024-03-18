using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject currentTurret;
    
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    public Vector3 positionOffset;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (currentTurret != null)
        {
            Debug.Log("Cannot build here");
            return;
        }
        
        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        currentTurret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

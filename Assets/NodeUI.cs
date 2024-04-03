using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node Target;
    public GameObject UI;
    public void SetTarget(Node target)
    {
        this.Target = target;
        transform.position = target.GetBuildPosition();
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
}

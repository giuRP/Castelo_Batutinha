using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpIten : Interactible
{
    [SerializeField]
    private ItenDataSO itenData;

    public override void Execute(Agent agent)
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        agent.inventory.PickUpIten(itenData);
        agent.newItenMessageUI.GetItenData(itenData);
        Destroy(gameObject);
    }

    public override void Undo()
    {
        return;
    }
}

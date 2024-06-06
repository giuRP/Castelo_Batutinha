using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItenData", menuName = "Itens/Data")]
public class ItenDataSO : ScriptableObject, IEquatable<ItenDataSO>
{
    public string itenName;
    public Sprite itenImage;
    public GameObject prefab;
    public AudioClip useItenSound;
    public int id;

    public bool Equals(ItenDataSO other)
    {
        return itenName == other.itenName;
    }

    public bool UseIten()
    {
        return PuzzleManager.Instance.currentPuzzle.SolvedCheck(this);

        //Play no som do item sendo usado
        //Remover o item do inventario 
        //Confirmar a resolução do puzzle
    }
}

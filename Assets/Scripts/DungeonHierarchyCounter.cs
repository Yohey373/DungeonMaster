using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonHierarchyCounter : SingletonMonoBehaviour<DungeonHierarchyCounter>
{
    [SerializeField]
    private int dungeonHierarchyCount;

    public int GetDungeonHierarchyCount
    {
        get
        {
            return dungeonHierarchyCount;
        }
    }

    public void DungeonHierarchyCountUP()
    {
        dungeonHierarchyCount++;
    }
}
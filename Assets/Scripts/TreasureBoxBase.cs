using UnityEngine;

public class TreasureBoxBase : ItemBase
{
    [SerializeField]
    private int scoreAmount;

    public int GetScoreAmount
    {
        get
        {
            return scoreAmount;
        }
    }

    public TreasureBoxBase(string name, ItemTypes itemType, int scoreAmount) : base(name, itemType)
    {
        this.scoreAmount = scoreAmount;
    }
}
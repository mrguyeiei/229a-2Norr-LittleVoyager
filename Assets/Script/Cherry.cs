using UnityEngine;

public class Cherry : CherryUp
{
    public int CherryIncrease;

    private void Start()
    {
        CherryIncrease = 1;
    }

    public override void ApplyCherryUp(PlayerMove playerMove)
    {
        playerMove.CherryUp(CherryIncrease);
    }
}


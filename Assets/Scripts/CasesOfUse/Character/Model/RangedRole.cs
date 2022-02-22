using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedRole : IRoleClass
{
    private int range = 20;
    public int GetAttackRange()
    {
        return range;
    }

}

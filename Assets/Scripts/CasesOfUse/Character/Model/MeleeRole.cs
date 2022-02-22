using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRole : IRoleClass 
{
    private int range = 2;
    public int GetAttackRange()
    {
        return range;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRoleClass 
{
    int GetAttackRange();
}

public class AttackConfiguration
{
    private int range;

    public bool IsMelee() {
        return range <= 2;
    }

    public bool IsRange() {
        return range > 2;
    }

    public void PerformAttack() {
        // Does an amazing attacks
    }

}

//Consultar a Sebas

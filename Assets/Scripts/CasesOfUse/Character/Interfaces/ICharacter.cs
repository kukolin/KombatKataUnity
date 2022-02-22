using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Character
{
    public interface ICharacter 
    {
        void ReceiveDamage(int amount);
        int GetAttackDamage();
        int GetCurrentLife();
        int GetCurrentLevel();
        bool IsAlive();
        int GetHealPowerAmount();
        void ReceiveHealing(int amount);
        IRoleClass GetRole();
        int GetPosition();
     
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Character
{
    public interface ICharacter 
    {
        void ReceiveDamage(int amount);
        int GetDamage(); 
        int GetCurrentLife();
    }
}


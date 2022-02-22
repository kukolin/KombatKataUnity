using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Character
{
    public class Character : ICharacter
    {
        private const int maxLife = 1000;
        private int currentLife;
        private int currentLevel;
        private bool isAlive;
        private int damage;
        private int healingPowerAmount;
        private IRoleClass _roleClass;
        private int position;
        public Character()
        {
            currentLife = maxLife;
            currentLevel = 1;
            isAlive = true;
            damage = 200;
            healingPowerAmount = 150;
           
        }

        public Character(IRoleClass roleClass) : base()
        {
            _roleClass = roleClass;
        }

        public int GetCurrentLife()
        {
            return currentLife;
        }

        public int GetCurrentLevel()
        {
            return currentLevel;
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public void ReceiveDamage(int damage)
        {
            currentLife = damage > currentLife ? 0 : currentLife - damage;

            isAlive = currentLife > 0;
        }

        public int GetAttackDamage()
        {
            return damage;
        }

        public int GetHealPowerAmount()
        {
            return healingPowerAmount;
        }

        public IRoleClass GetRole()
        {
            return _roleClass;
        }
        public int GetPosition()
        {
            return position;
        }
        public void ReceiveHealing(int healAmount)
        {
            if (isAlive)
            {   
                currentLife = currentLife + healAmount >= maxLife ? maxLife : currentLife + healAmount;
            }      
        }
    }
}

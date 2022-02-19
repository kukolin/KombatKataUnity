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

        public Character()
        {
            currentLife = maxLife;
            currentLevel = 1;
            isAlive = true;
            damage = 200;
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
            currentLife -= damage;
        }

        public int GetDamage()
        {
            return damage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Character;
using System;

namespace Scripts.BattleSystem
{
    public class BattleSystem
    {
        private List<ICharacter> characters;

        public BattleSystem()
        {
            characters = new List<ICharacter>();
        }
        public void SetCharacters(List<ICharacter> characters)
        {
            this.characters.AddRange(characters);
        }
        public void CharacterWantsToAttack(ICharacter attacker, ICharacter receiver)
        {
            int damage = Convert.ToInt32(attacker.GetAttackDamage() * CalculateDamageMultiplier(attacker, receiver));

            if (attacker != receiver) {
                receiver.ReceiveDamage(damage);
            }
        }
        public void CharacterWantsToHeal(ICharacter healer)
        {
            int healAmount = healer.GetHealPowerAmount();

            healer.ReceiveHealing(healAmount);
        }

        private float CalculateDamageMultiplier(ICharacter attacker, ICharacter receiver) {
            int attackerLevel = attacker.GetCurrentLevel();
            int receiverLevel = receiver.GetCurrentLevel();

            if (attackerLevel - receiverLevel >= 5)
            {
                return 1.5f;
            }
            if (attackerLevel - receiverLevel <= -5)
            {
                return 0.5f;
            }
            return 1;
        }

    }
}

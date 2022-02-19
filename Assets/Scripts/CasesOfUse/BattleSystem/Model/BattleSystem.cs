using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Character;

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
            characters.AddRange(characters);
        }

        public void CharacterWantsToAttack(ICharacter attacker, ICharacter receiver)
        {
            int damage = attacker.GetDamage();
            receiver.ReceiveDamage(damage);
        }
    }
}

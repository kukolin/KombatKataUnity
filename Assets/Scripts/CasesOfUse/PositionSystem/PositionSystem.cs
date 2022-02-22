using Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PositionSystem
{
    public class PositionSystem
    {
        private List<ICharacter> characters;

        public PositionSystem() {
            characters = new List<ICharacter>();
        }
        public void SetCharacters(List<ICharacter> characters)
        {
            this.characters.AddRange(characters);
        }
        public int CalculateDistance(ICharacter attacker, ICharacter receiver) 
        {
            return attacker.GetPosition() - receiver.GetPosition();
        }
    }

}
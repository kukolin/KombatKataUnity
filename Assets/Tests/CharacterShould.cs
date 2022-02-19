using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Scripts.Character;
using Scripts.BattleSystem;
using UnityEngine.TestTools;

/*
All Characters, when created, have:

Health, starting at 1000
Level, starting at 1
May be Alive or Dead, starting Alive (Alive may be a true/false)
Characters can Deal Damage to Characters.

Damage is subtracted from Health
When damage received exceeds current Health, Health becomes 0 and the character dies
A Character can Heal a Character.

Dead characters cannot be healed
Healing cannot raise health above 1000
*/

namespace Tests
{
    public class CharacterShould
    {
        private int expectedLife;
        private int expectedLevel;
        private Character character;

        [SetUp]
        public void CharacterSetUp()
        {
            character = new Character();
            expectedLevel = 1;
            expectedLife = 1000;
        }

        [Test]
        public void ShouldInitializeWithExpectedLife()
        {
            Assert.AreEqual(character.GetCurrentLife(), expectedLife);
        }

        [Test]
        public void ShouldInitializeWithExpectedLevel()
        {
            Assert.AreEqual(character.GetCurrentLevel(), expectedLevel);
        }

        [Test]
        public void ShouldInitializeAlive()
        {
            Assert.IsTrue(character.IsAlive());
        }

        [Test]
        public void ShouldSubstractHealthWhenCharacterAttacks()
        {
            BattleSystem battleSystem = new BattleSystem();

            ICharacter dummyEnemy = new Character();

            var beforeLifeToDecrease = dummyEnemy.GetCurrentLife();

            battleSystem.CharacterWantsToAttack(character, dummyEnemy);

            Assert.Less(dummyEnemy.GetCurrentLife(), beforeLifeToDecrease);
        }
    }
}
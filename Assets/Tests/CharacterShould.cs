using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Scripts.Character;
using Scripts.BattleSystem;
using NSubstitute;
using System;

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

//------------------------------ITERATION TWO ---------------------------------------------------------

A Character cannot Deal Damage to itself.

A Character can only Heal itself.

When dealing damage:
If the target is 5 or more Levels above the attacker, Damage is reduced by 50%
If the target is 5 or more Levels below the attacker, Damage is increased by 50%

//------------------------------ITERATION THREE --------------------------------------------------------
 
- Characters have an attack Max Range.

- Melee fighters have a range of 2 meters.

- Ranged fighters have a range of 20 meters.

- Characters must be in range to deal damage to a target.
  
*/

namespace Tests
{
    public class CharacterShould
    {
        private int expectedLife;
        private int expectedLevel;
        private ICharacter character;
        private ICharacter dummyEnemy;
        private ICharacter mockCharacter;
        private ICharacter dummyAlly;
        BattleSystem battleSystem;

        [SetUp]
        public void CharacterSetUp()
        {
            dummyEnemy = new Character();
            dummyAlly = new Character();
            battleSystem = new BattleSystem();
            mockCharacter = Substitute.For<ICharacter>();
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
        public void SubstractHealthWhenCharacterAttacks()
        {
            int beforeLifeToDecrease = dummyEnemy.GetCurrentLife();

            battleSystem.CharacterWantsToAttack(character, dummyEnemy);

            Assert.Less(dummyEnemy.GetCurrentLife(), beforeLifeToDecrease);
        }

        [Test]
        public void NotHaveHealthBelowCero()
        {
            int exagerateDamage = dummyEnemy.GetCurrentLife() * 2;
            mockCharacter.GetAttackDamage().Returns(exagerateDamage);

            battleSystem.CharacterWantsToAttack(mockCharacter, dummyEnemy);

            Assert.AreEqual(0, dummyEnemy.GetCurrentLife());
        }

        [Test]
        public void DieWhenHealthReachesCero()
        {
            int exagerateDamage = dummyEnemy.GetCurrentLife() * 2;
            mockCharacter.GetAttackDamage().Returns(exagerateDamage);

            battleSystem.CharacterWantsToAttack(mockCharacter, dummyEnemy);
            
            Assert.IsFalse(dummyEnemy.IsAlive());
        }

        [Test]
        public void AddHealthWhenCharacterHeals()
        {
            mockCharacter.GetAttackDamage().Returns(expectedLife / 2);
            battleSystem.CharacterWantsToAttack(mockCharacter, dummyAlly);

            int lifeWhenReceiveDamage = dummyAlly.GetCurrentLife();

            battleSystem.CharacterWantsToHeal(dummyAlly);

            Assert.Greater(dummyAlly.GetCurrentLife(), lifeWhenReceiveDamage);
        }

        [Test]
        public void NotBeHealedWhenIsDead()
        {
            mockCharacter.GetAttackDamage().Returns(expectedLife * 2);

            battleSystem.CharacterWantsToAttack(mockCharacter, dummyAlly);
            battleSystem.CharacterWantsToHeal(dummyAlly);

            Assert.AreEqual(0, dummyAlly.GetCurrentLife());
        }

        [Test]
        public void NotExceedMaxLife()
        {
            battleSystem.CharacterWantsToHeal(dummyAlly);

            Assert.AreEqual(expectedLife, dummyAlly.GetCurrentLife());
        }
        [Test]
        public void NotDamageHimself()
        {
            battleSystem.CharacterWantsToAttack(character, character);

            Assert.AreEqual(expectedLife, character.GetCurrentLife());
        }
        //[Test] PREGUNTAR A SEBAS SI HACE FALTA TESTEAR ESTO
        //public void OnlyHealHimself()
        //{
        //    mockCharacter.GetAttackDamage().Returns(expectedLife / 2);
        //    battleSystem.CharacterWantsToAttack(mockCharacter, dummyAlly);

        //    int lifeWhenReceiveDamage = dummyAlly.GetCurrentLife();

        //    battleSystem.CharacterWantsToHeal(dummyAlly);

        //    Assert.AreEqual(dummyAlly.GetCurrentLife(), lifeWhenReceiveDamage);
        //}
        [Test]
        public void DoHalfDamageIfEnemyIsFiveOrMoreLevelsAbove() 
        {
            int lifebeforeToDecrease = dummyEnemy.GetCurrentLife();

            mockCharacter.GetCurrentLevel().Returns(-6);
            mockCharacter.GetAttackDamage().Returns(200);
            int realDamage = (mockCharacter.GetAttackDamage() / 2);
            battleSystem.CharacterWantsToAttack(mockCharacter, dummyEnemy);

            Assert.AreEqual(lifebeforeToDecrease - realDamage, dummyEnemy.GetCurrentLife());
        }

        [Test]
        public void DoMoreDamageIfEnemyIsFiveOrLessLevelsBelow()
        {
            int lifebeforeToDecrease = dummyEnemy.GetCurrentLife();

            mockCharacter.GetCurrentLevel().Returns(6);
            mockCharacter.GetAttackDamage().Returns(200);
            int realDamage = Convert.ToInt32(mockCharacter.GetAttackDamage() * 1.5f);
            battleSystem.CharacterWantsToAttack(mockCharacter, dummyEnemy);

            Assert.AreEqual(lifebeforeToDecrease - realDamage, dummyEnemy.GetCurrentLife());
        }

        /* TEST APARTE PARA LOS ROLES?
            El test está bien para el character?
            Hacemos otro test para ver si el role se crea bien o con uno solo va?
                
        */
        [Test]
        public void HaveAnAttackRangeOfTwoIfIsMelee()
        {
            IRoleClass roleClass = new MeleeRole();
            character = new Character(roleClass);
            Assert.AreEqual(character.GetRole().GetAttackRange(), 2);
        }

        [Test]
        public void HaveRangeOfTwentyIfIsRange()
        {
            IRoleClass roleClass = new RangedRole();
            character = new Character(roleClass);
            Assert.AreEqual(character.GetRole().GetAttackRange(), 20);
        }

        [Test]
        public void BeInRangeToMakeAnAttack()
        {

            Assert.AreEqual();
        }



    }
}
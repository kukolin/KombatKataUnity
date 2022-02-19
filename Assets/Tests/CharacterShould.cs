using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;


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
        //Act
        //Assert
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
        var expectedCurrentLife = 20;
        //Mock Character - Attack
        var enemy = new Character();
        //var damage
        //Damage currentCharacter 
        character.ReceiveDamage(0);
        //Assert CurrentLife 
        Assert.Less(character.GetCurrentLife(), expectedCurrentLife);
    }
}

public class Character
{
    private const int maxLife = 1000;
    private int currentLife;
    private int currentLevel;
    private bool isAlive;

    public Character() 
    {
        currentLife = maxLife;
        currentLevel = 1;
        isAlive = true;
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

    }
}

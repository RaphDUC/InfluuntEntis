using DesignPatterns.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayedCharacter : Singleton
{
    public GameObject playedCharacter;


    public Character GetPlayedCharacter()
    {
        return playedCharacter.GetComponent<Character>();
    }

    public void SwitchCharacter(GameObject character)
    {
        playedCharacter = character;
    }
}

using UnityEngine;

public class GameConfig : ScriptableObject
{
    public string LocalDataSaveName = "LocalData";
    [Header("Application Settings")]
    public int FrameRate = 60;
    [Header("Audio Settings")]
    public float MusicVolume = .7f;
    public float SFXVolume = .9f;
    public string TestID;
    public string TestToken;
}
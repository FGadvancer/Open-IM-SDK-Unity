using UnityEngine;

public class GameConfig : ScriptableObject
{

    [Header("Application Settings")]
    public int FrameRate = 60;
    [Header("Audio Settings")]
    public float MusicVolume = .7f;
    public float SFXVolume = .9f;
    [Header("Player Settings")]
    public float PlayerHP;
    public float PlayerVit;
    public GameObject[] PlayerModels;
    public string[] modelNames;
    public Sprite Player1BigIcon;
    public Sprite Player1Icon;
    public Sprite Player1Select;

    public Sprite Player2BigIcon;
    public Sprite Player2Icon;
    public Sprite Player2Select;
    [Header("Skill Config")]
    public int SelectSkillCount = 5;
    public SkillConfig[] SkillConfig;
}
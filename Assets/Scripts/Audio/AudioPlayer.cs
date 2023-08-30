using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public AudioItem[] AudioList;
    AudioSource musicSource;
    float musicVolume = 1f;
    float sfxVolume = 1f;

    AudioSource[] SFXSources;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicVolume = Game.Config.MusicVolume;
        sfxVolume = Game.Config.SFXVolume;
        SFXSources = new AudioSource[2];
        for (int i = 0; i < 2; i++)
        {
            GameObject sfxSource = new GameObject();
            sfxSource.transform.parent = transform;
            sfxSource.name = "sound_" + i;
            var source = sfxSource.AddComponent<AudioSource>();
            SFXSources[i] = source;
        }
    }

    public void PlaySFX(int index, string name)
    {
        if (index >= SFXSources.Length) return;
        // bool SFXFound = false;
        foreach (AudioItem s in AudioList)
        {
            if (s.name == name)
            {
                var source = SFXSources[index];
                // pick a random number (not same twice)
                int rand = Random.Range(0, s.clip.Length);
                source.PlayOneShot(s.clip[rand]);
                source.volume = s.volume * sfxVolume;
                source.loop = s.loop;
                // SFXFound = true;
            }
        }
        // if (!SFXFound) Debug.Log("no sfx found with name: " + name);
    }

    public void PlayMusic(string name)
    {
        foreach (AudioItem s in AudioList)
        {
            if (s.name == name)
            {
                musicSource.clip = s.clip[0];
                musicSource.loop = true;
                musicSource.volume = s.volume * musicVolume;
                musicSource.Play();
            }
        }
    }
    public void StopMusic()
    {
        musicSource.volume = 0;
    }
}
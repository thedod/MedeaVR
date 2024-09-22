using UnityEngine;

[CreateAssetMenu(fileName = "ScenesData", menuName = "ScriptableObjects/SceneDataFile", order = 1)]
public class SceneDataFile : ScriptableObject
{
    public int sceneNumber;
    public AudioClip objectAudioClip;
    public AudioClip medeaAudioClip;
    public AudioClip choirAudioClip;
}
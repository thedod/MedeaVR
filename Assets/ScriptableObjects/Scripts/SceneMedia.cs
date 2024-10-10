using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "SceneMedia", menuName = "ScriptableObjects/SceneMedia", order = 1)]
public class SceneMedia : ScriptableObject
{
    public int sceneNumber;

    [Header("Radio")]
    public AudioClip radioAudioClip;

    [Header("Newspaper")]
    public AudioClip newspaperAudioClip;
    public Texture2D newspaperImage;

    [Header("Phone")]
    public VideoClip phoneVideo;

    [Header("TV")]
    public VideoClip tVVideo;

    [Header("Medea")]
    public AudioClip[] medeaAudioClips;

    [Header("Choir")]
    public AudioClip[] choirAudioClips;
}
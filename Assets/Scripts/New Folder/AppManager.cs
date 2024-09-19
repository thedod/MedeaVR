using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{

    public static AppManager instance;

    public Cinemachine.CinemachineVirtualCamera objectsCamera;
    public Cinemachine.CinemachineVirtualCamera medeaCamera;
    public Cinemachine.CinemachineVirtualCamera choirCamera;

    [SerializeField] ClickableObject[] allClickableObjects;

    public AudioSource audioSource;

    public Text SceneNumberText;
    public Text ScenePartText;

    public int currentScene;
    public int currentPart;

    [SerializeField] ScenesData scenesDataObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentScene = 0;
        currentPart = 0;
    }


    IEnumerator ObjectFlow()
    {

        objectsCamera.gameObject.SetActive(true);
        currentPart = 1;
        ScenePartText.text = "Part : " + currentPart.ToString();

        yield return new WaitForSeconds(2);

        AudioClip audioClip = scenesDataObject.sceneData[currentScene - 1].objectAudioClip;

        // Assign the audio clip to the AudioSource
        audioSource.clip = audioClip;

        // Play the audio
        audioSource.Play();

        // Wait until the audio has finished playing
        yield return new WaitForSeconds(audioClip.length);

        // After audio finishes, log a message
        Debug.Log("Objetc Audio finished playing!");

        StartCoroutine(MedeaFlow());

    }

    IEnumerator MedeaFlow()
    {
        medeaCamera.gameObject.SetActive(true);
        currentPart = 2;
        ScenePartText.text = "Part : " + currentPart.ToString();

        yield return new WaitForSeconds(2);

        AudioClip audioClip = scenesDataObject.sceneData[currentScene - 1].medeaAudioClip;

        // Assign the audio clip to the AudioSource
        audioSource.clip = audioClip;

        // Play the audio
        audioSource.Play();

        // Wait until the audio has finished playing
        yield return new WaitForSeconds(audioClip.length);

        // After audio finishes, log a message
        Debug.Log("Medea Audio finished playing!");

        StartCoroutine(ChoirFlow());

    }

    IEnumerator ChoirFlow()
    {

        choirCamera.gameObject.SetActive(true);
        currentPart = 3;
        ScenePartText.text = "Part : " + currentPart.ToString();

        yield return new WaitForSeconds(2);

        AudioClip audioClip = scenesDataObject.sceneData[currentScene - 1].choirAudioClip;

        // Assign the audio clip to the AudioSource
        audioSource.clip = audioClip;

        // Play the audio
        audioSource.Play();

        // Wait until the audio has finished playing
        yield return new WaitForSeconds(audioClip.length);

        // After audio finishes, log a message
        Debug.Log("Choir Audio finished playing!");


        ResetScene();
        ActivateScene();

    }



    public void ActivateScene()
    {
        //deactivate clickable Objects
        foreach (ClickableObject clickableObject in allClickableObjects)
        {
            if (!clickableObject.wasClicked)
            {
                clickableObject.gameObject.GetComponent<HighlightEffect>().overlay = 0f;
                clickableObject.gameObject.GetComponent<HighlightEffect>().glow = 5f;
                clickableObject.gameObject.GetComponent<BoxCollider>().enabled = true;
            }

        }


    }

    public void DeactivateScene()
    {
        //activate clickable Objects
        foreach (ClickableObject clickableObject in allClickableObjects)
        {
            if (!clickableObject.wasClicked)
            {
                clickableObject.gameObject.GetComponent<HighlightEffect>().overlay = 0.9f;
                clickableObject.gameObject.GetComponent<HighlightEffect>().glow = 0f;
                clickableObject.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        StartCoroutine(ObjectFlow());
    }

    public void ResetScene()
    {
        objectsCamera.gameObject.SetActive(false);
        medeaCamera.gameObject.SetActive(false);
        choirCamera.gameObject.SetActive(false);
    }

}

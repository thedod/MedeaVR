using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using UnityEngine.UI;
using UnityEngine.Video;


public enum expositionItems
{
    Radio,
    Newspaper,
    Phone,
    TV
}


public class AppManager : MonoBehaviour
{

    public static AppManager instance;

    public Cinemachine.CinemachineVirtualCamera playerCamera;

    [SerializeField] ClickableObject[] allClickableObjects;

    public AudioSource audioSource;

    public Text SceneNumberText;
    public Text ScenePartText;

    public int currentScene;
    public int currentPart;

    [SerializeField] ScenesData scenesDataObject;


    [SerializeField] GameObject medea;
    [SerializeField] GameObject choir;




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


    public IEnumerator ObjectFlow(expositionItems _expositionItem, GameObject item)
    {
        DeactivateScene();

        currentPart = 1;
        ScenePartText.text = "Part : " + currentPart.ToString();

        yield return new WaitForSeconds(1);


        switch (_expositionItem)
        {
            case expositionItems.Radio:

                AudioClip radioAudioClip = scenesDataObject.scenesMedia[currentScene - 1].radioAudioClip;

                // Assign the audio clip to the AudioSource
                audioSource.clip = radioAudioClip;

                // Play the audio
                audioSource.Play();

                // Wait until the audio has finished playing
                yield return new WaitForSeconds(radioAudioClip.length);

                // After audio finishes, log a message
                Debug.Log("Objetc Audio finished playing!");

                break;

            case expositionItems.Newspaper:

                item.GetComponent<MeshRenderer>().material.mainTexture = scenesDataObject.scenesMedia[currentScene - 1].newspaperImage;

                AudioClip newspaperAudioClip = scenesDataObject.scenesMedia[currentScene - 1].radioAudioClip;

                // Assign the audio clip to the AudioSource
                audioSource.clip = newspaperAudioClip;

                // Play the audio
                audioSource.Play();

                // Wait until the audio has finished playing
                yield return new WaitForSeconds(newspaperAudioClip.length);

                // After audio finishes, log a message
                Debug.Log("Objetc Audio finished playing!");

                break;

            case expositionItems.Phone:

                VideoClip phoneVideoClip = scenesDataObject.scenesMedia[currentScene - 1].phoneVideo;

                VideoPlayer phoneVideoPlayer = item.GetComponent<ClickableObject>().videoPlayer;
                phoneVideoPlayer.clip = phoneVideoClip;

                phoneVideoPlayer.Play();

                yield return new WaitForSeconds((int)phoneVideoClip.length);

                Debug.Log("Objetc Video finished playing!");

                break;

            case expositionItems.TV:

                VideoClip tvVideoClip = scenesDataObject.scenesMedia[currentScene - 1].tVVideo;

                VideoPlayer tvVideoPlayer = item.GetComponent<ClickableObject>().videoPlayer;
                tvVideoPlayer.clip = tvVideoClip;

                tvVideoPlayer.Play();

                yield return new WaitForSeconds((int)tvVideoClip.length);

                Debug.Log("Objetc Video finished playing!");

                break;

            default:

                Debug.Log("Couldnt Find Exposition Items");
                break;
        }


        StartCoroutine(MedeaFlow());

    }

    IEnumerator MedeaFlow()
    {
        playerCamera.LookAt = medea.transform;
        currentPart = 2;
        ScenePartText.text = "Part : " + currentPart.ToString();

        yield return new WaitForSeconds(1);

        for (int i = 0; i < scenesDataObject.scenesMedia[currentScene - 1].medeaAudioClips.Length; i++)
        {
            AudioClip audioClip = scenesDataObject.scenesMedia[currentScene - 1].medeaAudioClips[i];

            // Assign the audio clip to the AudioSource
            audioSource.clip = audioClip;

            // Play the audio
            audioSource.Play();

            // Wait until the audio has finished playing
            yield return new WaitForSeconds(audioClip.length);

            // After audio finishes, log a message
            Debug.Log("Medea Audio finished playing!");
        }


        StartCoroutine(ChoirFlow());

    }

    IEnumerator ChoirFlow()
    {
        playerCamera.LookAt = choir.transform;
        // choirCamera.gameObject.SetActive(true);
        currentPart = 3;
        ScenePartText.text = "Part : " + currentPart.ToString();

        yield return new WaitForSeconds(2);

        for (int i = 0; i < scenesDataObject.scenesMedia[currentScene - 1].choirAudioClips.Length; i++)
        {
            AudioClip audioClip = scenesDataObject.scenesMedia[currentScene - 1].choirAudioClips[i];

            // Assign the audio clip to the AudioSource
            audioSource.clip = audioClip;

            // Play the audio
            audioSource.Play();

            // Wait until the audio has finished playing
            yield return new WaitForSeconds(audioClip.length);

            // After audio finishes, log a message
            Debug.Log("Medea Audio finished playing!");
        }


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
                clickableObject.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }

    public void ResetScene()
    {
        //  objectsCamera.gameObject.SetActive(false);
        //  medeaCamera.gameObject.SetActive(false);
        //  choirCamera.gameObject.SetActive(false);
    }

}

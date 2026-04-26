using UnityEngine;

public class PlayerSoundEffectScript : MonoBehaviour
{
    public AudioClip universfieldswoosh027454865;
    public AudioClip freesoundcommunityunlockthedoor299745;
    public AudioClip freesoundcommunityfootstepsinahallway47842;
    public AudioClip soundsforstorywalkmanbutton272973;
    private AudioSource playerAudio;
   
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.PlayOneShot(universfieldswoosh027454865, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAudio.PlayOneShot(freesoundcommunityunlockthedoor299745, 0.50f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAudio.PlayOneShot(freesoundcommunityfootstepsinahallway47842, 0.50f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAudio.PlayOneShot(freesoundcommunityfootstepsinahallway47842, 0.50f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAudio.PlayOneShot(freesoundcommunityfootstepsinahallway47842, 0.50f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAudio.PlayOneShot(freesoundcommunityfootstepsinahallway47842, 0.50f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAudio.PlayOneShot(soundsforstorywalkmanbutton272973, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerAudio.PlayOneShot(soundsforstorywalkmanbutton272973, 2.0f);
        }
    }
}

using UnityEngine;

public class DoorUnLockingSoundeffectScript : MonoBehaviour
{
    public AudioClip freesoundcommunityunlockthedoor299745;
    private AudioSource test_drawerAudio;

    void Start()
    {
        test_drawerAudio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            test_drawerAudio.PlayOneShot(freesoundcommunityunlockthedoor299745, 1.0f);

        }

    }
}

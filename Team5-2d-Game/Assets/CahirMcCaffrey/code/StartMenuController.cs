using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public AudioClip soundsforstorywalkmanbutton272973;
    private AudioSource CanvasAudio;
    [SerializeField] Scene game_scene;

    void Start()
    {
        CanvasAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CanvasAudio.PlayOneShot(soundsforstorywalkmanbutton272973, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CanvasAudio.PlayOneShot(soundsforstorywalkmanbutton272973, 2.0f);
        }
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("main_game_scene");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
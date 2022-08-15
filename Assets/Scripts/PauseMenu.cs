using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool SoundIsMuted = false;
    public static bool MusicIsMuted = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource backgrondMusic;
    [SerializeField] GameObject btn_music;
    [SerializeField] GameObject btn_sound;
    [SerializeField] GameObject btn_pause;
    [SerializeField] Sprite mutedSpriteMusic;
    [SerializeField] Sprite unmutedSpriteMusic;
    [SerializeField] Sprite mutedSpriteSounds;
    [SerializeField] Sprite unmutedSpriteSounds;
     SpriteRenderer srMusic;
     SpriteRenderer srSound;



    private void Start()
    {
        srMusic = btn_music.GetComponent<SpriteRenderer>();
        srSound = btn_sound.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
        if (MusicIsMuted)
        {
            srMusic.sprite = mutedSpriteMusic;
        }
        else
        {
            srMusic.sprite = unmutedSpriteMusic;
        }

        if (SoundIsMuted)
        {
            srSound.sprite = mutedSpriteSounds;
        }
        else
        {
            srSound.sprite = unmutedSpriteSounds;
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MuteSound()
    {
        if(SoundIsMuted)
        {
            jumpSound.mute = false;
            damageSound.mute = false;
            SoundIsMuted = false;
            
        }
        else
        {
            jumpSound.mute = true;
            damageSound.mute = true;
            SoundIsMuted = true;
        }
        
    }
    public void MuteMusic()
    {
        if (MusicIsMuted)
        {
            backgrondMusic.mute = false;
            MusicIsMuted = false;
            //picture
            //sr.sprite = mutedSpriteMusic;
            
        }
        else
        {
            backgrondMusic.mute = true;
            MusicIsMuted = true;
        }
    }
}

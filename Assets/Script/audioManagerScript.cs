using UnityEngine;

public class audioManagerScript : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource backgroundMusicSource;
    [SerializeField] AudioSource soundEffectSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusicClip;
    public AudioClip coinSFXClip;
    public AudioClip deathClip;
    public LogicManagerScript logic;
    bool hasMusicChanged = false;
    [SerializeField] AudioClip NewOstClip;
    public PipeSpawnScript pipeState;

    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
        pipeState = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeSpawnScript>();
        backgroundMusicSource.clip = backgroundMusicClip;
        backgroundMusicSource.Play();
    }

    void Update()
    {
        changeSoundTrack();
        if (logic.isGameOver)
        {
            backgroundMusicSource.Stop();
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }

    void changeSoundTrack()
    {
        if (pipeState.isPipeColliderDeactivated && !hasMusicChanged)
        {
            backgroundMusicSource.Stop();
            backgroundMusicSource.clip = NewOstClip;
            backgroundMusicSource.Play();
            hasMusicChanged = true;
            Debug.Log("Changement de musique réussi");
        }
        else if (!pipeState.isPipeColliderDeactivated && hasMusicChanged)
        {
            backgroundMusicSource.Stop();
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
            hasMusicChanged = false;
            Debug.Log("Musique par défaut rétablie");
        }
    }
}

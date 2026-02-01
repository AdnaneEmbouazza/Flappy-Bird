using UnityEngine;

public class CoreFlameTriggerScript : MonoBehaviour
{
    LogicManagerScript logic;
    audioManagerScript audioManager;
    void Start()
    {
       logic = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
       audioManager = GameObject.Find("AudioManager").GetComponent<audioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            audioManager.PlaySoundEffect(audioManager.coinSFXClip);
            logic.AddFlameScore(1);
            Destroy(gameObject);
        }
    }
}

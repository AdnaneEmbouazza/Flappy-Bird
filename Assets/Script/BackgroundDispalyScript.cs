using UnityEngine;

public class BackgroundDispalyScript : MonoBehaviour
{
    public GameObject[] backgrounds;
    private int currentBackgroundIndex = 0;
    public float changeInterval = 5f;
    private float timer = 0f;
    LogicManagerScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        changeActiveBackground();
    }

    void changeActiveBackground()
    {
        if (backgrounds.Length == 0)
            return;

        if (timer < changeInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {

            backgrounds[currentBackgroundIndex].SetActive(false); //désactiver le background précédent

            currentBackgroundIndex = Random.Range(0, backgrounds.Length);

            backgrounds[currentBackgroundIndex].SetActive(true); //activer le nouveau background  

            timer = 0f; //réinitialiser le timer

            if (logic.isGameOver)
            {
                this.enabled = false; //arrêter le changement de background si le jeu est terminé
            }
        }
    }
}

using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject coreFlame;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffSet = 10;
    public Transform[] coinSpawnPoints;
    public LogicManagerScript logic;
    public int currentIndex = 0;
    public bool isPipeColliderDeactivated = false;
    public float pipeDesactivateDuration = 30f;
    public float deactivationTimer = 0f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        spawnPipe();
        SpawnCoreFlame();
    }

    void Update()
    {
        checkPipeandCore();
        DeactivatePipe();
        ReactivatePipe();

        if (isPipeColliderDeactivated)
        {

        }

        if (logic.isGameOver)
        {
            // Arrêter TOUS les tuyaux en mouvement
            var pipes = GameObject.FindObjectsByType<PipeMoveScript>(FindObjectsSortMode.None); // tt les instance de PipeMoveScript
            foreach (var pipe in pipes)
            {
                pipe.enabled = false; // arrete les tuyaux
            }

            // Arrêter TOUS les coreFlame en mouvement
            var coreFlames = GameObject.FindObjectsByType<coreFlameMoveScript>(FindObjectsSortMode.None); // tt les instance de coreFlameMoveScript
            foreach (var coreFlame in coreFlames)
            {
                coreFlame.enabled = false; // arrete les coreFlame
            }

            this.enabled = false; // arrete le spawn des tuyaux

        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;

        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x , Random.Range(lowestPoint , highestPoint) , 0), transform.rotation);

        // Si la désactivation déjà est active
        if (isPipeColliderDeactivated)
        {
            PipeDesactivateScript pipeScript = newPipe.GetComponent<PipeDesactivateScript>();
            if (pipeScript != null)
            {
                pipeScript.DeactivateColliderPipe(); //desactive les hitbox des nouveaux tuyaux spawn
            }
        }
    }

    void DeactivatePipe()
    {
        if (logic.flameScore >=12 && !isPipeColliderDeactivated)
        {
            isPipeColliderDeactivated = true;
            logic.flameScore -= 12; //retire 12 flammes au score
            logic.moveSpeed *= 2f; //augmente la vitesse des tuyaux de 50% pendant la désactivation

            var pipes = GameObject.FindObjectsByType<PipeDesactivateScript>(FindObjectsSortMode.None); // tt les instance de PipeDesactivateScript
            if (pipes != null)
            {
                foreach (var pipe in pipes)
                {
                    pipe.DeactivateColliderPipe(); //desactive les hitbox des tuyaux si condition remplies
                }
            }
            Debug.Log("Tuyaux désactivés pour une durée de !" + pipeDesactivateDuration + "Secondes");
        }
        else if (isPipeColliderDeactivated && logic.flameScore >=12) // si les tuyaux sont déjà désactivés et que le joueur a réacumulé 3 flammes
        {
            deactivationTimer = 0f; //réinitialise le timer
            logic.flameScore -= 12; //retire 12 flammes au score
            Debug.Log("Durée de désactivation des tuyaux réinitialisé!");
        }
    }

    void ReactivatePipe()
    {
        if (isPipeColliderDeactivated)
        {
            deactivationTimer += Time.deltaTime;

            if(deactivationTimer >= pipeDesactivateDuration)
            {
                var pipes = GameObject.FindObjectsByType<PipeDesactivateScript>(FindObjectsSortMode.None); // tt les instance de PipeDesactivateScript

                foreach (var pipe in pipes)
                {
                    pipe.ReactivateColliderPipe();
                }
                isPipeColliderDeactivated = false;
                Debug.Log("Tuyaux réactivés!");
                deactivationTimer = 0f;
                logic.moveSpeed /= 2f; //remet la vitesse des tuyaux à la normale
            }
        }
    }


    void SpawnCoreFlame()
    {
        if (coinSpawnPoints.Length == 0) //si tableau vide
            return;
            
            int previousIndex = currentIndex; //stocker l'index précédent
            currentIndex = Random.Range(0, coinSpawnPoints.Length); //index aléatoire

        if(currentIndex == previousIndex || previousIndex == 3 && currentIndex == 0) //si l'index est le même que le précédent
            {
                currentIndex = (currentIndex + 1) % coinSpawnPoints.Length; //changer l'index pour éviter la répétition
            }

        Transform spawnPoint = coinSpawnPoints[currentIndex]; //point de spawn choisi en fonction de l'index aléatoire

            Instantiate(coreFlame, spawnPoint.position, transform.rotation);
            Debug.Log("Core Flame Spawned");
    }

    void checkPipeandCore()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            SpawnCoreFlame();
            timer = 0;
        }
    }

}

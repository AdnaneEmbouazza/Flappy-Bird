using UnityEngine;

public class PipeTriggerScript : MonoBehaviour
{

    public LogicManagerScript logic;
    public PipeSpawnScript pipeState;
    void Start()
    {
      logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
      pipeState = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeSpawnScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (!pipeState.isPipeColliderDeactivated) // si les colliders des tuyaux sont actifs
            {
                logic.AddScore(1);
            }
            else
            {
                Debug.Log("Pipe collider is deactivated, adding 3 points now");
                logic.AddScore(3);
            }
        }
    }
}

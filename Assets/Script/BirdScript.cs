using Unity.VisualScripting;
using UnityEngine;

public class PhainonScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float upStrenght;
    public LogicManagerScript logic;
    public bool isAlive = true;
    public Vector3 maxHeightViewPort = new Vector3(0, 1, 10);
    public Vector3 minHeightViewPort = new Vector3(0, 0, 10);
    public PipeSpawnScript pipeState;
    [SerializeField] Sprite newSprite;
    [SerializeField] Sprite defaultSprite;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        pipeState = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeSpawnScript>();
    }

    void Update()
    {
        changeSprite();
        if (Input.GetKeyDown(KeyCode.Space) && isAlive) {
            myRigidBody.linearVelocity = Vector2.up * upStrenght;
        }

        if (outOfBound())
        {
            logic.gameOver();
            isAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
        Destroy(gameObject);
    }

    bool outOfBound()
    {
        Vector3 maxHeightWorld = Camera.main.ViewportToWorldPoint(maxHeightViewPort); // Convertit les coordonnées du viewport en coordonnées du monde
        Vector3 minHeightWorld = Camera.main.ViewportToWorldPoint(minHeightViewPort); // Convertit les coordonnées du viewport en coordonnées du monde

        if (transform.position.y > maxHeightWorld.y+2 || transform.position.y < minHeightWorld.y-2)
        {
            return true;
        }
        else {
            return false;
        }
    }

    void changeSprite()
    {
        if (pipeState.isPipeColliderDeactivated)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }
    }
        
}


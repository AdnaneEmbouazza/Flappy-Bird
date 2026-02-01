using UnityEngine;

public class coreFlameMoveScript : MonoBehaviour
{
    public Vector3 leftBoundViewPort = new Vector3(0, 0, 10);
    public LogicManagerScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }


    void Update()
    {
        CheckFlameSpeed();
        transform.position += (Vector3.left * logic.moveSpeed) * Time.deltaTime;

        if (transform.position.x < LimitWorldLeft().x - 3)
        {
            //Debug.Log("CoreFlame Destroyed");
            Destroy(gameObject);
        }
    }

    Vector3 LimitWorldLeft()
    {
        Vector3 cameraPosLeft = Camera.main.ViewportToWorldPoint(leftBoundViewPort);
        return cameraPosLeft;
    }

    void CheckFlameSpeed()
    {
        logic.UpgradeSpeed();
    }
}

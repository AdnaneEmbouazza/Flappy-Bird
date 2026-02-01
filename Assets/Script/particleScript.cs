using UnityEngine;

public class particleScript : MonoBehaviour
{
    public LogicManagerScript logic;
    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.isGameOver)
        {
            ParticleSystem ps = GetComponent<ParticleSystem>();
            ps.Stop();
        }
    }
}

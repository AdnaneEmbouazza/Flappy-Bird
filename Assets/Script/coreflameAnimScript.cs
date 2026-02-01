using UnityEngine;

public class coreflameAnimScript : MonoBehaviour
{
    public float rotationSpeed = 180f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime , 0f);
    }
}

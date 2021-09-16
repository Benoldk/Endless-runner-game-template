using UnityEngine;

public class TestObstacle : MonoBehaviour
{
    public float minZPosition = 5;
    public float maxZPosition = -5;
    public float Speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > maxZPosition)
            transform.position -= transform.forward * Speed * Time.deltaTime;
        else
        {
            Vector3 position = transform.position;
            position.z = minZPosition;
            transform.position = position;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    print($"trigger entered by {other.tag}");
    //}
}

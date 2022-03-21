using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{/// <summary>
/// all the variables with the set perameters
/// </summary>
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 6;
    private float ySpawnPos = -4;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); // accessing the GameObjects Rigidbody

        targetRb.AddForce(RandomForce(), ForceMode.Impulse); // applying Force randomly to the object
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // applying that force on all three axis

        transform.position = RandomSpawnPos(); //spawn in random position

}

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// These are all the methods created to Destroy the objects apply the diffrent types of force and positions
    /// </summary>
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

   
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}

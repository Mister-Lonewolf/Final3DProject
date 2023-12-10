using System.Runtime.CompilerServices;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float maxRotationSpeed = 30f;
    private float maxRotationX, maxRotationY, maxRotationZ;

    void Start()
    {
        maxRotationX = Random.Range(0.01f, maxRotationSpeed) * roundedValue();
        maxRotationY = Random.Range(0.01f, maxRotationSpeed) * roundedValue();
        maxRotationZ = Random.Range(0.01f, maxRotationSpeed) * roundedValue();
    }

    void Update()
    {
        // Rotatie om de X-as
        transform.Rotate(Vector3.right * maxRotationX * Time.deltaTime);

        // Rotatie om de Y-as
        transform.Rotate(Vector3.up * maxRotationY * Time.deltaTime);

        // Rotatie om de Z-as
        transform.Rotate(Vector3.forward * maxRotationZ * Time.deltaTime);
    }
    float roundedValue()
    {
        float randomValue = Random.Range(-1.0f, 1.0f);
        randomValue = (float)Mathf.RoundToInt(randomValue);
        return randomValue;
    }
}

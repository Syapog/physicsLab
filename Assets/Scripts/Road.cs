using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject RoadPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Car car;
        if(other.TryGetComponent<Car>(out car))
        {
            Instantiate(RoadPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 6f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

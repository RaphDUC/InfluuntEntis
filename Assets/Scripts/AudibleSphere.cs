using UnityEngine;

public class AudibleSphere : MonoBehaviour
{

    public SphereCollider sphereCollider;

    public float radius=5f;


    private void Update()
    {
        radius = sphereCollider.radius;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    public int accurate = 3; 
    bool isHit;
    RaycastHit raycastHit;
    void Start()
    {
        
    }
    void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
        for (int i = 0; i < accurate * 3; i++)
        {
           Ray ray = new Ray(transform.position, Quaternion.Euler(0.0f, -45 + 45 / accurate * 3 * (i+1), 0.0f) * transform.forward);
           isHit = Physics.Raycast(ray, out raycastHit, 5, layerMask);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        int radius = 5;
        int segments = 300;
        float angle = 90.0f;
        float deltaAngle = angle / segments;
        Vector3[] vertex = new Vector3[segments];
        for (int i = 0; i < vertex.Length; i++)
        {
            Vector3 pos = transform.position + Quaternion.Euler(0.0f, -angle/2 + deltaAngle * i,0.0f)*transform.forward* radius;
            vertex[i] = pos;
        }
        for (int i = 0; i < vertex.Length-1; i++)
        {
            Gizmos.DrawLine(vertex[i], vertex[i + 1]);
        }
        Gizmos.DrawLine(transform.position, vertex[0]);
        Gizmos.DrawLine(transform.position, vertex[vertex.Length-1]);

        if (isHit)
        {
            Gizmos.color = Color.red;
            radius = 5;
            segments = 300;
            angle = 90.0f;
            deltaAngle = angle / segments;            

            Gizmos.DrawLine(transform.position, vertex[0]);
            Gizmos.DrawLine(transform.position, vertex[vertex.Length - 1]);
        }

    }
}

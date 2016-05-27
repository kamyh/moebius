using UnityEngine;
using System.Collections;

public class SetRigidbodyToChildrens : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb;
	    foreach(Transform child in transform.gameObject.GetComponentsInChildren<Transform>())
        {
            rb = child.gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            //rb.centerOfMass = GetCenter(child.gameObject);
            rb.mass = 10f;
            rb.angularVelocity = Vector3.zero;
            rb.angularDrag = 1f;
        }
	}

    private Vector3 GetCenter(GameObject obj)
    {
        MeshFilter[] filters;
        try
        {
            filters = obj.GetComponents<MeshFilter>();
        }
        catch (MissingComponentException e)
        {
            e.ToString();
            filters = obj.GetComponentsInChildren<MeshFilter>();
        }

        if (filters.Length > 0)
        {
            Vector3[] vertices;
            Vector3 total = Vector3.zero;
            int length = 0;
            foreach (MeshFilter filter in filters)
            {
                vertices = filter.mesh.vertices;
                foreach (Vector3 v in vertices)
                {
                    total += v;
                    length++;
                }
            }
            return total / length;
        }
        else
        {
            Debug.Log(obj.tag);
            return obj.transform.localPosition;
        }
    }
}

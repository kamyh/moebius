using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ClickHandler : MonoBehaviour {

    public float depth = -1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
       SetAllCollidersStatus(false);
    }

    void OnMouseUp()
    {
        SetAllCollidersStatus(true); 
    }

    void OnMouseDrag()
    {
        var mousePos = Input.mousePosition;
        Vector3 boundary = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag(TagsHelper.Wall).transform.position);
        //Debug.Log(mousePos.x);
        //mousePos.x = Mathf.Clamp(mousePos.x, 0, boundary.x - 30);
        //Debug.Log(mousePos.x);
        //Debug.Log(boundary.x);
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));
        wantedPos.z = depth;
        GetComponent<Rigidbody>().MovePosition(wantedPos);
    }


    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }
}

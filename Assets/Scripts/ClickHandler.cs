using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ClickHandler : MonoBehaviour {

    public float depth = -0f;

    private Texture2D standardCursor;
    private Texture2D hoverCursor;
    private Texture2D dragCursor;
    private Vector2 dragAndHoverOffset;

	// Use this for initialization
	void Start () {
        dragAndHoverOffset = new Vector2(13, 0);
        standardCursor = Resources.Load("standardCursor") as Texture2D;
        hoverCursor = Resources.Load("hoverCursor") as Texture2D;
        dragCursor = Resources.Load("dragCursor") as Texture2D;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(hoverCursor, dragAndHoverOffset, CursorMode.ForceSoftware);
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(dragCursor, dragAndHoverOffset, CursorMode.ForceSoftware);
        GetComponent<AudioSource>().Play();
        SetAllCollidersStatus(false);
    }

    void OnMouseUp()
    {
        Cursor.SetCursor(hoverCursor, dragAndHoverOffset, CursorMode.ForceSoftware);
        SetAllCollidersStatus(true); 
    }

    void OnMouseDrag()
    {
        var mousePos = Input.mousePosition;
        //Vector3 boundary = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag(TagsHelper.Wall).transform.position);
        //Debug.Log(mousePos.x);
        //mousePos.x = Mathf.Clamp(mousePos.x, 0, boundary.x - 30);
        //Debug.Log(mousePos.x);
        //Debug.Log(boundary.x);
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));
        wantedPos.z = depth;
        GetComponent<Rigidbody>().MovePosition(wantedPos);
        Cursor.SetCursor(dragCursor, dragAndHoverOffset, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(standardCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnDestroy()
    {
        Cursor.SetCursor(standardCursor, Vector2.zero, CursorMode.ForceSoftware);
    }


    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = active;
        }

        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = active;
        }
    }
}

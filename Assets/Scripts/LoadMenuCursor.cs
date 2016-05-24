using UnityEngine;
using System.Collections;

public class LoadMenuCursor : MonoBehaviour {


    private Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
        cursorTexture = Resources.Load("standardCursor") as Texture2D;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
	}
	
}

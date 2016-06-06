using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpSlider : MonoBehaviour {

    public RectTransform scrollableArea;
    public GameObject helpHierarchy;
	// Use this for initialization
	void Start () {
        SetRenderersState(false);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnValueChanged(Vector2 value)
    {
        Debug.Log(value);
        if(value.y <= 0.08f)
        {
            SetRenderersState(true);
        }
        else
        {
            SetRenderersState(false);
        }
    }

    private void SetRenderersState(bool state)
    {
        foreach (Renderer r in helpHierarchy.GetComponentsInChildren<Renderer>())
        {
            r.enabled = state;
        }
    }
}

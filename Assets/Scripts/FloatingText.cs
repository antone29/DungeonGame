using UnityEngine;
using UnityEngine.UI; //imports Text
using TMPro;

public class FloatingText
{
    public bool active;
    public GameObject go;
    public TextMeshProUGUI txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

//not called but unity, called by us through a manager
    public void UpdateFloatingText() 
    {
        if (!active) {
            return;
        }

        if (Time.time - lastShown > duration){
            Hide();
        }

        go.transform.position += motion * Time.deltaTime;

    }
}

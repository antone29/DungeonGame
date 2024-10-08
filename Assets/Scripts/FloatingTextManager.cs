using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
  public GameObject textContainer;
  public GameObject textPrefab;

  private List<FloatingText> floatingTexts = new List<FloatingText>();


  private void Update()
  {
    foreach (FloatingText txt in floatingTexts){
      txt.UpdateFloatingText(); //updates all the floating text in the array every frame
    }
    {
      
    }
  }
  public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
  {
    FloatingText floatingText = GetFloatingText();

    floatingText.txt.text = msg;
    floatingText.txt.fontSize = fontSize;
    floatingText.txt.color = color;
    //make sure camera has tag maincamera
    floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); //transfer world space to screen space so we can use it in the UI
    floatingText.motion = motion;
    floatingText.duration = duration;

    floatingText.Show();
  }

  private FloatingText GetFloatingText()
  {
    FloatingText txt = floatingTexts.Find(t => !t.active);

    if (txt == null)
    {
        txt = new FloatingText();
        txt.go = Instantiate(textPrefab);
        txt.go.transform.SetParent(textContainer.transform);
        txt.txt = txt.go.GetComponent<TextMeshProUGUI>();

        floatingTexts.Add(txt);
    }

    return txt;
  }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class TouchShop : MonoBehaviour,
  IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
  IBeginDragHandler, IEndDragHandler, IDragHandler {

    [Header("UI")]
    public Text text;

    [Header("Params")]
    public int num;

    [Header("Effect")]
    public TouchEffectManager effectMan;

    private Queue<string> lines;

    void Awake() {
        lines = new Queue<string> ();
    }

    public void OnDrag (PointerEventData eventData) {
        Log ("Drag", eventData.ToSimpleString (), Color.black);
    }

    public void OnEndDrag (PointerEventData eventData) {
        Log ("End", eventData.ToSimpleString (), Color.cyan);
    }

    public void OnBeginDrag (PointerEventData eventData) {
        Log ("Begin", eventData.ToSimpleString (), Color.magenta);
    }

    public void OnPointerClick (PointerEventData eventData) {
        Log ("Click", eventData.ToSimpleString (), Color.green);
    }

    public void OnPointerDown (PointerEventData eventData) {
        effectMan.Invoke (eventData.position, Color.red);
        Log ("Down", eventData.ToSimpleString (), Color.red);
    }

    public void OnPointerUp (PointerEventData eventData) {
        effectMan.Invoke (eventData.position, Color.blue);
        Log ("Up", eventData.ToSimpleString (), Color.blue);
    }

    public void Log(string prefix, string str, Color color) {
        string line = (prefix + ": " + str).ToString(color);

        lines.Enqueue (line);
        if (lines.Count () > num) {
            lines.Dequeue ();
        }

        text.text = lines.Aggregate ((s, l) => s += "\n" + l);
    }

}

public static class Utility {
    public static string ToString(this string str, Color color) {
        return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(color), str);
    }

    public static string ToSimpleString(this PointerEventData eventData) {
        return eventData.pointerId + ", " + eventData.position + "@" + Time.time;
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TouchEffectManager : MonoBehaviour {
    public TouchEffect prefab;

    private List<TouchEffect> effectList;

    void Awake() {
        effectList = new List<TouchEffect> ();
    }

    public void Invoke(Vector2 position, Color color) {
        
        TouchEffect next = effectList.FirstOrDefault (e => !e.gameObject.activeInHierarchy);
        if (next == null) {
            next = Instantiate (prefab);
            effectList.Add (next);
        }

        Transform trans = next.trans;
        trans.SetParent (transform);
        trans.localScale = Vector3.one;
        trans.position = position;
        next.Enable (color);
    }

}

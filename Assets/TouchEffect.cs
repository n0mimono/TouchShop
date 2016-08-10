using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchEffect : MonoBehaviour {
    public RectTransform trans;
    public Image image;

    private Color color;
    private float alpha;

    public void Enable(Color color) {
        this.color = color;

        gameObject.SetActive (true);

        alpha = 0.5f;
        Apply ();
    }

    private void Apply() {
        image.color = new Color (color.r, color.g, color.b, alpha);
        if (alpha <= 0f) {
            alpha = 0f;
            gameObject.SetActive (false);
        }
    }

    void Update() {
        alpha -= Time.deltaTime * 0.5f;
        Apply ();
    }

}

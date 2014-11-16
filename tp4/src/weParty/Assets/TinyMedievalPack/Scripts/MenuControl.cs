using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {
    UISprite menuOn, menuOff;
    public UILabel label;

	void Awake () {
        menuOff = transform.Find("BackgroundOff").GetComponent<UISprite>();
        menuOn = transform.Find("BackgroundOn").GetComponent<UISprite>();
        label = GetComponentInChildren<UILabel>();
    }

    public void OnMenu()
    {
        menuOff.enabled = false;
        menuOn.enabled = true;
        label.color = Color.white;
    }

    public void OffMenu()
    {
        menuOff.enabled = true;
        menuOn.enabled = false;
        label.color = new Color(0.6f, 0.6f, 0.6f);
    }

}

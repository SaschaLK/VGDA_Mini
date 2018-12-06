using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScrollBehaviour : MonoBehaviour {

    public List<Image> images = new List<Image>();
    public float scrollSpeed;
    private Vector3 setbackPosition;
    private Vector3 forwardPosition;
    private List<float> imagesStartY = new List<float>();

    private void Start() {
        //Set image scale to Windows Size
        foreach (Image image in images) {
            image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        }

        //Set image starting positions
        Vector3 tempLoadingPosition = transform.position;
        foreach(Image image in images) {
            image.transform.position = tempLoadingPosition;
            tempLoadingPosition = new Vector3(transform.position.x, -image.transform.position.y, transform.position.z);
        }

        //Add image starting positions to starting position list
        foreach (Image image in images) {
            imagesStartY.Add(image.transform.position.y);
        }
        setbackPosition = images[images.Count - 1].transform.position;
        forwardPosition = setbackPosition * -3;
    }

    private void Update() {
        for (int i = 0; i < images.Count; i++) {
            if (images[i].transform.position.y >= forwardPosition.y) {
                images[i].transform.position = setbackPosition;
            }
            else {
                images[i].transform.position = images[i].transform.position + (new Vector3(0, scrollSpeed * Time.deltaTime, 0));
            }
        }
    }
}

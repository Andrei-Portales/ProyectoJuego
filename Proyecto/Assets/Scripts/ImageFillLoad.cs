using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillLoad : MonoBehaviour
{

    public Image fillImage;
    public float waitingTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount += 1.0f / waitingTime * Time.deltaTime;
    }
}

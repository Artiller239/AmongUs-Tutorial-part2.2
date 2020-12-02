using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadBar : MonoBehaviour
{
    public Slider slider;
    public DownloadTask downloadTask;

    void Update()
    {
        slider.maxValue = 100;
        slider.value = downloadTask.downloadProgress;
    }
}

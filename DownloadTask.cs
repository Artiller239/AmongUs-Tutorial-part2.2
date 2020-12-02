using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadTask : MonoBehaviour
{
    public GameObject downloadCanvas;
    public GameObject uploadCanvas;

    public Text downloadText;
    public GameObject downloadTextHolder;
    public GameObject downloadBar;

    public Text uploadText;
    public GameObject uploadTextHolder;
    public GameObject uploadBar;

    public bool canUpload;
    public bool downloadTaskIsDone;

    int downloadNeeded = 100;
    public int downloadProgress;

    int uploadNeeded = 100;
    public int uploadProgress;

    public MouseLook mouseLook;
    public PlayerMovement playerMovement;
    public TaskManager taskManager;
    public TaskSliderManager TSM;

    void Update()
    {
        downloadText.text = downloadProgress.ToString();
        uploadText.text = uploadProgress.ToString();

        if (downloadProgress == downloadNeeded)
        {
            canUpload = true;
            downloadTextHolder.SetActive(false);
            downloadCanvas.SetActive(false);
            taskManager.haveDownload = true;
            taskManager.taskButton.interactable = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.enabled = true;
            playerMovement.enabled = true;
        }

        if(uploadProgress == uploadNeeded)
        {
            canUpload = false;
            downloadTaskIsDone = true;
            uploadTextHolder.SetActive(false);
            uploadCanvas.SetActive(false);
            taskManager.taskButton.interactable = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.enabled = true;
            playerMovement.enabled = true;
                TSM.TaskComplete(10);
            uploadNeeded = 0;
        }
    }

    public void StartDownload()
    {
        downloadTextHolder.SetActive(true);
        InvokeRepeating("Download", 1, 0.5f);
        downloadBar.SetActive(true);
    }

    public void Download()
    {
        downloadProgress = downloadProgress + 5;
    }

    public void StartUpload()
    {
        uploadTextHolder.SetActive(true);
        InvokeRepeating("Upload", 1, 0.5f);
        uploadBar.SetActive(true);
    }

    public void Upload()
    {
        uploadProgress = uploadProgress + 5;
    }
}

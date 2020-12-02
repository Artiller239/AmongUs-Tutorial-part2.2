using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public Button taskButton;

    public GameObject downloadCanvas;
    public GameObject uploadCanvas;

    public bool haveDownload;
    private bool CanDownload;

    public MouseLook mouseLook;
    public PlayerMovement playerMovement;
    public DownloadTask downloadTask;

    void Start()
    {
        taskButton.interactable = false;
    }

    void Update()
    {
        if (CanDownload == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mouseLook.enabled = false;
                playerMovement.enabled = false;
                downloadCanvas.SetActive(true);
                UnlockMouse();
            }
        }

        if (downloadTask.canUpload == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mouseLook.enabled = false;
                playerMovement.enabled = false;
                uploadCanvas.SetActive(true);
                UnlockMouse();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if((col.tag == "Download"))
        {
            if (haveDownload == false)
            {
                taskButton.interactable = true;
                CanDownload = true;
            }
        }

        if ((col.tag == "Upload"))
        {
            if (downloadTask.canUpload == true)
            {
                taskButton.interactable = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if ((col.tag == "Download"))
        {
            taskButton.interactable = false;
            CanDownload = false;
        }

        if ((col.tag == "Upload"))
        {
            taskButton.interactable = false;
        }
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

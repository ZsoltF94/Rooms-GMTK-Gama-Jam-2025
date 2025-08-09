

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : Singleton<DialogManager>
{


    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;

    public bool isDialog = false;

    private Queue<string> dialogQueue = new Queue<string>();




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ShowNextLine();

    }

    public void StartDialog(string[] lines)
    {
        isDialog = true;
        GameManager.Instance.playerCanMove = false;
        GameManager.Instance.npcsCanMove = false;
        dialogQueue.Clear();

        foreach (string line in lines)
        {
            dialogQueue.Enqueue(line);
        }
        dialogPanel.SetActive(true);
        ShowNextLine();
    }

    private void ShowNextLine()
    {
        if (dialogQueue.Count == 0)
        {
            EndDialog();
            return;
        }
        string currentLine = dialogQueue.Dequeue();
        dialogText.text = currentLine;
    }

    public void EndDialog()
    {
        GameManager.Instance.playerCanMove = true;
        GameManager.Instance.npcsCanMove = true;
        dialogPanel.SetActive(false);
        isDialog = false;
    }
}
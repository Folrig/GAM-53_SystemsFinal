using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanel : MonoBehaviour
{
    [SerializeField] private GameObject commandPrefab;
    [SerializeField] private Image panel;

    private bool hidden = false;
    private List<GameObject> commands = new List<GameObject>();

    public delegate void stringParam(string message);
    public event stringParam CommandClick;

    public void AddCommand(string command)
    {
        GameObject newCommand = Instantiate(commandPrefab, transform);
        Button commandButton = newCommand.GetComponent<Button>();
        if (commandButton == null)
        {
            Debug.LogError("[F" + Time.frameCount + "]: Command prefab does not have a Button component!");
            Destroy(newCommand);
            return;
        }

        Text commandText = newCommand.GetComponentInChildren<Text>();
        if (commandText == null)
        {
            Debug.LogWarning("[F" + Time.frameCount + "]: Command prefab does not have button text.");
        }
        else
        {
            commandText.text = command;
        }

        commandButton.onClick.AddListener(() => CommandClicked(command));
        commands.Add(newCommand);
    }

    public void RemoveAllCommands()
    {
        foreach (GameObject command in commands)
        {
            commands.Remove(command);
            Destroy(command);            
        }
    }

    public void TogglePanel()
    {
        TogglePanel(hidden);
    }

    public void TogglePanel(bool active)
    {
        panel.enabled = active;
        foreach (GameObject command in commands)
        {
            command.SetActive(active);
        }
        hidden = !active;
    }

    // Called when a command button is clicked
    public void CommandClicked(string command)
    {
        if (CommandClick != null)
        {
            CommandClick(command);
        }
    }
}

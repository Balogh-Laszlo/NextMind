[System.Serializable]
public class Control {
    public Control(string controlName, string customEvent)
    {
        ControlName = controlName;
        CustomEvent = customEvent;
    }

    public string ControlName { get; set; }
    public string CustomEvent { get; set; }
}

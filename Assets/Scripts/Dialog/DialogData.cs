using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Dialogdata", fileName = "New Dialog")]
public class DialogData : ScriptableObject
{
    [SerializeField] string[] dialog;

    public string[] GetLines()
    {
        return dialog;
    }
}

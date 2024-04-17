using UnityEngine;
using UnityEditor;

public class OpenPersistentDataFolderEditor : Editor
{
    [MenuItem("Window/Open Persistent Data Folder")]
    static void OpenFolder()
    {
        string persistentDataPath = Application.persistentDataPath;
        EditorUtility.RevealInFinder(persistentDataPath);
    }
}
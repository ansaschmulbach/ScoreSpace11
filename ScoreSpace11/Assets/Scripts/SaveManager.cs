using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager
{
    public SavePB savePB;
    protected string savePath;
    // Start is called before the first frame update
    public SaveManager()
    {
        Debug.Log("A SaveManager is born");
        this.savePath = Application.persistentDataPath + "/save.dat";
        Debug.Log(Application.persistentDataPath + "/save.dat");
        this.savePB = new SavePB();
        this.loadDataFromDisk();
    }

    public void saveDataToDisk()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, savePB);
        file.Close();
    }
    private SavePB CreateSaveFile()
    {
        SavePB savePB = new SavePB();
        savePB.personal_best = GameManager.instance.gameState.personal_best;
        return savePB;
    }
    public void loadDataFromDisk()
    {
        if(File.Exists(savePath))
        {
            Debug.Log("File does indeed exist");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            this.savePB = (SavePB)bf.Deserialize(file);
            file.Close();
        }
    }
    public void SaveRecord()
    {
        this.savePB = CreateSaveFile();
        Debug.Log(savePB.personal_best);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.savePB");
        bf.Serialize(file, savePB);
        file.Close();
    }
}

    

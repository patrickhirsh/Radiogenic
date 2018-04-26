using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

    public string scenename;

    public void loadscene()
    {
        if (scenename == "Main")
            GameManager.Restart();
        SceneManager.LoadScene(scenename);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainPlay : MonoBehaviour
{
    public void LoadGameAgain()
    {
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    
    int breakableBlocks;

    SceneLoader sceneLoader;

    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void addBreakableBlock() {
        breakableBlocks++;
    }

    public void breakBlock() {
        breakableBlocks--;
        if (breakableBlocks<=0) {
            sceneLoader.LoadNextScene();
        }
    }
}

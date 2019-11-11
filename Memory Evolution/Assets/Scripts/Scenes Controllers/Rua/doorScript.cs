﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour {

    Animator animation_;
	// Use this for initialization
	void Start () {
        animation_ = GetComponent<Animator>();
        animation_.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<talks>().falas[2].talked > 0)
        {
            SceneManager.LoadScene("Andar 1");
            ChangeScene();
            animation_.enabled = true;
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.7f);
        
    }
}

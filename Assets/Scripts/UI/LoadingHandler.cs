using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingHandler : MonoBehaviour
{
    public void BeginLoading()
    {
        this.gameObject.SetActive(true);
    }

    public void CompleteLoading()
    {
        this.gameObject.SetActive(false);
    }
}
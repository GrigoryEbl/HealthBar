using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    public void DestroyText()
    {
        Destroy(gameObject);
    }
}

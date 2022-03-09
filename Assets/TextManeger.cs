using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManeger : MonoBehaviour
{
    public TMP_Text plyerhealth;
    // Start is called before the first frame update

    public void Something(float health)
    {
        //Write to the text mesh pro element InfoText
        plyerhealth.text = "health:"+health;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

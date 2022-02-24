using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesLeft : MonoBehaviour
{
    readonly List<Image> lives = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            Debug.Log("image:" + child.name);
            Image image = child.GetComponent<Image>();
            if (image != null)
            {
                lives.Add(image);
                image.enabled = true;
            }
        }
        foreach (Image image in lives)
        {
            Debug.Log(image);
        }
        Debug.Log(lives.Count);
        lives.Sort((Image x, Image y)
            => x.transform.localPosition.x.CompareTo(y.transform.localPosition.x));
        //Invoke("removeLife", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeLife()
    {
        if (lives.Count == 0)
        {
            return;
        }

        Image life = lives[lives.Count - 1];
        life.enabled = false;
        lives.Remove(life);
    }
}

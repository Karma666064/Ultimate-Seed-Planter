using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plant : MonoBehaviour
{
    public List<GameObject> tree = new List<GameObject>();
    public int state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Grow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Grow()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            tree[state].SetActive(false);
            state++;
            tree[state].SetActive(true);
        }
    }
}

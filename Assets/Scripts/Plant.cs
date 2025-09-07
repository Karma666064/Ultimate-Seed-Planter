using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plant : MonoBehaviour
{
    public List<GameObject> tree = new List<GameObject>();
    public int state;
    public float growthTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        int treeStatesCount = tree.Count;
        while (true)
        {
            yield return new WaitForSeconds(growthTime);

            if (state + 1 >= treeStatesCount)
            {
                Debug.Log("Je me casse");
                break;
            }

            tree[state].SetActive(false);
            state++;
            tree[state].SetActive(true);

            Debug.Log("treeStatesCount: " + treeStatesCount);
            Debug.Log("state: " + state);
        }
    }
}

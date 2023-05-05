using System;
using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject treeOne;
    [SerializeField] private GameObject treeBroken;
    [SerializeField] private GameObject treeBrokenTwo;

    private int hitCount;

    public void Hit()
    {
        switch (hitCount)
        {
            case 0:
                treeOne.SetActive(false);
                treeBroken.SetActive(true);
                StartCoroutine((ReSpawn()));
                hitCount++;
                break;
            case 1:
                treeBroken.SetActive(false);
                treeBrokenTwo.SetActive(true);
                hitCount++;
                break;
            case 2:
                treeBrokenTwo.SetActive(false);
                hitCount++;
                break;
        }
    }

    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(3);

        treeOne.SetActive(true);
        treeBroken.SetActive(false);
        treeBrokenTwo.SetActive(false);
        hitCount = 0;
    }
}
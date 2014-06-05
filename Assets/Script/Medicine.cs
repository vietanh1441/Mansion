using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Medicine : MonoBehaviour
{

    private int[] pos = new int[2];
    public List<int[]> list;

    void Start()
    {
        list = new List<int[]>();
    }

    void Update()
    {
        pos[0] = 2;
        pos[1] = 3;
        list.Add(pos);
    }


}
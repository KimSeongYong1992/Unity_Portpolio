using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.PlayerSettings;
using Unity.VisualScripting;

// ��� 
/* 
1. ���� ����/����  
2. ������Ʈ ��ġ/����
3. 
 
 
 
 
 
*/



public class TerrainManager : Singleton<GameManager>
{
    public GameManager Owner;

    public BlockNormal blockNormal;
    public PlayerController playerController;

    public int testRow;
    public int testCol;

    public float fSize;

    private List<List<TerrainBlock>> terrainList = new List<List<TerrainBlock>>();
    private PlayerController gamePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < testRow; ++i)
        {
            terrainList.Add(new List<TerrainBlock>());

            for (int j = 0; j < testCol; ++j)
            {
                Vector3 pos = new Vector3(fSize * (float)i, 0f, fSize * (float)j);
                BlockNormal NewBlock = Instantiate(blockNormal);
                NewBlock.transform.position = pos;
                terrainList[i].Add(NewBlock);
            }
        }

        Vector3 posPlayer = new Vector3(50f, 2f, 50f);
        playerController.transform.position = posPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

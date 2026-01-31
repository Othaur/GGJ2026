using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] List<Nono_Tile> cells;
    [SerializeField] List<bool> solution;

    [SerializeField] GameObject nonoPanel;
    [SerializeField] Nono_Tile tilePrefab;

    bool victory = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FillSolution();

        for (int i = 0; i<100; i++)
        {
            Nono_Tile temp = Instantiate(tilePrefab, Vector2.zero, Quaternion.identity);
            temp.gameObject.transform.SetParent( nonoPanel.gameObject.transform);
            cells.Add(temp);
            
            Debug.Log("Tile activaed " + temp.Activated.ToString());
            
        }

        //DisplayCells();

    }

    // Update is called once per frame
    void Update()
    {
        // DisplayCells();
        if (!victory)
        {
            if (VerifySolution())
            {
                Debug.Log("Victory");
                victory = true;
                for (int i = 0; i < cells.Count; i++)
                {
                    cells[i].GetComponent<UIImageClick>().Deactivate();
                }
            }
        }
    }

    bool VerifySolution()
    {
        //Debug.Log("Verifying");
        
        for (int i = 0; i < cells.Count; i++)
        {
            //Debug.Log(cells[i].ToString() + '-' + solution[i].ToString());
            if (cells[i].Activated != solution[i])
                return false;
        }
        return true;
    }

    void DisplayCells()
    {
        int index = 0;
        string output = "\n";
        for(int i = 0; i< 10; i++)
        {    for (int j = 0; j < 10; j++)
            {
                if (cells[index].Activated)
                {
                    output += "1";
                }
                else
                {
                    output += "0";
                }
                index++;
            }
            output += "\n";
        }

        Debug.Log(output +  "$$$" + index + "***" + cells.Count);
    }

    void FillSolution()
    {
        solution = new List<bool>
        {
            false,  false,  false,  false,  true,   true,   false,  false,  false,  false,
            false,  false,  false,  true,   true,   true,   true,   false,  false,  false,
            false,  false,  true,   true,   true,   true,   true,   true,   false,  false,
            false,  true,   false,  true,   false,  false,  true,   false,  true,   false,
            false,  true,   false,  false,  true,   true,   false,  false,  true,   false,
            false,  true,   true,   true,   true,   true,   true,   true,   true,   false,
            true,   true,   true,   false,  false,  false,  false,  true,   true,   true,
            false,  true,   true,   true,   false,  false,  true,   true,   true,   false,
            false,  false,  true,   true,   true,   true,   true,   true,   false,  false,
            false,  true,   true,   false,  false,  false,  false,  true,   true,  false
        };
    }
}

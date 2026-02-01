using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NonoPuzzleManager : MonoBehaviour
{
    [SerializeField] List<UIImageClick> cells;
    [SerializeField] List<bool> solution;
    [SerializeField] List<bool> prefill;

    [SerializeField] GameObject nonoPanel;
    [SerializeField] GameObject nextPanel;
    [SerializeField] UIImageClick tilePrefab;

    bool victory = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextPanel.SetActive(false);
        FillSolution();
        PrefillCells();

        for (int i = 0; i < 100; i++)
        {
            UIImageClick temp = Instantiate(tilePrefab, Vector2.zero, Quaternion.identity);
            temp.gameObject.transform.SetParent(nonoPanel.gameObject.transform);
                       
            cells.Add(temp);
          //  Debug.Log("Tile activaed " + temp.Activated.ToString());

        }

        for (int i = 0; i < 100; i++)
        {
            if (prefill[i])
            {
                Debug.Log("Prefill index" + i);
                cells[i].Prefill();
                // temp.Toggle();
            }
        }
        //DisplayCells();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateVisual();
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
                DisplayVictory();
            }
        }

    }

    void UpdateVisual()
    {
        //for (int i = 0; i < cells.Count; i++)
        //{
        //    cells[i].GetComponent<UIImageClick>().Deactivate();
        //}
    }

    void DisplayVictory()
    {
        nextPanel?.SetActive(true);
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

    void PrefillCells()
    {
        prefill = new List<bool>
        {
            false,  false,  false,  false,  false,  false,  false,  false,  false,  false,
            false,  false,  false,  false,  true,   false,  true,   false,  false,  false,
            false,  false,  true,   true,   true,   true,   true,   true,   false,  false,
            false,  true,   false,  true,   false,  false,  true,   false,  true,   false,
            false,  true,   false,  false,  true,   true,   false,  false,  true,   false,
            false,  true,   true,   true,   true,   true,   true,   true,   true,   false,
            true,   true,   true,   false,  false,  false,  false,  true,   true,   true,
            false,  true,   true,   true,   false,  false,  true,   true,   true,   false,
            false,  false,  true,   true,   true,   true,   true,   true,   false,  false,
            false,  false,  false,  false,  false,  false,  false,  true,   true,  false
        };

    }
}

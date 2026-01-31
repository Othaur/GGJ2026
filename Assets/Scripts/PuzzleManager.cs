using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] bool[] solution;

    [SerializeField] GameObject nonoPanel;
    [SerializeField] Nono_Tile tilePrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //solution = { true,false,true,true};

        for (int i = 0; i<121; i++)
        {
            Nono_Tile temp = Instantiate(tilePrefab, Vector2.zero, Quaternion.identity);
            temp.gameObject.transform.SetParent( nonoPanel.gameObject.transform);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

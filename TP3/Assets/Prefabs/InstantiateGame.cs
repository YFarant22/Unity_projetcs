using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateGame : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boxPoint;

    private List<GameObject> walls = new List<GameObject>();
    private List<GameObject> boxes = new List<GameObject> (); 
    
    [SerializeField] private Sprite squareSprite;
    [SerializeField] private Sprite triangleSprite;
    [SerializeField] private Sprite circleSprite;

    private Color orange = new Color32(204, 153, 76, 255); 
    private Color brown = new Color32(130, 77, 4, 255); 
    private Color blue = new Color32(18, 165, 231, 255);
    
    private int width_map = 10;
    private int height_map = 10;
    
    void instantiate_boxPoint(int x, int y)
    {
        GameObject temp = Instantiate(boxPoint);
        temp.transform.position = new Vector3(x, y);
       // temp.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        temp.name = "point";

        SpriteRenderer tempMaterial = temp.AddComponent<SpriteRenderer>();
        tempMaterial.sprite = circleSprite;
        tempMaterial.color = Color.green;
    }
    
    void instantiate_box(int x, int y)
    {
        GameObject temp = Instantiate(square);
        temp.transform.position = new Vector3(x, y);
        temp.name = "box";

        SpriteRenderer tempMaterial = temp.AddComponent<SpriteRenderer>();
        tempMaterial.sprite = squareSprite;
        tempMaterial.color = Color.black;
        boxes.Add(temp);
    }
    void instantiate_player(int x, int y)
    {
        GameObject temp = Instantiate(player);
        temp.transform.position = new Vector3(x, y);
        temp.name = "player";

        SpriteRenderer tempMaterial = temp.AddComponent<SpriteRenderer>();
        tempMaterial.sprite = triangleSprite;
        tempMaterial.color = blue;
    }
    
    void instantiate_wall(int x, int y)
    {
        GameObject temp = Instantiate(square);
        temp.transform.position = new Vector3(x, y);
        temp.name = $"wall {x}, {y}";

        SpriteRenderer tempMaterial = temp.AddComponent<SpriteRenderer>();
        tempMaterial.sprite = squareSprite;
        tempMaterial.color = brown;
        walls.Add(temp);
    }
    
    void instantiate_floor(int x, int y)
    {
        GameObject temp = Instantiate(square);
        temp.transform.position = new Vector3(x, y);
        temp.name = $"floor {x}, {y}";

        SpriteRenderer tempMaterial = temp.AddComponent<SpriteRenderer>();
        tempMaterial.sprite = squareSprite;
        tempMaterial.color = orange;
    }
    private void create_map()
    {
        for (int y = 0; y <= height_map; y++)
        {
            for (int x = 0; x <= width_map; x++)
            {
                if (x == 0 || x > width_map - 1 ||y == 0 || y > height_map - 1 )
                    instantiate_wall(x, y);
                else   
                    instantiate_floor(x, y);
            }
        }
    }
    
    // Start is called before the first frame update-
    void Start()
    {
        // create_map();
        // instantiate_player(1, 1);
        // instantiate_box(5, 5);
        instantiate_boxPoint(6, 1);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> get_boxes()
    {
        return (boxes);
    }
    
    public List<GameObject> get_walls()
    {
        return (walls);
    }
}
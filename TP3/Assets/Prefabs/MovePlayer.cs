using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    public InstantiateGame game;
    private List<GameObject> walls = new List<GameObject>();
    private List<GameObject> boxes = new List<GameObject> (); 
    
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameInstance").GetComponent<InstantiateGame>();
        walls = game.get_walls();
        boxes = game.get_boxes();
        Debug.Log(walls[0]);
    }

    GameObject search_in_list(List<GameObject> list, Vector3 pos)
    {
        foreach (var obj in list)
        {
            if (obj.transform.position == pos)
            {
                return (obj);
            }
        }
        return null;
    }
    
    bool is_there_a_wall(Vector3 pos)
    {
        foreach (var obj in walls)
        {
            if (obj.transform.position == pos)
            {
                return (true);
            }
        }
        return false;
    }
    
    void allow_movement(Vector3 direction)
    {
        if (!is_there_a_wall(transform.position + direction))
        {
            transform.position += direction;
        }
    }
    
    private void player_movements()
    {
        if (Input.GetKeyDown("w"))
        {
           allow_movement(new Vector3(0, 1, 0));
        } else if (Input.GetKeyDown("s"))
        {
            allow_movement(new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown("d"))
        {
           allow_movement(new Vector3(1, 0, 0));
        } else if (Input.GetKeyDown("a"))
        {
            allow_movement(new Vector3(-1, 0, 0));
        }
    }
    
    // Update is called once per frame
    void Update()
    {
       player_movements();
    }
}

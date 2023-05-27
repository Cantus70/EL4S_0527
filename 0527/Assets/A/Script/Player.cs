using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> number = new List<GameObject>();
    int holdmax = 3;

    private Vector2 mousePos;
    private Vector3 objPos;

    HaveNumber haveNumber;
    Keisan keisan;

    void Start()
    {
        Cursor.visible = true;
        keisan = GetComponent<Keisan>();
        haveNumber = HaveNumber.none;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var obj = GetGameObject();
            if (number.Count<holdmax && !number.Contains(obj) && obj)
            {
                switch (haveNumber)
                {
                    case HaveNumber.none:
                        if (obj.tag == "Number")
                        {
                            keisan.SetNumbers(obj, haveNumber);
                            haveNumber = HaveNumber.haveNumber;

                            AddObject(obj);
                        }
                        break;

                    case HaveNumber.haveNumber:
                        if (obj.tag == "Operator")
                        {
                            keisan.SetNumbers(obj, haveNumber);
                            haveNumber = HaveNumber.haveOperator;

                            AddObject(obj);
                        }
                        break;

                    case HaveNumber.haveOperator:
                        if (obj.tag == "Number")
                        {
                            keisan.SetNumbers(obj, haveNumber);
                            haveNumber = HaveNumber.none;

                            AddObject(obj);
                            Delete();
                        }
                        
                        break;
                }
            }
        }
        else
        {
            if(number.Count > 0)
            {
                Relese();
                number.Clear();

                keisan.Relese();
                haveNumber = HaveNumber.none;
            }
        }

        mousePos = Input.mousePosition;
        objPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1));
        transform.position = objPos;

        foreach(GameObject obj in number)
        {
            obj.transform.position = objPos;
        }
    }

    private GameObject GetGameObject()
    {
       
            RaycastHit2D hit =
            Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


        if (hit.collider != null)
        {
            if(!hit.collider.gameObject.CompareTag("EditorOnly"))
            {
                return hit.collider.gameObject;
            }
            
        }

        return null;
    }

    void AddObject(GameObject gameObject)
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        number.Add(GetGameObject());
        gameObject.layer = 2;
    }

    void Relese()
    {
        foreach (GameObject obj in number)
        {
            obj.layer = 0;
            Collider2D Collider2D =  obj.GetComponent<Collider2D>();
            Collider2D.isTrigger = false;
        }
    }

    void Delete()
    {
        Relese();
        foreach (GameObject obj in number)
        {
            if(obj.tag == "Number")
            Destroy(obj);
        }
        number.Clear();
    }
}


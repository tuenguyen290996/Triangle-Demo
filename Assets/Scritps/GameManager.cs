using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject point;
    public GameObject pointContainer;

    int pointID;    
    int STT;
    double space2Point;
    //public Vector3 pointPos;



    PointPos m_pp;

    //public override void Awake()
    //{
    //    MakeSingleton(false);
    //}
   

    private void Start()
    {
        m_pp = FindObjectOfType<PointPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

            Vector3 pointPos = new Vector3(worldPoint.x, worldPoint.y, point.transform.position.z);


            //if (space2Point <= 2) return;

            Debug.Log(pointPos);

            pointID++;

            Dictionary<int, object> PointPosDic = new()
            {
                { pointID, pointPos }
            };

            foreach (KeyValuePair<int, object> item in PointPosDic)
            {
                Debug.Log(item.Key + "\t" + item.Value);
            }

            SpawnPoint(pointPos);

            

            
        }

    }
    public void SpawnPoint(Vector3 position)
    {
        GameObject PointClone = Instantiate(point, position,Quaternion.identity);
        PointClone.transform.parent = pointContainer.transform;
        STT++;
        PointClone.name = "Point_" + STT; 
    }    
   

    static double squareRoot(int number)
    {
        double temp;
        double sr = number / 2;
        
        do
        {
            temp = sr;
            sr = (temp + (number / temp)) / 2;
        } while ((temp - sr) != 0);
        return sr;
    }
}

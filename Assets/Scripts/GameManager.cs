using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Pen Canvas")]
    [SerializeField] private PenCanvas penCanvas;

    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;

    [Header("Lines")]
    [SerializeField] private GameObject linePrefab;
    [SerializeField] Transform lineParent;

    [Header("Info")]  
    [SerializeField] private Text areaText;

    public Material mat;

    int dotId;
    private Vector2 currentDot;
    private LineController currentLine;
    private int clickCount;
    private LineRenderer lineRend;
    private float semiPerimeter, area;
    private Mesh mesh;
    Vector3[] vertices;

    Dictionary<int, DotController> dotDic = new Dictionary<int, DotController>();

    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 0;
        clickCount = 0;
        areaText.text = "Area = " + area;
        mesh = new Mesh();
        vertices = new Vector3[3];
        // Event khi click vao PenCanvas
        penCanvas.OnPenCanvasleftClickEvent += AddDot;
        penCanvas.OnPenCanvasRightClickEvent += EndCurrentLine;
    }

    private void EndCurrentLine()
    {
        //lineRend.positionCount = 0;
    }

    private void AddDot()
    {
        DotController dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent).GetComponent<DotController>();
        dot.OnDragEvent += MoveDot;
        dot.OnRightClickEvent += SelectDotAndDrawLine;
        
        dotId++;
        dotDic.Add(dotId, dot);
        //foreach (KeyValuePair<int, DotController> item in dotDic)
        //{
        //    Debug.Log(item.Key + "\t" + item.Value.transform.position);
        //}
    }

    private void SelectDotAndDrawLine(DotController dot)
    {
        //Destroy(dot.gameObject);
        currentDot = dot.transform.position;
        lineRend.positionCount += 1;
        clickCount += 1;

        //if (currentLine == null)
        //{
        //    currentLine = Instantiate(lineParent, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
        //}



        switch (clickCount)
        {
            //Toa do diem dau tien
            case 1:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(0, new Vector2(currentDot.x, currentDot.y));
                vertices[0] = new Vector3(currentDot.x, currentDot.y);
                break;
            //Toa do diem thu 2
            case 2:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(1, new Vector2(currentDot.x, currentDot.y));
                vertices[1] = new Vector3(currentDot.x, currentDot.y);
                break;
            //Toa do diem thu 3
            case 3:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(2, new Vector2(currentDot.x, currentDot.y));
                vertices[2] = new Vector3(currentDot.x, currentDot.y);
                break;
            //Toa do diem thu 4
            case 4:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(3, new Vector2(currentDot.x, currentDot.y));
                semiPerimeter = (
                            (lineRend.GetPosition(0) - lineRend.GetPosition(1)).magnitude +
                            (lineRend.GetPosition(1) - lineRend.GetPosition(2)).magnitude +
                            (lineRend.GetPosition(2) - lineRend.GetPosition(0)).magnitude) * 0.5f;
                //Tinh dien tich tam giac
                area = Mathf.Sqrt(semiPerimeter *
                    (semiPerimeter - (lineRend.GetPosition(0) - lineRend.GetPosition(1)).magnitude) *
                    (semiPerimeter - (lineRend.GetPosition(1) - lineRend.GetPosition(2)).magnitude) *
                    (semiPerimeter - (lineRend.GetPosition(2) - lineRend.GetPosition(0)).magnitude)
                    );

                areaText.text = "Area = " + area;

                mesh.vertices = vertices;

                mesh.triangles = new int[] { 0, 1, 2 };

                GetComponent<MeshRenderer>().material = mat;

                GetComponent<MeshFilter>().mesh = mesh;

                break;
            case 5:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(4, new Vector2(currentDot.x, currentDot.y));
                break;
            case 6:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(5, new Vector2(currentDot.x, currentDot.y));
                break;
            case 7:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(6, new Vector2(currentDot.x, currentDot.y));
                break;
            case 8:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(7, new Vector2(currentDot.x, currentDot.y));
                break;
            case 9:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(8, new Vector2(currentDot.x, currentDot.y));
                break;
            case 10:
                dot.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                lineRend.SetPosition(9, new Vector2(currentDot.x, currentDot.y));
                break;
            //Dat lai bo dem
            case 11:
                lineRend.positionCount = 0;
                clickCount = 0;
                //area = 0f;
                //areaText.text = "Area = " + area;
                break;

        }
    }

    private void MoveDot(DotController dot)
    {
        dot.transform.position = GetMousePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Left Click


        }


    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}

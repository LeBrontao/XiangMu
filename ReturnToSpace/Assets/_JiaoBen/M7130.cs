using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M7130 : MonoBehaviour
{

    /// <summary>
    /// 获取砂轮
    /// </summary>
    public GameObject shaLun;

    /// <summary>
    /// 获取上下移动转轮
    /// </summary>
    public GameObject zhuanLun;

    /// <summary>
    /// 上移移动的磨床架
    /// </summary>
    public GameObject moChuangJia;

    public float shang = 5f;
    public float xia = 1f;


    /// <summary>
    /// 是否转动转轮
    /// </summary>
    private bool isZhuanLun = false;

    /// <summary>
    /// 是否上升，默认上升
    /// </summary>
    private bool isShangXia = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //砂轮绕z轴旋转
        shaLun.transform.Rotate(new Vector3(0, 0, 50));

        MouseDown0();
        MouseDown1();
    }

    /// <summary>
    /// 点击鼠标左键磨床上升
    /// </summary>
    void MouseDown0()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("按下");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                //Debug.Log("射线发出");
                if (Hit.collider.gameObject.tag == "ZhuanLun")
                {
                    //Debug.Log("检测到转轮");

                    if (isZhuanLun == false)
                    {
                        isZhuanLun = true;
                        ShangSheng();
                    }
                    else
                    {
                        isZhuanLun = false;
                    }
                }
            }
        }
        ZhuanLun();

    }

    /// <summary>
    /// 点击鼠标右键磨床下降
    /// </summary>
    void MouseDown1()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("按下");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                //Debug.Log("射线发出");
                if (Hit.collider.gameObject.tag == "ZhuanLun")
                {
                    //Debug.Log("检测到转轮");

                    if (isZhuanLun == false)
                    {
                        isZhuanLun = true;
                        XiaJiang();
                    }
                    else
                    {
                        isZhuanLun = false;
                    }
                }
            }
        }
        ZhuanLun();

    }

    /// <summary>
    /// 砂轮转动的方法
    /// </summary>
    void ZhuanLun()
    {
        if (isZhuanLun)
        {
            zhuanLun.transform.Rotate(new Vector3(0, 0, 10));
        }
    }

    /// <summary>
    /// 磨床架上升
    /// </summary>
    void ShangSheng()
    {
        while (isZhuanLun)
        {
            moChuangJia.transform.position += new Vector3(0, 0.01f, 0);
            if (moChuangJia.transform.position.y < shang)
            return;
        }
       
    }

    /// <summary>
    /// 磨床架下降
    /// </summary>
    void XiaJiang()
    {
        while (isZhuanLun)
        {
            moChuangJia.transform.position -= new Vector3(0, 0.01f, 0);
            if (moChuangJia.transform.position.y < shang)
                return;
        }

    }
}

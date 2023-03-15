using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class BuildCubes : MonoBehaviour
{
    private int x; //������� ������������ �������
    private int y;

    public GameObject cube;
    public GameObject sphere;
    RaycastHit hit; //����������� �����, ���� ����� ���������� � �����������
    private Ray ray; //�����������, ���� ����� ����������
    private Transform some_transform;

    void Start()
    {
        CreateCube();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    void CreateCube()
    {
        x = 20;
        y = 1;

        for (int i = 0; i <= x; i++)
        {
            for (int j = 0; j <= y; j++)
            {
                GameObject.Instantiate(cube, new Vector3(i - 5f, j + 3.5f, 0f), Quaternion.identity); //�������� ������� //Quaternion.identity - �������
            }
        }
    }

    void Shot()
    { 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) //ray - ���, ������� ������������ � ������ ������ //hit - ������ //���� �� ���� ���� ���-�� �������n��, �� Raycast ������ true
        {
            GameObject bullet = GameObject.Instantiate(sphere, transform.position, Quaternion.identity);

            Vector3 dir = hit.point - transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(dir * 100);
        }
    }
}

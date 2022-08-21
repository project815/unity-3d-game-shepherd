using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�
    public CharacterController characterController; // ĳ���� ��Ʈ�ѷ�
    public Vector3 movePoint; // �̵� ��ġ ����
    public Quaternion quaternion;
    public Camera mainCamera; // ���� ī�޶�


    bool isInWater;
    void Start()
    {
        speed = 4.0f;
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        quaternion = transform.rotation;

    }

    void Update()
    {
        // ��Ŭ�� �̺�Ʈ�� ���Դٸ�
        if (Input.GetMouseButtonUp(0))
        {
            // ī�޶󿡼� �������� ���.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // Scence ���� ī�޶󿡼� ������ ������ ������ Ȯ���ϱ�
            Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red, 1f);

            // �������� ������ �¾Ҵٸ�
            if (Physics.Raycast(ray, out RaycastHit raycastHit) && gameObject.tag != "Water")
            {
                // ���� ��ġ�� �������� ����
                movePoint = raycastHit.point;
            }
        }

        // ���������� �Ÿ��� 0.1f ���� �ִٸ�
        if (Vector3.Distance(transform.position, movePoint) > 0)
        {
            // �̵�
            Move();
        }

    }

    void Move()
    {
        // thisUpdatePoint �� �̹� ������Ʈ(������) ���� �̵��� ����Ʈ�� ��� ������.
        // �̵��� ����(�̵��� ��-���� ��ġ) ���ϱ� �ӵ��� �ؼ� �̵��� ��ġ���� ����Ѵ�.
        //Vector3 thisUpdatePoint = (movePoint - transform.position).normalized * speed;
        //// characterController �� ĳ���� �̵��� ����ϴ� ������Ʈ��.
        //// simpleMove �� �ڵ����� �߷��� ����ؼ� �̵������ִ� �޼ҵ��.
        //// ������ �̵��� ����Ʈ�� �������ָ� �ȴ�.
        //characterController.SimpleMove(thisUpdatePoint);
        transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            isInWater = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            isInWater = false;
        }
    }
}
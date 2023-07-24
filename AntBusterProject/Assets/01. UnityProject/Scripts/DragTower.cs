using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    // �巡�װ� ������ �������� Ȯ���ϴ� bool ����

    public CreateTower createTower;

    private DragTower dragTower_;
    private BuildTowerAttack buildTowerAttack_;

    private void Awake()
    {
        dragTower_ = gameObject.GetComponent<DragTower>();
        buildTowerAttack_ = gameObject.GetComponent<BuildTowerAttack>();
    }

    // �� ������ �� ȣ��Ǵ� �޼ҵ�
    void Update()
    {
        // ����ڰ� ���콺 ���ʹ�ư�� ������ �� true�� ��ȯ�� if�� �� �ڵ� ����
        if (Input.GetMouseButtonDown(0))
        {
            // �巡�װ� ������ ���·� ����
            GameManager.instance.draggable = true;
            // Raycast�� ������ �ε��� ������Ʈ ��ȯ
            RaycastHit hit = CastRay();

            // �ε��� ������Ʈ�� ���� ��ũ��Ʈ update�޼ҵ尡 ����ǰ� �ִ� ������Ʈ�� ���
            if (hit.transform == transform)
            {
                buildTowerAttack_.enabled = false;
            }
        }

        // ����ڰ� ���콺 ���ʹ�ư�� ���� ���¿��� �հ����� ������ �� true�� ��ȯ�� if�� �� �ڵ� ����
        if (Input.GetMouseButtonUp(0))
        {
            // �巡�װ� �Ұ����� ���·� ����
            GameManager.instance.draggable = false;

            dragTower_.enabled = false;
            buildTowerAttack_.enabled = true;

            // �߰��� �ڵ�
            // ���� ������ createCube ��ũ��Ʈ�� �ִٸ� if�� �� �ڵ� ����
            if (createTower != null)
            {
                // �ش� ��ũ��Ʈ �� cube null ó��
                createTower.tower = null;
                // �ش� ��ũ��Ʈ ���� ����
                createTower = null;
            }
        }

        // ���� �巡�װ� ������ ������ ��� if�� �� �ڵ� ����
        if (GameManager.instance.draggable == true)
        {
            // ���� ȭ�鿡 �ִ� ���콺 Ŀ���� x,y ��ǥ�� ī�޶� ���� ���� �� ��ũ��Ʈ�� ����Ǵ� ������Ʈ�� z��ǥ�� ����� ScreenPoint Vector3 position �� ����
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            // ������Ʈ�� �̵��� �� ������ x,z ��ǥ�� ���� WorldPoint Vector3 position ����
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            // �� worldPosition�� x,z ��ǥ�� ����ϰ� ���� y��ǥ�� ������ ������Ʈ �̵�
            transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
        }
    }

    // Raycast�� �浹�� ������ ��ȯ�ϴ� �޼ҵ�
    private RaycastHit CastRay()
    {
        // ���콺 Ŀ���� ����Ű�� ī�޶� �������ϴ� ���� �հ��� ��ġ ScreenPoint Vector3 position
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        // ���콺 Ŀ���� ����Ű�� ī�޶� �������ϴ� ���� �������� ��ġ ScreenPoint Vector3 position
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        // �� ��ġ�� WorldPosition���� ����
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        // RaycastHit ������ ���� ���� ����
        RaycastHit hit;
        // ���� worldMousePosNear���� �����ϰ� worldMousePosFar�� ���ϴ� Raycast�� �����Ѵ�
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        // ������ ���� hit ��ȯ
        return hit;
    }
}

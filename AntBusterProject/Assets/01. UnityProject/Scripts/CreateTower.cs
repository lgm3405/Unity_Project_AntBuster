using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    // ������ cube Prefab
    public Transform towerToCreate;

    // ������ Prefab�� ������ ����
    public Transform tower;

    // Prefab ���� �޼ҵ�
    public void DragTowerCreate()
    {
        if (GameManager.instance.isGameOver == true) { return; }

        if (GameManager.instance.money < GameManager.instance.randomTowerPay) { return; }

        // ���� �����Ǿ� �巡�� ���� Prefab�� ���� ��� if�� �� �ڵ� ����
        if (tower == null)
        {
            // ���� ȭ�鿡 �ִ� ���콺 Ŀ���� x,y ��ǥ�� ī�޶� ���� ���� �� ��ũ��Ʈ�� ����Ǵ� ������Ʈ�� z��ǥ�� ����� ScreenPoint Vector3 position �� ����
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            // ������Ʈ�� �̵��� �� ������ x,z ��ǥ�� ���� WorldPoint Vector3 position ����
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            // Prefab�� �����ϰ� cube ������ ����
            tower = Instantiate(towerToCreate, new Vector3(worldPosition.x, 1f, worldPosition.y), Quaternion.identity);

            // �� ��ũ��Ʈ�� ������ Prefab�� �����ϰ� ����
            tower.GetComponent<DragTower>().createTower = this;

            // �ش� ������Ʈ ��ũ��Ʈ�� draggable ������ true�� ������ ���콺�� ���� ������ �� �ְ� �����
            //tower.GetComponent<DragTower>().GameManager.instance.draggable = true;
            GameManager.instance.draggable = true;
        }
    }
}

using UnityEngine;

public class TaichiSlots : MonoBehaviour
{
    public int count;
    public GameObject taichiPrefab;
    public GameObject ghost;
    public float rowDistance;

    void Start()
    {
        int front = 2 * count / 3;
        int rear = count - front;
        float zstep = -rowDistance;

        createRow(front, zstep, taichiPrefab);
        zstep -= rowDistance;
        createRow(rear, zstep, taichiPrefab);
    }

    void createRow(int num, float z, GameObject pf)
    {
        float pos = 1 - num;
        for (int i = 0; i < num; ++i) {
            Vector3 position = ghost.transform.TransformPoint(new Vector3 (pos,0f,z));
            GameObject temp = (GameObject)Instantiate(pf, position, ghost.transform.rotation); 
            temp.AddComponent<Formation>();
            temp.GetComponent<Formation>().pos = new Vector3 (pos,0,z);
            temp.GetComponent<Formation>().target = ghost;
            pos += 2f;
        }
    }
}

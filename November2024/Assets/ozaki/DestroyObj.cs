using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public void Destroy()
    {
        Debug.Log("������");

        Destroy(gameObject);
    }
}

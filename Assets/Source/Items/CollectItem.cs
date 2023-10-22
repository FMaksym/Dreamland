using UnityEngine;

public class CollectItem : MonoBehaviour, ICollectable
{
    [SerializeField] private string _nameOfItem;
    [SerializeField] private int _score;

    public void Collect(Inventory inventory)
    {
        inventory.AddItem(_nameOfItem, 1);
    }

    public int GetScore()
    {
        return _score;
    }
}

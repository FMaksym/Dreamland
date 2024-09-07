using UnityEngine;

public class CollectItem : MonoBehaviour, ICollectable
{
    [SerializeField] private string _nameOfItem;
    [SerializeField] private int _score;
    [SerializeField] private int amount = 1;

    public void Collect(Inventory inventory)
    {
        inventory.AddItem(_nameOfItem, amount);
    }

    public int GetScore()
    {
        return _score;
    }
}

using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private float radiusScorePosition;
    [SerializeField] private float heightScorePosition;
    [SerializeField] private Transform[] _scores;
    [SerializeField] private PlayerScore playerScore;

    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
        if (collectable != null)
        {
            CollectItem(other, collectable);
            DataManager.instance.GameDataChanged();
        }
    }

    private void CollectItem(Collider other, ICollectable collectable)
    {
        collectable.Collect(inventory);
        playerScore.AddScore(collectable.GetScore());

        _scores[_index].gameObject.SetActive(true);
        _scores[_index].position = transform.position + new Vector3(Random.Range(-radiusScorePosition, radiusScorePosition),
            heightScorePosition,
            Random.Range(-radiusScorePosition, radiusScorePosition));

        if (_index < 4)
        {
            _index++;
        }
        else
        {
            _index = 0;
        }

        other.gameObject.SetActive(false);
    }
}

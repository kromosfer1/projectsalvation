using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Color _hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = _sr.color;
    }

    private void OnMouseEnter()
    {
        _sr.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null)
            return;
        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.Cost > CurrencyManager.main.Currency)
        {
            Debug.Log("Cant afford tower");
            return;
        }

        CurrencyManager.main.DecreaseCurrency(towerToBuild.Cost);

        tower = Instantiate(towerToBuild.TowerPrefab, transform.position, Quaternion.identity);
    }
}

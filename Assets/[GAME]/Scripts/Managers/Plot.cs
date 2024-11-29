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
        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }
}

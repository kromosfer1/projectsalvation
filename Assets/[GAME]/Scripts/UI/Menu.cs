using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI _currencyUI;
    [SerializeField] Animator _animator;

    private bool isMenuOpen = true;

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        _animator.SetBool("MenuOpen", isMenuOpen);
    }

    private void OnGUI()
    {
        _currencyUI.text = CurrencyManager.main.Currency.ToString();
    }

    public void SetSelected()
    {

    }

}

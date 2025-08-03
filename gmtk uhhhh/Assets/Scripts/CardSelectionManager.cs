using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public static CardSelectionManager Instance;

    private List<Card> selectedCards = new List<Card>();
    public int maxSelected = 5;

    private Coroutine resetCoroutine;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool TrySelect(Card card)
    {
        if (selectedCards.Count >= maxSelected)
            return false;

        selectedCards.Add(card);
        return true;
    }

    public void Deselect(Card card)
    {
        if (selectedCards.Contains(card))
            selectedCards.Remove(card);
    }

    public void ClearAll()
    {
        foreach (var card in selectedCards)
            card.Deselect();

        selectedCards.Clear();
    }

    public int Count => selectedCards.Count;

    // Call this to start the 1-second reset timer
    public void ResetAfterDelay(float delay)
    {
        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);
        resetCoroutine = StartCoroutine(ResetSelectionCoroutine(delay));
    }

    private IEnumerator ResetSelectionCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearAll();
        resetCoroutine = null;
    }
    
}

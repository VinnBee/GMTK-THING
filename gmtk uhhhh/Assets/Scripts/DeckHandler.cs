using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHandler : MonoBehaviour
{
    [SerializeField] public uint handSize;
    [SerializeField] public uint deckSize;
    [SerializeField] public Transform cardGrp;

    private Transform deckTransform;

    void Start()
    {
        deckTransform = this.gameObject.transform.GetChild(7); // The deck container
        StartCoroutine(DelayedFill());
    }

   void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
    {
        FillHand();

        // Start/reset the 1-second timer to clear selected cards
        CardSelectionManager.Instance.ResetAfterDelay(1f);
    }
}

    private IEnumerator DelayedFill()
    {
        yield return new WaitForSeconds(0.1f); // short delay for setup
        FillHand();
    }

    private void FillHand()
    {
        HorizontalCardHolder cardHolder = cardGrp.GetComponent<HorizontalCardHolder>();

        for (int i = 0; i < handSize; i++)
        {
            if (deckSize == 0)
            {
                this.gameObject.SetActive(false);
                break;
            }

            Transform cardSlot = cardGrp.transform.GetChild(i);
            if (cardSlot.childCount == 0)
            {
                int rcard = Random.Range(0, (int)deckSize);
                Transform card = deckTransform.GetChild(rcard);

                card.gameObject.SetActive(true);
                card.SetParent(cardSlot);
                card.localPosition = Vector3.zero;

                deckSize -= 1;
            }
        }

        cardHolder.EnslaveChildren();
    }
}

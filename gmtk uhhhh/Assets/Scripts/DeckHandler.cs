using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public uint handSize;
    [SerializeField] public uint deckSize;
    [SerializeField] public Transform cardGrp;

    private Transform deckTransform;

    void Start()
    {
        deckTransform = this.gameObject.transform.GetChild(7); // The deck container
        FillHand();
    }

    void Update() { }

    public void OnPointerClick(PointerEventData unused)
    {
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

            float rcard = Random.Range(0, deckSize - 1);
            Transform card = deckTransform.GetChild((int)rcard);
            Transform cardSlot = cardGrp.transform.GetChild(i);

            // Instead of destroying, return the old card to the deck and deactivate it
            if (cardSlot.childCount > 0) {
                Transform oldCard = cardSlot.GetChild(0);
                oldCard.SetParent(deckTransform);
oldCard.position = new Vector3(213, -150, 0);
oldCard.gameObject.SetActive(false);
            }

            // Move new card into the slot
            card.gameObject.SetActive(true);
            card.SetParent(cardSlot);
            card.localPosition = Vector3.zero;

            deckSize -= 1;
        }

        cardHolder.EnslaveChildren();
    }
}

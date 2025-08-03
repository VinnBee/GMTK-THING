using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DeckHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public uint handSize;
    [SerializeField] public uint deckSize;
    [SerializeField] public Transform cardGrp;
    // Callbacks

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnPointerClick(PointerEventData unused) { FillHand(); }


    // Fill deck (PlayingCardGroup) with cards within deck
    private void FillHand() {

        Transform cards = this.gameObject.transform.GetChild(7);
        HorizontalCardHolder cardHolder = cardGrp.GetComponent<HorizontalCardHolder>();

        for(int i = 0; i < handSize; i++) {

            if(deckSize == 0) {
                this.gameObject.SetActive(false);
            }

            float rcard = Random.Range(0, deckSize - 1);
            Transform card = cards.GetChild((int)rcard);
            Transform cardSlot = cardGrp.transform.GetChild(i);

            if(cardSlot.childCount > 0) { Object.Destroy(cardSlot.GetChild(0).gameObject); }

            card.gameObject.SetActive(true);
            card.SetParent(cardSlot);
            card.localPosition = Vector3.zero;

            deckSize -= 1;

        }

        cardHolder.EnslaveChildren();

    }
}

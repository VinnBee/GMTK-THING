using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DeckHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] uint handSize;
    [SerializeField] uint deckSize;
    // Callbacks

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnPointerClick(PointerEventData unused) { FillHand(); }


    // Fill deck (PlayingCardGroup) with cards within deck
    private void FillHand() {

        // update t
        GameObject cardGrp = GameObject.Find("/Canvas/PlayingCardGroup");
        Transform cards = this.gameObject.transform.GetChild(7);

        for(int i = 0; i < handSize; i++) {

            float rcard = Random.Range(0, deckSize - 1);
            Transform card = cards.GetChild((int)rcard);
            Transform cardSlot = cardGrp.transform.GetChild(i);

            if(cardSlot.childCount > 0) { Object.Destroy(cardSlot.GetChild(0).gameObject); }

            card.gameObject.SetActive(true);
            card.SetParent(cardSlot);
            card.localPosition = Vector3.zero;

            deckSize -= 1;

            if(deckSize == 0) {
                this.gameObject.SetActive(false);
            }

        }

    }
}

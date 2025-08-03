using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script populates the deck.
// This may be a placeholder?
public class CardGen : MonoBehaviour
{
    [SerializeField] private uint deckSize;
    [SerializeField] private GameObject cardPrefab;

    // Start is called before the first frame update
    void Start() {

        for(uint i = 0; i < deckSize; i++) {

            GameObject card = Instantiate(cardPrefab, this.transform);
            card.name = i.ToString();
            card.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update() { }
}

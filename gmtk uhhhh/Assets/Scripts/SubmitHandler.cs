using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitHandler : MonoBehaviour
{
    [SerializeField] public Transform sourceHand;
    private HorizontalCardHolder me;

    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<HorizontalCardHolder>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space)) {

            Card[] cards = sourceHand.GetComponentsInChildren<Card>();
            Transform[] cardSlots = GetComponentsInChildren<Transform>();
            uint i = 0;
            foreach(Card card in cards) {

                if(card.selected && i < me.cardsToSpawn) {

                    card.transform.SetParent(cardSlots[i + 1]); // For some reason, the first child is... itself. Skip that shit on foenem
                    card.transform.localPosition = Vector3.zero;

                    i++;
                }

            }

            me.EnslaveChildren();

        }
    }
}

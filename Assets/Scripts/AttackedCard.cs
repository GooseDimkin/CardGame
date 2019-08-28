using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardInfoScr card = eventData.pointerDrag.GetComponent<CardInfoScr>();

        if (card &&
           card.SelfCard.CanAttack &&
           transform.parent == GetComponent<CardMovementScript>().GameManager.EnemyField)
        {
            card.SelfCard.ChangeAttackState(false);

            if (card.IsPlayer)
                card.DeHighlightCard();

            GetComponent<CardMovementScript>().GameManager.CardsFight(card, GetComponent<CardInfoScr>());
        }
    }
}

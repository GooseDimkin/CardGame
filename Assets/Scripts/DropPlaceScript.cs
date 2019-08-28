using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    SELF_HAND,
    SELF_FIELD,
    ENEMY_HAND,
    ENEMY_FIELD
}

public class DropPlaceScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType type;

    public void OnDrop(PointerEventData eventData)
    {
        if (type != FieldType.SELF_FIELD)
            return;

        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card && card.GameManager.PlayerFieldCards.Count < 6 &&
            card.GameManager.IsPlayerTurn)
        {
            card.GameManager.PlayerHandCards.Remove(card.GetComponent<CardInfoScr>());
            card.GameManager.PlayerFieldCards.Add(card.GetComponent<CardInfoScr>());
            card.DefaultParent = transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || type == FieldType.ENEMY_FIELD ||
            type == FieldType.ENEMY_HAND || type == FieldType.SELF_HAND) 
            return;

        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card)
            card.DefaultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card && card.DefaultTempCardParent == transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }
}

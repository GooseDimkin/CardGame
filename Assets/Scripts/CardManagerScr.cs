using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Attack, Defense;
    public bool CanAttack;

    public bool IsAlive
    {
        get
        {
            return Defense > 0;
        }
    }

    public Card(string name, string logoPath, int attack, int defense)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
        CanAttack = false;
    }

    public void ChangeAttackState(bool can)
    {
        CanAttack = can;
    }

    public void GetDamage(int dmg)
    {
        Defense -= dmg;
    }


}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManagerScr : MonoBehaviour
{
    public void Awake()
    {
        CardManager.AllCards.Add(new Card("Алексей тян", "Sprites/Cards/Alexey", 1, 1));
        CardManager.AllCards.Add(new Card("Алексей тян", "Sprites/Cards/Alexey", 1, 1));
        CardManager.AllCards.Add(new Card("Алексей тян", "Sprites/Cards/Alexey", 1, 1));
        CardManager.AllCards.Add(new Card("Алексей тян", "Sprites/Cards/Alexey", 1, 1));
        CardManager.AllCards.Add(new Card("Алексей тян", "Sprites/Cards/Alexey", 1, 1));

        CardManager.AllCards.Add(new Card("Бджилка Селя", "Sprites/Cards/Bee", 1, 3));
        CardManager.AllCards.Add(new Card("Бджилка Селя", "Sprites/Cards/Bee", 1, 3));
        CardManager.AllCards.Add(new Card("Бджилка Селя", "Sprites/Cards/Bee", 1, 3));
        CardManager.AllCards.Add(new Card("Бджилка Селя", "Sprites/Cards/Bee", 1, 3));

        CardManager.AllCards.Add(new Card("Лесик чан", "Sprites/Cards/Kate", 2, 4));
        CardManager.AllCards.Add(new Card("Лесик чан", "Sprites/Cards/Kate", 2, 4));
        CardManager.AllCards.Add(new Card("Лесик чан", "Sprites/Cards/Kate", 2, 4));

        CardManager.AllCards.Add(new Card("Цветная Кисточка", "Sprites/Cards/ColorBrush", 3, 6));
        CardManager.AllCards.Add(new Card("Цветная Кисточка", "Sprites/Cards/ColorBrush", 3, 6));

        CardManager.AllCards.Add(new Card("Грут беларус", "Sprites/Cards/Groot1", 8, 7));

        CardManager.AllCards.Add(new Card("Илья велосипедист", "Sprites/Cards/Ilya", 10, 4));

        CardManager.AllCards.Add(new Card("Братик Холодец", "Sprites/Cards/Kholodets", 9, 1));

        CardManager.AllCards.Add(new Card("Обрыгыш", "Sprites/Cards/Minecraft", 10, 10));
    }
}

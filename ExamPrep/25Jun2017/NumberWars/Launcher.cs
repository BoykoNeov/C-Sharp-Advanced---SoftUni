namespace NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launcher
    {
        public static void Main()
        {
            string[] firstPlayerInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondPlayerInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Queue<Card> firstPlayerCards = new Queue<Card>(ParseCards(firstPlayerInput));
            Queue<Card> secondPlayerCards = new Queue<Card>(ParseCards(secondPlayerInput));

            int roundCounter = 0;
            bool gameOver = false;

            while (roundCounter < 1_000_000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && gameOver == false)
            {
                roundCounter++;
                Card firstPlayerCard = firstPlayerCards.Dequeue();
                Card secondPlayerCard = secondPlayerCards.Dequeue();

                Queue<Card> winningPlayer = null;

                List<Card> cardsOnTheTable = new List<Card>();
                cardsOnTheTable.Add(firstPlayerCard);
                cardsOnTheTable.Add(secondPlayerCard);

                if (firstPlayerCard.Number > secondPlayerCard.Number)
                {
                    winningPlayer = firstPlayerCards;
                }
                else if (firstPlayerCard.Number < secondPlayerCard.Number)
                {
                    winningPlayer = secondPlayerCards;
                }
                else
                {
                    bool weHaveARoundWinner = false;

                    while (weHaveARoundWinner == false)
                    {
                        if (firstPlayerCards.Count < 3 || secondPlayerCards.Count < 3)
                        {
                            weHaveARoundWinner = true;
                            gameOver = true;
                        }
                        else
                        {
                            int firstPlayerSum = 0;
                            int secondPlayerSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                Card firstPlayerCardWarRound = firstPlayerCards.Dequeue();
                                Card secondPlayerCardWarRound = secondPlayerCards.Dequeue();

                                firstPlayerSum += firstPlayerCardWarRound.Letter - 96;
                                secondPlayerSum += secondPlayerCardWarRound.Letter - 96;

                                cardsOnTheTable.Add(firstPlayerCardWarRound);
                                cardsOnTheTable.Add(secondPlayerCardWarRound);
                            }

                            if (firstPlayerSum > secondPlayerSum)
                            {
                                weHaveARoundWinner = true;
                                winningPlayer = firstPlayerCards;
                            }
                            else if (secondPlayerSum > firstPlayerSum)
                            {
                                weHaveARoundWinner = true;
                                winningPlayer = secondPlayerCards;
                            }
                        }
                    }
                }

                if (gameOver)
                {
                    break;
                }

                foreach (Card card in cardsOnTheTable.OrderByDescending(x => x))
                {
                    winningPlayer.Enqueue(card);
                }
            }

            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {roundCounter} turns");
            }
            else if (secondPlayerCards.Count > firstPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins after {roundCounter} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {roundCounter} turns");
            }
        }

        public static IEnumerable<Card> ParseCards (IEnumerable<string> stringCards)
        {
            foreach (string cardString in stringCards)
            {
                List<char> charCard = cardString.ToCharArray().ToList();
                char cardLetter = char.ToLower(charCard[charCard.Count - 1]);
                charCard.RemoveAt(charCard.Count - 1);
                int cardNumber = int.Parse(string.Join("", charCard));

                Card newCard = new Card(cardNumber, cardLetter);
                yield return newCard;
            }
        }
    }

    public class Card : IComparable<Card>
    {
        public Card() { }

        public Card(int number, char letter)
        {
            this.Number = number;
            this.Letter = letter;
        }

        public int Number { get; set; }
        public char Letter { get; set; }

        public int CompareTo(Card other)
        {
            if (this.Number > other.Number)
            {
                return 1;
            }
            else if(this.Number < other.Number)
            {
                return -1;
            }
            else
            {
                if (this.Letter > other.Letter)
                {
                    return 1;
                }
                else if (this.Letter < other.Letter)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
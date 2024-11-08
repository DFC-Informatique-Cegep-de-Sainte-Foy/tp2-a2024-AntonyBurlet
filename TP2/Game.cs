using System;

namespace TP2
{
    public class Game
    {
        #region Constants
        public const int HEART = 0;
        public const int DIAMOND = 1;
        public const int SPADE = 2;
        public const int CLUB = 3;

        public const int ACE = 0;
        public const int TWO = 1;
        public const int THREE = 2;
        public const int FOUR = 3;
        public const int FIVE = 4;
        public const int SIX = 5;
        public const int SEVEN = 6;
        public const int EIGHT = 7;
        public const int NINE = 8;
        public const int TEN = 9;
        public const int JACK = 10;
        public const int QUEEN = 11;
        public const int KING = 12;

        public const int NUM_SUITS = 4;
        public const int NUM_CARDS_PER_SUIT = 13;
        public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
        public const int NUM_CARDS_IN_HAND = 3;

        public const int FACES_SCORE = 10;
        public const int ACES_SCORE = 11;

        public const int MAX_SCORE = 31;
        public const int ALL_SAME_CARDS_VALUE_SCORE = 30;
        public const int ALL_FACES_SCORE = 30;
        public const int ONLY_FACES_SCORE = 28;
        public const int SAME_COLOR_SEQUENCE_SCORE = 28;
        public const int SEQUENCE_SCORE = 26;
        public const int SAME_COLOR_SCORE = 24;
        #endregion

        public static int GetSuitFromCardIndex(int index)
        {           
            return index / NUM_CARDS_PER_SUIT;
        }

        public static int GetValueFromCardIndex(int index)
        {
            return index % NUM_CARDS_PER_SUIT;
        }

        public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            int randomCardIndex;

            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (!selectedCards[i])
                {
                    //Draw une carte
                    do
                    {
                        randomCardIndex = new Random().Next(0, NUM_CARDS);
                    } while (!availableCards[randomCardIndex]);

                    cardValues[i] = randomCardIndex;
                    availableCards[randomCardIndex] = false;
                }
            }

            //On remet les cartes dans le deck fonction ???
            for (int i = 0;i < availableCards.Length;i++)
            {
                if (!availableCards[i])
                {
                    if (!cardValues.Contains(i))
                    {
                        availableCards[i] = true;
                    }
                }
            }
        }
        public static int GetScoreFromCardValue(int cardValue)
        {
            int cardScore;
            cardValue = cardValue % NUM_CARDS_PER_SUIT;

            if (cardValue == ACE)
            {
                cardScore = ACES_SCORE;
            }
            else if (cardValue < JACK)
            {
                cardScore = cardValue + 1;
            }
            else
            {
                cardScore = FACES_SCORE;
            }

            return cardScore;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }

        // A COMPLETER
        // ...
        // Il manque toutes les méthodes pour trouver les différentes combinaisons.
        // Référez-vous aux tests pour les noms de fonctions appropriés.
        // ATTENTION! Suivez bien les noms dans les tests, car je vais utiliser mon propre fichier
        // (qui est exactement comme le vôtre, mais vous ne pourrez pas me faire parvenir un fichier
        // de tests avec vos noms de fonctions).


        public static int GetHighestCardValue(int[] values)
        {
            int highestCardValue = 0;
            int highestCardScore = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if(highestCardScore < GetScoreFromCardValue(values[i])) 
                {
                    highestCardValue = values[i];
                    highestCardScore = GetScoreFromCardValue(values[i]);
                }
            }

            return highestCardValue;
        }

        public static bool HasOnlySameColorCards(int[] suits)
        {

            return false;
        }

        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }


        public static bool HasAllSameCardValues(int[] values)
        {
            throw new NotImplementedException();
        }

        public static bool HasAllFaces(int[] values)
        {
            throw new NotImplementedException();
        }

        public static bool HasOnlyFaces(int[] values)
        {
            throw new NotImplementedException();
        }

        public static bool HasSameColorSequence(int[] values, int[] suits)
        {
            throw new NotImplementedException();
        }

        public static bool HasSequence(int[] values)
        {
            throw new NotImplementedException();
        }

        public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)
        {
            throw new NotImplementedException();
        }
    }
}

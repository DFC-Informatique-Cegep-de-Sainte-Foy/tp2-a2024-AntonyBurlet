using Xunit;
using TP2;
namespace TP2Tests
{
    public class TestsGame
    {
        //PROF : nous testons certaines fonctions avec 5 choix, car il est demandé que vos
         //fonctions soient bonnes en général et non seulement pour le jeu du 31 (lorsque applicable).
        #region GetScoreFromCardValue
        [Fact]
        public void CanGetNormalCardScore()
        {
            const int EXPECTED = 5;
            // Arrange
            // 5
            int cardValue = Game.FIVE;

            // Act
            int score = Game.GetScoreFromCardValue(cardValue);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        [Fact]
        public void CanGetFaceCardScore()
        {
            // Arrange
            // Roi
            int cardValue = Game.KING;

            // Act
            int score = Game.GetScoreFromCardValue(cardValue);

            // Assert
            Assert.Equal(Game.FACES_SCORE, score);
        }

        [Fact]
        public void CanGetAceCardScore()
        {
            // Arrange
            // Roi
            int cardValue = Game.ACE;

            // Act
            int score = Game.GetScoreFromCardValue(cardValue);

            // Assert
            Assert.Equal(Game.ACES_SCORE, score);
        }

        #endregion // GetHighestCardValue

        #region GetHighestCardValue
        [Fact]
        public void CanGetHighestCardValueOnNormalHand()
        {
            // Arrange
            // 3, 7, 6, Reine, 4
            int[] values = { 2, 6, 5, 11, 3 };

            // Act
            int highestCard = Game.GetHighestCardValue(values);

            // Assert
            Assert.Equal(Game.QUEEN, highestCard);
        }
        [Fact]
        public void CanGetHighestCardValueOnConstantHand()
        {
            // Arrange
            // 3, 3, 3, 3, 3
            int[] values = { 2, 2, 2, 2, 2 };

            // Act
            int highestDice = Game.GetHighestCardValue(values);

            // Assert
            Assert.Equal(Game.THREE, highestDice);
        }
        [Fact]
        public void CanGetHighestCardValueWithAceInHand()
        {
            // Arrange
            // 3, Roi, As, 7, 4
            int[] values = { 2, 12, 0, 6, 3 };

            // Act
            int highestDice = Game.GetHighestCardValue(values);

            // Assert
            Assert.Equal(Game.ACE, highestDice);
        }
        #endregion // GetHighestCardValue

        #region HasOnlySameColorCards
        [Fact]
        public void CantFindOnlySameColorIfDifferentColorsPresent()
        {
            // Arrange
            // Coeur, Diamant, Pique, Trèfle, Coeur
            int[] suits = { 0, 1, 2, 3, 0 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.False(onlySameColor);
        }
        [Fact]
        public void CanFindOnlySameColorCardsAllRed()
        {
            // Arrange
            // Coeur, Diamant, Diamant, Coeur, Coeur
            int[] suits = { 0, 1, 1, 0, 0 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.True(onlySameColor);
        }
        [Fact]
        public void CanFindOnlySameColorCardsAllBlack()
        {
            // Arrange
            // Pique, Trèfle, Trèfle, Pique, Pique
            int[] suits = { 2, 3, 3, 2, 2 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.True(onlySameColor);
        }
        [Fact]
        public void CantFindOnlySameColorCardsIfNonExistentColorPresent()
        {
            // Arrange
            // Pique, Trèfle, Pique, ?, Pique
            int[] suits = { 2, 3, 2, 4, 2 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.False(onlySameColor);
        }

        [Fact]
        public void CantFindOnlySameColorCardsIfOnlyNonExistentColorsPresent()
        {
            // Arrange
            // ?, ?, ?, ?, ?
            int[] suits = { 4, 5, 6, 7, 8 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.False(onlySameColor);
        }
        #endregion // HasOnlySameColorCards

        #region HasAllSameCardValues
        [Fact]
        public void CantFindAllSameCardValuesIfNotPresent()
        {
            // Arrange
            // As, 8, Valet, 10, Roi
            int[] values = { 0, 7, 10, 9, 12 };

            // Act
            bool hasAllSameCardValues = Game.HasAllSameCardValues(values);

            // Assert
            Assert.False(hasAllSameCardValues);
        }
        [Fact]
        public void CantFindAllSameCardValuesIfMajorityOfCardsHaveSameValue()
        {
            // Arrange
            // 4, 4, 4, 5, 5
            int[] values = { 3, 3, 3, 4, 4 };

            // Act
            bool hasAllSameCardValues = Game.HasAllSameCardValues(values);

            // Assert
            Assert.False(hasAllSameCardValues);
        }
        [Fact]
        public void CanFindAllSameCardValuesIfPresent()
        {
            // Arrange
            // 10, 10, 10, 10, 10
            int[] values = { 9, 9, 9, 9, 9 };

            // Act
            bool hasAllSameCardValues = Game.HasAllSameCardValues(values);

            // Assert
            Assert.True(hasAllSameCardValues);
        }
        #endregion // HasAllSameCardValues

        #region HasAllFaces
        [Fact]
        public void CantFindAllFacesIfNonePresent()
        {
            // Arrange
            // 6, 10, As
            int[] values = { 5, 9, 0 };

            // Act
            bool hasAllFaces = Game.HasAllFaces(values);

            // Assert
            Assert.False(hasAllFaces);
        }
        [Fact]
        public void CantFindAllFacesIfNotOnlyFacesPresent()
        {
            // Arrange
            // Valet, Reine, As
            int[] values = { 10, 11, 0 };

            // Act
            bool hasAllFaces = Game.HasAllFaces(values);

            // Assert
            Assert.False(hasAllFaces);
        }
        [Fact]
        public void CantFindAllFacesIfMultipleSameFacesPresent()
        {
            // Arrange
            // Valet, Roi, Roi
            int[] values = { 10, 12, 12 };

            // Act
            bool hasAllFaces = Game.HasAllFaces(values);

            // Assert
            Assert.False(hasAllFaces);
        }
        [Fact]
        public void CanFindAllFacesIfPresent()
        {
            // Arrange
            // Valet, Reine, As
            int[] values = { 10, 11, 12 };

            // Act
            bool hasAllFaces = Game.HasAllFaces(values);

            // Assert
            Assert.True(hasAllFaces);
        }
        [Fact]
        public void CanFindAllFacesIfPresentNotInOrder()
        {
            // Arrange
            // Valet, Reine, As
            int[] values = { 12, 10, 11 };

            // Act
            bool hasAllFaces = Game.HasAllFaces(values);

            // Assert
            Assert.True(hasAllFaces);
        }


        #endregion // HasAllFaces

        #region HasOnlyFaces
        [Fact]
        public void CantFindOnlyFacesIfNonePresent()
        {
            // Arrange
            // 4, 5, 6, 7, 8
            int[] values = { 3, 4, 5, 6, 7 };

            // Act
            bool hasOnlyFaces = Game.HasOnlyFaces(values);

            // Assert
            Assert.False(hasOnlyFaces);
        }

        [Fact]
        public void CantFindOnlyFacesIfNotOnlyFacesPresent()
        {
            // Arrange
            // 4, 5, 6, Valet, Roi
            int[] values = { 3, 4, 5, 10, 12 };

            // Act
            bool hasOnlyFaces = Game.HasOnlyFaces(values);

            // Assert
            Assert.False(hasOnlyFaces);
        }

        [Fact]
        public void CanFindOnlyFacesIfPresent()
        {
            // Arrange
            // Reine, Valet, Roi, Valet, Roi
            int[] values = { 11, 10, 11, 10, 12 };

            // Act
            bool hasOnlyFaces = Game.HasOnlyFaces(values);

            // Assert
            Assert.True(hasOnlyFaces);
        }

        [Fact]
        public void CanFindOnlyFacesIfAllSameFace()
        {
            // Arrange
            // Valet, Valet, Valet, Valet, Valet
            int[] values = { 10, 10, 10, 10, 10 };

            // Act
            bool hasOnlyFaces = Game.HasOnlyFaces(values);

            // Assert
            Assert.True(hasOnlyFaces);
        }

        [Fact]
        public void CanFindOnlyFacesIfAllFacesPresent()
        {
            // Arrange
            // Reine, Valet, Roi
            int[] values = { 12, 10, 11, };

            // Act
            bool hasOnlyFaces = Game.HasOnlyFaces(values);

            // Assert
            Assert.True(hasOnlyFaces);
        }
        #endregion // HasOnlyFaces

        #region HasSameColorSequence
        [Fact]
        public void CantFindSameColorSequenceIfNonePresent()
        {
            // Arrange
            // 4, 7, 2, Valet, Roi
            int[] values = { 3, 6, 1, 10, 12 };
            // Coeur, Diamant, Pique, Trèfle, Coeur
            int[] suits = { 0, 1, 2, 3, 0 };

            // Act
            bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

            // Assert
            Assert.False(hasSameColorSequence);
        }

        [Fact]
        public void CantFindSameColorSequenceIfOnlySequencePresent()
        {
            // Arrange
            // 4, 7, 5, 6, 8 (4, 5, 6, 7, 8)
            int[] values = { 3, 6, 4, 5, 7 };
            // Coeur, Diamant, Pique, Trèfle, Coeur
            int[] suits = { 0, 1, 2, 3, 0 };

            // Act
            bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

            // Assert
            Assert.False(hasSameColorSequence);
        }

        [Fact]
        public void CantFindSameColorSequenceIfOnlySameColorPresent()
        {
            // Arrange
            // 4, 7, 2, Valet, Roi
            int[] values = { 3, 6, 1, 10, 12 };
            // Coeur, Diamant, Diamant, Diamant, Coeur
            int[] suits = { 0, 1, 1, 1, 0 };

            // Act
            bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

            // Assert
            Assert.False(hasSameColorSequence);
        }
        [Fact]
        public void CanFindSameColorSequenceIfPresent()
        {
            // Arrange
            // 4, As, 5, 3, 2 (As, 2, 3, 4, 5)
            int[] values = { 3, 0, 4, 2, 1 };
            // Coeur, Diamant, Diamant, Diamant, Coeur
            int[] suits = { 0, 1, 1, 1, 0 };

            // Act
            bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

            // Assert
            Assert.True(hasSameColorSequence);
        }
        #endregion // HasSameColorSequence

        #region HasSequence
        [Fact]
        public void CantFindSequenceIfNonePresent()
        {
            // Arrange
            // 4, Valet, 2, 5, 8
            int[] values = { 3, 10, 1, 4, 7 };

            // Act
            bool hasSequence = Game.HasSequence(values);

            // Assert
            Assert.False(hasSequence);
        }
        [Fact]
        public void CanFindSequenceIfPresent()
        {
            // Arrange
            // 4, 5, 6, 7, 8
            int[] values = { 3, 4, 5, 6, 7 };

            // Act
            bool hasSequence = Game.HasSequence(values);

            // Assert
            Assert.True(hasSequence);
        }
        [Fact]
        public void CanFindSequenceWithAce()
        {
            // Arrange
            // As, 2, 3, 4, 5
            int[] values = { 0, 1, 2, 3, 4 };

            // Act
            bool hasSequence = Game.HasSequence(values);

            // Assert
            Assert.True(hasSequence);
        }
        [Fact]
        public void CanFindSequenceWithFaces()
        {
            // Arrange
            // 9, 10, Valet, Reine, Roi
            int[] values = { 8, 9, 10, 11, 12 };

            // Act
            bool hasSequence = Game.HasSequence(values);

            // Assert
            Assert.True(hasSequence);
        }
        [Fact]
        public void CantFindSequenceWithAceAndFaces()
        {
            // Arrange
            // 10, Valet, Reine, Roi, As
            int[] values = { 9, 10, 11, 12, 0 };

            // Act
            bool hasSequence = Game.HasSequence(values);

            // Assert
            Assert.False(hasSequence);
        }
        [Fact]
        public void CanFindSequenceNotInOrder()
        {
            // Arrange
            // 5, 8, 7, 6, 4 (4, 5, 6, 7, 8)
            int[] values = { 4, 7, 6, 5, 3 };

            // Act
            bool hasSequence = Game.HasSequence(values);

            // Assert
            Assert.True(hasSequence);
        }
        #endregion // HasSequence

        #region GetScoreFromMultipleCardsOfASuit
        [Fact]
        public void ShouldGet0WhenTargetSuitNotInSuits()
        {
            // Arrange
            const int EXPECTED = 0;
            // Coeur
            int suit = 0;
            // 4, Valet, As
            int[] values = { 3, 10, 0 };
            // Diamant, Diamant, Diamant
            int[] suits = { 1, 1, 1 };

            // Act
            int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        [Fact]
        public void ShouldGetRightScoreWithOneCardFromTargetSuit()
        {
            // Arrange
            const int EXPECTED = 4;
            // Coeur
            int suit = 0;
            // 4, Valet, As
            int[] values = { 3, 10, 0 };
            // Coeur, Diamant, Diamant
            int[] suits = { 0, 1, 1 };

            // Act
            int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        [Fact]
        public void ShouldGetRightScoreWithMultipleCardsFromTargetSuit()
        {
            // Arrange
            const int EXPECTED = 14;
            // Coeur
            int suit = 0;
            // 4, Valet, As, Reine, 6
            int[] values = { 3, 10, 0, 11, 5 };
            // Coeur, Diamant, Diamant, Coeur, Pique
            int[] suits = { 0, 1, 1, 0, 2 };

            // Act
            int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        [Fact]
        public void ShouldGetMaxScoreWithRightCombinationFromTargetSuit()
        {
            // Arrange
            // Trèfle
            int suit = 3;
            // Roi, Valet, As
            int[] values = { 12, 10, 0, };
            // Trèfle, Trèfle, Trèfle
            int[] suits = { 3, 3, 3 };

            // Act
            int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

            // Assert
            Assert.Equal(Game.MAX_SCORE, score);
        }
        #endregion // GetScoreFromMultipleCardsOfASuit

        #region GetHandScore
        [Fact]
        public void CanGetBestScoreFromCombinationScoreIfBetterThenAdditionScore()
        {
            // Arrange
            // 2, 6, 9 de Coeur (Même couleur = 24, Addition = 17)
            int[] indexes = { 1, 5, 8 };

            // Act
            int score = Game.GetHandScore(indexes);

            // Assert
            Assert.Equal(Game.SAME_COLOR_SCORE, score);
        }
        [Fact]
        public void CanGetBestScoreFromAdditionScoreIfBetterThenCombinationScore()
        {
            const int EXPECTED = 30;
            // Arrange
            // 10, Valet, Reine de Pique (Suite de même couleur = 28, Addition = 30)
            int[] indexes = { 35, 36, 37 };

            // Act
            int score = Game.GetHandScore(indexes);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        [Fact]
        public void CanGetBestScoreFromSingleCardIfNoCombinationAndNoCardsFromSameSuit()
        {
            const int EXPECTED = 11;
            // Arrange
            // As de Coeur, Valet de Pique, 6 de Diamant (Aucune combinaison spéciale, Carte la plus forte = 11)
            int[] indexes = { 0, 36, 18 };

            // Act
            int score = Game.GetHandScore(indexes);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        [Fact]
        public void CanGetBestScoreFromSingleCardIfNoCombinationAndAdditionOfCardsFromSameSuitIsLower()
        {
            const int EXPECTED = 11;
            // Arrange
            // As de Coeur, 4 de Pique, 6 de Pique (Aucune combinaison spéciale, Carte la plus forte = 11, Addition = 10)
            int[] indexes = { 0, 29, 31 };

            // Act
            int score = Game.GetHandScore(indexes);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
        #endregion // GetHandScore

    }
}
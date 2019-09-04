namespace Casino

    module Domain =

        type Value =
           | Two = 2
           | Three = 3
           | Four = 4
           | Five = 5
           | Six = 6
           | Seven = 7
           | Eight = 8
           | Nine = 9
           | Ten = 10
           | Jack = 11
           | Queen = 12
           | King = 13
           | Ace = 14
           | Joker = 15

        type Color =
            | Red
            | Black

        type Suit =
           | Colver
           | Diamonds
           | Hearts of Color
           
        type Card = Value * Suit
        
        type Hand = Card * Card * Card * Card * Card

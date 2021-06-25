using System;
using System.Threading;
using System.Collections.Generic;

namespace ProjectHigherLower
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Greeting the player
            Program.WriteLineSlow("Welcome to Hi/Lo");
            Console.Write("Can I get your name, player? ");
            string playerOne = Console.ReadLine();
            //To check if the player entered a correct answer
            bool rulesAnswerCorrect = false;
            while (rulesAnswerCorrect == false)
            {

                Program.WriteLineSlow("Welcome " + playerOne + "! Do you want to know the rules? y/n");
                string rulesAnswer = Console.ReadLine();
                //Explaining the rules if the player chose yes
                if (rulesAnswer == "y")
                {
                    rulesAnswerCorrect = true;
                    Program.WriteLineSlow("Here are the rules!");
                    Program.WriteLineSlow("The game is played with a deck of 52 cards.");
                    Program.WriteLineSlow("The goal of the game is to win as many rounds as possible.");
                    Program.WriteLineSlow("The Ace is the lowest card, and the King is the highest.");
                    Program.WriteLineSlow("Every round the computer will show you a card.");
                    Program.WriteLineSlow("And you have to guess whether the next card will be higher or lower.");
                    Program.WriteLineSlow("If you get it right, you get a point.");
                    Program.WriteLineSlow("Otherwise the computer will get a point.");
                    Program.WriteLineSlow("If the card picked is an Ace or a King, the next card will be picked.");
                    Program.WriteLineSlow("However, if the two picked cards have the same value, the one with the highest suit will win");

                }
                else if (rulesAnswer == "n")
                {
                    //If the player chose no, not showing the rules and letting the player out of the loop
                    rulesAnswerCorrect = true;
                }
                else
                {
                    //Telling the player their input is wrong
                    Console.WriteLine("Please enter a valid response, y for yes and n for no.");
                    rulesAnswerCorrect = false;
                }
            }
                //Asking how many rounds the player wants to play
                Console.Write("How many rounds do you want to play, " + playerOne + "? ");
                int totalRounds = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The computer is generating a deck of cards...");
                               List<Card> deck = new List<Card>();
                //Getting the deck ready for use
                string[] cardValue = Card.GetAllowedCardValues();
                for (int i = 0; i < cardValue.Length; i++)
                {
                    string deckValue = cardValue[i];
                    string deckSuit = "s";
                    
                    for (int j = 1; j <= 4; j++)
                    {
                       
                        if (j == 1)
                        {
                            deckSuit = "r";
                        }
                        else if (j == 2)
                        {
                            deckSuit = "h";
                        }
                        else if (j == 3)
                        {
                            deckSuit = "k";
                        }
                        deck.Add(new Card(deckValue, deckSuit));

                    }
                }
                int guessedCorrectly = 0;
                int guessedIncorrectly = 0;
                //Randomizing and guessing cards
                for (int y = 0; y < totalRounds; y++)
                {
                    Random rnd = new Random();
                    int indexOne = rnd.Next(deck.Count);
                    if (indexOne >= 47)
                    {
                        indexOne = rnd.Next(46);
                    } else if (indexOne < 4)
                    {
                        indexOne = rnd.Next(4, deck.Count);
                    }
                   
                    Card computersCard = deck[indexOne];
                    Console.WriteLine(" ");
                    Program.WriteLineSlow("The next card is...");
                    Console.WriteLine(" ");
                    computersCard.PrintCard();
                    int indexTwo = rnd.Next(deck.Count);
                    if (indexOne == indexTwo)
                    {
                        indexTwo = rnd.Next(deck.Count);
                    }
                    bool correctImput = false;
                    while (correctImput == false)
                    {
                        Console.WriteLine(" ");
                        Console.Write("Will the next card be Higher (h) or Lower (l)? ");
                        computersCard = deck[indexTwo];
                        string answer = Console.ReadLine();
                        if (answer == "h")
                        {
                            if (indexOne < indexTwo)
                            {
                                guessedCorrectly++;
                                Console.Write("Congrats! You got it right! The card was ");
                                Console.WriteLine(" ");
                                computersCard.PrintCard();
                                correctImput = true;
                            }
                            else if (indexOne > indexTwo)
                            {
                                guessedIncorrectly++;
                                Console.Write("I'm sorry, unfortunately the card was ");
                                Console.WriteLine(" ");
                                computersCard.PrintCard();
                                correctImput = true;
                            }
                            
                        }
                        else if (answer == "l")
                        {
                            if (indexOne > indexTwo)
                            {
                            guessedCorrectly++;
                            Console.Write("Congrats! You got it right! The card was ");
                            Console.WriteLine(" ");
                            computersCard.PrintCard();
                            correctImput = true;
                        }
                            else if (indexOne < indexTwo)
                            {
                            guessedIncorrectly++;
                            Console.Write("I'm sorry, unfortunately the card was ");
                            Console.WriteLine(" ");
                            computersCard.PrintCard();
                            correctImput = true;
                        }
                            
                        }

                        else 
                        {
                        Console.WriteLine("Please enter a valid letter, h for Higher, l for Lower");

                        }
                    }

                    
                }
                Console.WriteLine(" ");
                Program.WriteLineSlow("Wow! What was that an interesting game!");
                Program.WriteLineSlow("Let's take a look at the score!");
                Program.WriteLineSlow(playerOne + " had " + guessedCorrectly + " points!");
                Program.WriteLineSlow("Meaning the computer got " + guessedIncorrectly + " points.");
                Program.WriteLineSlow("That means, the winner of this game of Hi/Lo is...");
                if (guessedCorrectly < guessedIncorrectly)
                {
                    Program.WriteLineSlow("The computer!");
                }else if (guessedCorrectly > guessedIncorrectly)
                {
                    Program.WriteLineSlow(playerOne);
                }
                else
                {
                    Program.WriteLineSlow("It's a tie!");
                }
                Program.WriteLineSlow("Well, that surely was a surprise, wasn't it?");
                Program.WriteLineSlow("I hope you had a fun time!");
                Credits();
            

        }
        public static void WriteLineSlow(string message)
        {
            //To slowly show the messages wanted
            Console.WriteLine(message);
            Thread.Sleep(2000);
        }
        public static void Credits()
        {
            Console.WriteLine("\n\n\n\n");
            Program.WriteLineSlow("Credits");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Creative Director - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Art Director - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Game Analist - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Game Director - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Game Design - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Game Developer - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Lead Developer - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Senior Developer - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Junior Developer - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Developer - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Catering staff - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Copywritings - Jamie De Mooij");
            Console.WriteLine("\n");
            Program.WriteLineSlow("Writer - Jamie De Mooij");
            Console.WriteLine("\n");
        }
    }
}

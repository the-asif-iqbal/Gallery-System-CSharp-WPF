using System;
using CGSLibrary;

namespace CGSConsole
{
    class ArtGallery
    {
        static Gallery gal = new Gallery();
        static void Main(string[] args)
        {
            string fname;
            string lname;
            string artistID;
            string curatorID;
            string artPieceID;
            string pieceTitle;
            string pieceYear;
            double pieceValue;
            double piecePrice;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Computerised Gallery System - Prototype 1.0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("**Created by Asif Iqbal & Harpreet Kaur**\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------------------------Main Menu-------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool menuLoop = true;
            while (menuLoop)
            {
                try
                {
                    DisplayMenu();
                    Console.Write("\nEnter menu option:");
                    int menuCase = int.Parse(Console.ReadLine());
                    switch (menuCase)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------Add New Artist-----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("First Name: ");
                            fname = Console.ReadLine();
                            Console.Write("Last Name: ");
                            lname = Console.ReadLine();
                            Console.Write("Artist ID: ");
                            artistID = Console.ReadLine();
                            gal.AddArtist(fname, lname, artistID);
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------List of Artists----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            gal.ListArtists();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------Find Artist----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Artist ID: ");
                            artistID = Console.ReadLine();
                            gal.FindArtist(artistID);
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("----------------------------------------------------Add New Curator----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("First Name: ");
                            fname = Console.ReadLine();
                            Console.Write("Last Name: ");
                            lname = Console.ReadLine();
                            Console.Write("Curator ID: ");
                            curatorID = Console.ReadLine();
                            gal.AddCurator(fname, lname, curatorID);
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("----------------------------------------------------List of Curators----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            gal.ListCurators();
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------Find Curator----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Curator ID: ");
                            curatorID = Console.ReadLine();
                            gal.FindCurator(curatorID);
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("---------------------------------------------------Add New Art Piece----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Piece ID: ");
                            artPieceID = Console.ReadLine();
                            Console.Write("Title: ");
                            pieceTitle = Console.ReadLine();
                            Console.Write("Year of Aquisition: ");
                            pieceYear = Console.ReadLine();
                            Console.Write("Piece Value: ");
                            pieceValue = double.Parse(Console.ReadLine());
                            Console.Write("Artist ID: ");
                            artistID = Console.ReadLine();
                            Console.Write("Curator ID: ");
                            curatorID = Console.ReadLine();
                            gal.AddArtPiece(artPieceID, pieceTitle, pieceYear, pieceValue, artistID, curatorID);
                            break;
                        case 8:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("---------------------------------------------------List of Art Pieces---------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            gal.ListArtPieces();
                            break;
                        case 9:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------Sell Art Piece-----------------------------------------------------\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Enter Piece ID: ");
                            artPieceID = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            piecePrice = double.Parse(Console.ReadLine());
                            gal.SellPiece(artPieceID, piecePrice);
                            break;
                        case 10:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Thank you for using Computerised Gallery System. Hope you have wonderful day ahead");
                            Console.ForegroundColor = ConsoleColor.White;
                            menuLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("**ERROR - Enter Valid Menu Option**");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    menuLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (CGSException)
                {
                    throw new CGSException("**Some unknown exception is occured**");
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1: New Artist" +
                "\n2: List Artist" +
                "\n3: Find Artist" +
                "\n4: New Curator" +
                "\n5: List Curator" +
                "\n6: Find Curator" +
               "\n7: New ArtPiece" +
               "\n8: List ArtPiece" +
               "\n9: Sell Art Piece" +
               "\n10: Exit");
        }
    }
 }


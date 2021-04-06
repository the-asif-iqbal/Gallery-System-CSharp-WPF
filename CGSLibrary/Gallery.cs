using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGSLibrary
{
    public class Gallery
    {
        Validation val = new Validation();
        //LIST TO STORE ARTIST
        public static List<Artist> artists = new List<Artist>();
        private Artist artist = new Artist();
        //METHOD TO ADD NEW ARTIST
        public void AddArtist(string fname, string lname, string artistID)
        {
            try
            {
                bool isValidated = val.ArtistVal(fname, lname, artistID);
                if (isValidated)
                {
                    bool isDone = val.AddArtistVal(fname, lname, artistID);
                    if (isDone)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("**Artist Added Successfully**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**Please try again**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Please Enter Valid Input**\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(CGSException)
            {
                throw new CGSException("**Some unknown exception is occured**");
            }
        }
        //METHOD TO FIND ARTIST
        public void FindArtist(string artistID)
        {
            bool isFound = artists.Exists(a => a.ArtistID == artistID);
            if (isFound == true)
            {
                artist = artists.Find(a => a.ArtistID == artistID);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Name" + "\t\tArtist ID");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(artist.ToString());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Artist does not exist**\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //METHOD TO DISPLAY ALL ARTISTS
        public void ListArtists()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name" + "\t\tArtist ID");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Artist artist in artists)
            {
                Console.Write(artist.ToString());
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //LIST TO STORE CURATOR
        public static List<Curator> curators = new List<Curator>();
        private Curator curator = new Curator();
        //METHOD TO ADD NEW CURATOR
        public void AddCurator(string fname, string lname, string curatorID)
        {
            try
            {
                bool isValidated = val.CuratorVal(fname, lname, curatorID);
                if (isValidated)
                {
                    bool isDone = val.AddCuratorVal(fname, lname, curatorID);
                    if (isDone)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("**Curator Added Successfully**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**Please try again**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Please Enter Valid Input**\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (CGSException)
            {
                throw new CGSException("**Some unknown exception is occured**");
            }
        }
        //METHOD TO FIND CURATOR
        public void FindCurator(string curatorID)
        {
            bool isFound = curators.Exists(c => c.CuratorID == curatorID);
            if (isFound == true)
            {
                curator = curators.Find(c => c.CuratorID == curatorID);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Name" + "\t\tCurator ID" + "\tCommission Earned");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(curator.ToString());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Curator does not exist**\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //METHOD TO DISPLAY ALL CURATORS
        public void ListCurators()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name" + "\t\tCurator ID" + "\tCommission Earned");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Curator curator in curators)
            {
                Console.WriteLine(curator.ToString());
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        ArtPiece pieces = new ArtPiece();
        //LIST TO STORE ARTPIECE
        public static List<ArtPiece> artPieces = new List<ArtPiece>();
        //METHOD TO ADD NEW ARTPIECE
        public void AddArtPiece(string artpieceID, string pieceTitle, string pieceYear, double pieceValue, string artistID, string curatorID)
        {
            try
            {
                bool isValidated = val.ArtPieceVal(artpieceID, pieceTitle, pieceYear, pieceValue, artistID, curatorID);
                if (isValidated)
                {
                    bool isDone = val.AddPieceVal(artpieceID, pieceTitle, pieceYear, pieceValue, artistID, curatorID);
                    if (isDone)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("**Piece Added Successfully**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**Please try again**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Please Enter Valid Input**\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (CGSException)
            {
                throw new CGSException("**Some unknown exception is occured**");
            }
        }
        //METHOD TO DISPLAY ALL ARTPIECES
        public void ListArtPieces()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Piece ID" + "  Title" + "\t\t\tAcquired Year" + "\tPrice Paid" + "\tPrice Value" + "\tArtist ID" + "\tCurator ID" + "\tStatus");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (ArtPiece artPiece in artPieces)
            {
                Console.WriteLine(artPiece.ToString());
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n**Status**" + "\nD = On Display" + "\nS = Sold");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //METHOD TO SELL ARTPIECE
        public bool SellPiece(string artPieceID, double pricePaid)
        {
            bool isSold = false;
            try
            {
                bool ID = artPieces.Exists(i => i.PieceID == artPieceID);
                if (ID == true)
                {
                    bool isStatus = artPieces.Exists(s => s.Status == 'D');
                    if (isStatus)
                    {

                        pieces.ChangeStatus('S', artPieceID);
                        pieces.PricePaid(pricePaid, artPieceID);
                        curator.GetID(artPieceID);
                        curator.SetComm(pricePaid, artPieceID);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("**Piece Sold Successfully**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        return isSold = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**Piece Already Sold**\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        return isSold = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Piece do not exists**\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return isSold = false;
                }
            }
            catch (CGSException)
            {
                
            }
            return isSold;
        }
    }
}

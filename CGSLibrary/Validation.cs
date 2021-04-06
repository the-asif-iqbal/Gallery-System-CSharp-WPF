using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CGSLibrary
{
    public class Validation
    {
        //ARTIST VALIDATION
        public bool ArtistVal (string fname, string lname, string artistID)
        {
            string name = fname + " " + lname;
            bool artistValid;
            if (name.Length < 3 || name.Length > 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Artist Name - should be between 3-40 characters**");
                Console.ForegroundColor = ConsoleColor.White;
                artistValid = false;
            }
            else if (!(new Regex(@"^([A]{1}\d{4})?$").IsMatch(artistID)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid ArtistID - should follow format - A####**");
                Console.ForegroundColor = ConsoleColor.White;
                artistValid = false;
            }
            else if (fname.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid First Name - should not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;
                artistValid = false;
            }
            else if (lname.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Last Name - should not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;
                artistValid = false;
            }
            else
            {
                artistValid = true;
            }
            return artistValid;
        }
        //ADDING ARTIST TO LIST VALIDATION
        public bool AddArtistVal(string fname, string lname, string artistID)
        {
            bool isDone = false;
            try
            {
                Artist addArtist = new Artist()
                {
                    FirstName = fname,
                    LastName = lname,
                    ArtistID = artistID
                };
                Gallery.artists.Add(addArtist);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new CGSException(e.Message);
            }
            return isDone;
         }
        //CURATOR VALIDATION
        public bool CuratorVal(string fname, string lname, string curatorID)
        {
            string name = fname + " " + lname;
            bool curatorValid;
            if (name.Length < 3 || name.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Artist Name - shold be between 3-40 characters**");
                Console.ForegroundColor = ConsoleColor.White;
                curatorValid = false;
            }
            else if (!(new Regex(@"^([C]{1}\d{4})?$").IsMatch(curatorID)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Curator ID - should follow format - C####**");
                Console.ForegroundColor = ConsoleColor.White;
                curatorValid = false;
            }
            else if (fname.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid First Name - shold not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;
                curatorValid = false;
            }
            else if (lname.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Last Name - shold not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;
                curatorValid = false;
            }
            else
            {
                curatorValid = true;
            }
            return curatorValid;
        }
        //ADDING CURATOR TO LIST VALIDATION
        public bool AddCuratorVal(string fname, string lname, string curatorID)
        {
            bool isDone = false;
            try
            {
                Curator addCurator = new Curator()
                {
                    FirstName = fname,
                    LastName = lname,
                    CuratorID = curatorID
                };
                Gallery.curators.Add(addCurator);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new CGSException(e.Message);
            }
            return isDone;
        }
        //ARTPIECE VALIDATION
        public bool ArtPieceVal(string artpieceID, string pieceTitle, string pieceYear, double pieceValue, string artistID, string curatorID)
        {
            bool pieceValid;
            if (!(new Regex(@"^([P]{1}\d{4})?$").IsMatch(artpieceID)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid ArtPiece ID - should follow format - P####**");
                Console.ForegroundColor = ConsoleColor.White;
                pieceValid = false;
            }
            else if (pieceTitle.Length < 9 || pieceTitle.Length > 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid ArtPiece Title - should be between 9-40 characters**");
                Console.ForegroundColor = ConsoleColor.White;
                pieceValid = false;
            }
            else if (!(new Regex(@"^(\d{4})?$").IsMatch(pieceYear)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Year - should follow format - ####**");
                Console.ForegroundColor = ConsoleColor.White;
                pieceValid = false;
            }
            else if (!(Gallery.artists.Exists(a => a.ArtistID == artistID)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Given Artist does not exist. Please add Artist first.**");
                Console.ForegroundColor = ConsoleColor.White;
                pieceValid = false;
            }
            else if (!(Gallery.curators.Exists(c => c.CuratorID == curatorID)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Given Curator does not exist. Please add Curator first.**");
                Console.ForegroundColor = ConsoleColor.White;
                pieceValid = false;
            }
            else
            {
                pieceValid = true;
            }
            return pieceValid;
        }
        //ADDING ARTPIECE TO LIST VALIDATION
        public bool AddPieceVal(string artpieceID, string pieceTitle, string pieceYear, double pieceValue, string artistID, string curatorID)
        {
            bool isDone = false;
            try
            {
                ArtPiece addPiece = new ArtPiece()
                {
                    PieceID = artpieceID,
                    Title = pieceTitle,
                    Year = pieceYear,
                    Estimate = pieceValue,
                    ArtistID = artistID,
                    CuratorID = curatorID,
                };
                Gallery.artPieces.Add(addPiece);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new CGSException(e.Message);
            }
            return isDone;
        }
    }
}

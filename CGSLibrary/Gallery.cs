using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CGSLibrary
{
    public class Gallery
    {
        //LIST TO STORE ARTIST
        public static List<Artist> artists = new List<Artist>();
        private Artist artist = new Artist();
        //METHOD TO ADD ARTIST
        public void AddArtist(string fname, string lname, string artistID)
        {
            Artist addArtist = new Artist()
            {
                FirstName = fname,
                LastName = lname,
                ArtistID = artistID
            };
            artists.Add(addArtist);
        }
        //LIST TO STORE CURATOR
        public static List<Curator> curators = new List<Curator>();
        private Curator curator = new Curator();
        //METHOD TO ADD CURATOR
        public void AddCurator(string fname, string lname, string curatorID)
        {
            Curator addCurator = new Curator()
            {
                FirstName = fname,
                LastName = lname,
                CuratorID = curatorID
            };
            curators.Add(addCurator);
        }
        //LIST TO STORE ARTPIECE
        public static List<ArtPiece> artPieces = new List<ArtPiece>();
        ArtPiece pieces = new ArtPiece();
        //METHOD TO ADD ARTPIECE
        public void AddArtPiece(string artpieceID, string pieceTitle, string pieceYear, double pieceValue, string artistID, string curatorID)
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
            artPieces.Add(addPiece);
            SetStatus();
        }
        public bool SetStatus()
        {
            bool isSet = true;
            return isSet;
        }
        //METHOD TO SELL PIECE
        public bool SellPiece(string artPieceID, double pricePaid)
        {
            bool isSold = true;
            bool ID = artPieces.Exists(i => i.PieceID == artPieceID);
            if (ID == true)
            {
                bool isOnDisplay = artPieces.Where(w => w.PieceID == artPieceID).ToList().Exists(d => d.Status == 'D');
                bool isInStorage = artPieces.Where(w => w.PieceID == artPieceID).ToList().Exists(o => o.Status == 'O');
                if (isOnDisplay)
                {
                    pieces.ChangeStatus('S', artPieceID);
                    pieces.PricePaid(pricePaid, artPieceID);
                    curator.GetID(artPieceID);
                    curator.SetComm(pricePaid, artPieceID);
                    MessageBox.Show("Piece Sold Successfully", "Success");
                    isSold = true;
                }
                else if (isInStorage)
                {
                    MessageBox.Show("Piece in storage cannot be sold", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSold = false;
                }
                else
                {
                    MessageBox.Show("Piece Already Sold", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSold = false;
                }
            }
            else
            {
                MessageBox.Show("Piece does not exits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isSold = false;
            }
            return isSold;
        }
        //METHOD TO WRITE TO FILE
        public void WriteCurators(string curatorID, string fname, string lname, string filePath)
        {
            Curator addCurator = new Curator()
            {
                CuratorID = curatorID,
                FirstName = fname,
                LastName = lname
            };
            curators.Add(addCurator);
            List<string> output = new List<string>();
            foreach (var curator in curators)
            {
                output.Add($"{curator.CuratorID},{curator.FirstName},{curator.LastName},{curator.Commission}");
            }
            File.AppendAllLines(filePath, output);
            MessageBox.Show("Curator Written Successfully", "Success");
        }
        //METHOD TO READ FROM FILE
        public void ReadCurators(string filePath)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Curator newCurator = new Curator() { CuratorID = entries[0], FirstName = entries[1], LastName = entries[2], Commission = double.Parse(entries[3]) };
                curators.Add(newCurator);
            }
            MessageBox.Show("Curator Read Successfully", "Success");
        }
    }
}
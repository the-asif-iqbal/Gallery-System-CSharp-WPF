using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGSLibrary
{
    public class ArtPiece
    {
        public string PieceID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public double Estimate { get; set; }
        public string ArtistID { get; set; }
        public string CuratorID { get; set; }
        public char Status { get; set; }
        public ArtPiece()
        {
            PieceID = string.Empty;
            Title = string.Empty;
            Year = string.Empty;
            Price = 0;
            Estimate = 0;
            ArtistID = string.Empty;
            CuratorID = string.Empty;
            Status = 'D';
        }
        //ToString METHOD FOR ARTPIECE
        public override string ToString()
        {
            return $"Piece ID: {this.PieceID}\t Title: {this.Title}\t Year of Acquisition: {this.Year}\t Price Paid: {this.Price}\t Estimate: {this.Estimate}\t Artist ID: {this.ArtistID}\t Curator ID: {this.CuratorID}\t Status: {this.Status}\n";
        }
        //CHANGE STATUS OF ARTPIECE
        public void ChangeStatus(char S, string pieceID)
        {
            Gallery.artPieces.Where(w => w.PieceID == pieceID).ToList().ForEach(d => d.Status = S);
        }
        //ASSIGN PRICE TO ARTPIECE
        public void PricePaid(double p, string pieceID)
        {
            Gallery.artPieces.Where(w => w.PieceID == pieceID).ToList().ForEach(d => d.Price = p);
        }
        //CALCULATE COMMISSION
        public double CalculateComm(double c, string pieceID)
        {
            double per = 0.25;
            ArtPiece art = Gallery.artPieces.Find(i => i.PieceID == pieceID);
            var e = art.Estimate;
            double value = c - e;
            return per * value;
        }
    }
}

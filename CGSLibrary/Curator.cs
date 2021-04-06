﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGSLibrary
{
    public class Curator : Person
    {
        public string CuratorID { get; set; }
        public double Commission { get; set; }
        public const double CommRate = 0.1;
        public Curator()
        {
            Commission = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            CuratorID = string.Empty;
        }
        //OVERRIDE ToString() METHOD FOR CURATOR
        public override string ToString()
        {
            return $"Curator ID: {CuratorID}\t Name: {FirstName} {LastName}\t Commission: {Commission}\n";
        }
        //RETRIEVE CURATOR ID FROM ARTPIECE
        public string GetID(string pieceID)
        {
            ArtPiece art = Gallery.artPieces.Find(i => i.PieceID == pieceID);
            var d = art.CuratorID;
            return d;
        }
        //ASSIGN COMMISSION TO CURATOR
        public void SetComm(double a, string pieceID)
        {
            var ret = GetID(pieceID);
            ArtPiece s = new ArtPiece();
            var c = s.CalculateComm(a, pieceID);
            double sc = CommRate * c;
            Gallery.curators.Where(w => w.CuratorID == ret).ToList().ForEach(d => d.Commission += sc);
        }
    }
}
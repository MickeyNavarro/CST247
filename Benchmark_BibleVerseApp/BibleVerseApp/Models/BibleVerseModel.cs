using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApp.Models
{
    public class BibleVerseModel
    {
        [Required]
        [DisplayName("Testament Selection")]
        public string Testament { get; set; }

        [Required]
        [DisplayName("Book Selection")]
        public string Book { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        [DisplayName("Chapter Number")]
        public int ChapterNumber { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        [DisplayName("Verse Number")]
        public int VerseNumber { get; set; }

        [Required]
        [DisplayName("Verse Text")]
        public string VerseText { get; set; }

        public BibleVerseModel(){}

        public BibleVerseModel(string testament, string book, int chapterNumber, int verseNumber, string verseText)
        {
            Testament = testament;
            Book = book;
            ChapterNumber = chapterNumber;
            VerseNumber = verseNumber;
            VerseText = verseText;
        }
    }
}
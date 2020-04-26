using BibleVerseApp.Models;
using BibleVerseApp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerseApp.Services.Business
{
    public class SecurityService
    {
        public bool Create(BibleVerseModel bibleVerseModel)
        {
            SecurityDAO service = new SecurityDAO();
            return service.EnterNewVerse(bibleVerseModel);
        }
        public BibleVerseModel Search(BibleVerseModel bibleVerseModel)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindVerse(bibleVerseModel);
        }
    }
}
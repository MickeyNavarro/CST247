﻿using BibleVerseApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BibleVerseApp.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Bible; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool EnterNewVerse(BibleVerseModel bibleVerse)
        {
            //assume that nothing is in the query 
            bool success = false;

            //provide the wuery string with a parameter placeholder
            string queryString = "insert into dbo.Bible (book, chapter, verse, text, testament) values (@Book, @ChapterNumber, @VerseNumber, @VerseText, @Testament)";

            //create and open the connection in a using block. This ensures that all resources will be closed and disclosed when the code exists
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //create the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.Add("@Testament", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.Testament;
                command.Parameters.Add("@Book", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.Book;
                command.Parameters.Add("@ChapterNumber", System.Data.SqlDbType.Int).Value = bibleVerse.ChapterNumber;
                command.Parameters.Add("@VerseNumber", System.Data.SqlDbType.Int).Value = bibleVerse.VerseNumber;
                command.Parameters.Add("@VerseText", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.VerseText;

                try
                {
                    conn.Open();
                    //save to see how many rows were affected by the creation in the database
                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();

                    //check if the creation was successful
                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }

        public bool FindVerse(BibleVerseModel bibleVerse)
        {
            //assume that nothing is in the query 
            bool success = false;

            //provide the wuery string with a parameter placeholder
            string queryString = "select * from dbo.Bible where testament = @Testament and book = @Book and chapter = @ChapterNumber and verse = @VerseNumber";

            //create and open the connection in a using block. This ensures that all resources will be closed and disclosed when the code exists
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //create the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.Add("@Testament", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.Testament;
                command.Parameters.Add("@Book", System.Data.SqlDbType.VarChar, 50).Value = bibleVerse.Book;
                command.Parameters.Add("@ChapterNumber", System.Data.SqlDbType.Int).Value = bibleVerse.ChapterNumber;
                command.Parameters.Add("@VerseNumber", System.Data.SqlDbType.Int).Value = bibleVerse.VerseNumber;

                try
                {
                    conn.Open();
                    //save to see what row found in the database
                    SqlDataReader reader = command.ExecuteReader();

                    //check if the reader was successful
                    if (reader.HasRows)
                        success = true;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
    }
}
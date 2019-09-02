/***************************************************************************************

   DocX – DocX is the community edition of Xceed Words for .NET

   Copyright (C) 2009-2017 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license

   For more features and fast professional support,
   pick up Xceed Words for .NET at https://xceed.com/xceed-words-for-net/

  *************************************************************************************/

using System;
using System.IO;
using System.Linq;

namespace Xceed.Words.NET.Examples
{
    public class BookmarkSample
    {
        #region Private Members

        private const string BookmarkSampleResourcesDirectory = Program.SampleDirectory + @"Bookmark\Resources\";
        private const string BookmarkSampleOutputDirectory = Program.SampleDirectory + @"Bookmark\Output\";

        #endregion Private Members

        #region Constructors

        static BookmarkSample()
        {
            if (!Directory.Exists(BookmarkSample.BookmarkSampleOutputDirectory))
            {
                Directory.CreateDirectory(BookmarkSample.BookmarkSampleOutputDirectory);
            }
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Insert a bookmark in a document and a paragraph(and replace the displayed bookmark).
        /// </summary>
        public static void InsertBookmarks()
        {
            Console.WriteLine("\tInsertBookmarks()");

            // Create a document
            using (DocX document = DocX.Create(BookmarkSample.BookmarkSampleOutputDirectory + @"InsertBookmarks.docx"))
            {
                // Add a title
                document.InsertParagraph("Insert Bookmarks").FontSize(15d).SpacingAfter(40d).Alignment = Alignment.center;

                // Insert a bookmark in the document.
                document.InsertBookmark("Bookmark1");

                // Add a paragraph
                var p = document.InsertParagraph("This document contains a bookmark named \"");
                p.Append(document.Bookmarks.First().Name);
                p.Append("\" just before this line.");
                p.SpacingAfter(50d);

                var _bookmarkName = "Bookmark2";
                var _displayedBookmarkName = "special";

                // Add another paragraph.
                var p2 = document.InsertParagraph("This paragraph contains a ");
                // Add a bookmark into the paragraph.
                p2.AppendBookmark(_bookmarkName);
                p2.Append(" bookmark named \"");
                p2.Append(document.Bookmarks.Last().Name);
                p2.Append("\" but displayed as \"" + _displayedBookmarkName + "\".");

                // Set a string to be displayed as the Bookmark in the second paragraph.
                p2.InsertAtBookmark(_displayedBookmarkName, _bookmarkName);

                document.Save();
                Console.WriteLine("\tCreated: InsertBookmarks.docx\n");
            }
        }

        /// <summary>
        /// Load a document with bookmarks and replace the bookmark's text.
        /// </summary>
        public static void ReplaceText()
        {
            Console.WriteLine("\tReplaceBookmarkText()");

            // Load a document
            using (DocX document = DocX.Load(BookmarkSample.BookmarkSampleResourcesDirectory + @"DocumentWithBookmarks.docx"))
            {
                // Get the regular bookmark from the document and replace its Text.
                var regularBookmark = document.Bookmarks["regBookmark"];
                if (regularBookmark != null)
                {
                    regularBookmark.SetText("Regular Bookmark has been changed");
                }

                // Get the formatted bookmark from the document and replace its Text.
                var formattedBookmark = document.Bookmarks["formattedBookmark"];
                if (formattedBookmark != null)
                {
                    formattedBookmark.SetText("Formatted Bookmark has been changed");
                }

                document.SaveAs(BookmarkSample.BookmarkSampleOutputDirectory + @"ReplaceBookmarkText.docx");
                Console.WriteLine("\tCreated: ReplaceBookmarkText.docx\n");
            }

            // Load a document
            using (DocX document = DocX.Load(BookmarkSample.BookmarkSampleResourcesDirectory + @"y_RMC_Standard_Lease_Non_Stabilized_Part_11.docx"))
            {
                // Get the regular bookmark from the document and replace its Text.
                document.ExposeFormFieldBookmark("SIGNA01");
                document.ExposeFormFieldBookmark("DATESIGNEDA01");
                document.ExposeFormFieldBookmark("SIGNA02");
                document.ExposeFormFieldBookmark("DATESIGNEDA02");
                document.ExposeFormFieldBookmark("SIGNA03");
                document.ExposeFormFieldBookmark("DATESIGNEDA03");
                document.ExposeFormFieldBookmark("SIGNA04");
                document.ExposeFormFieldBookmark("DATESIGNEDA04");
                document.ExposeFormFieldBookmark("SIGNM01");
                document.ExposeFormFieldBookmark("DATESIGNEDM01");
                document.ExposeFormFieldBookmark("SIGNG01");
                document.ExposeFormFieldBookmark("DATESIGNEDG01");

                document.SaveAs(BookmarkSample.BookmarkSampleOutputDirectory + @"y_RMC_Standard_Lease_Non_Stabilized_Part_11.docx");
                Console.WriteLine("\tCreated: y_RMC_Standard_Lease_Non_Stabilized_Part_11.docx\n");
            }

            using (DocX document = DocX.Load(BookmarkSample.BookmarkSampleResourcesDirectory + @"y_RMC_Standard_Lease_Non_Stabilized_Part_1.docx"))
            {
                // Get the regular bookmark from the document and replace its Text.
                document.ExposeFormFieldBookmark("INITIALA01");
                document.ExposeFormFieldBookmark("INITIALA02");
                document.ExposeFormFieldBookmark("INITIALA03");
                document.ExposeFormFieldBookmark("INITIALA04");

                document.SaveAs(BookmarkSample.BookmarkSampleOutputDirectory + @"y_RMC_Standard_Lease_Non_Stabilized_Part_1.docx");
                Console.WriteLine("\tCreated: y_RMC_Standard_Lease_Non_Stabilized_Part_1.docx\n");
            }

            //INITIALA01
        }

        #endregion Public Methods
    }
}
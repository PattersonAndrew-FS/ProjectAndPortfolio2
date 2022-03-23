using System;
using System.Collections.Generic;
using System.IO;

namespace SignInSignUp
{
    public class WatchListService
    {
        private  List<string> watchList;
        private string filePath;

        public WatchListService()
        {
            //Create file path
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "watchlist.txt");
           watchList = ReadWatchListFromFile();
        }
        //Set up streamreader
        public List<string> ReadWatchListFromFile()
        {
          List<string> watchListFromFile = new List<string>();
            if (!File.Exists(filePath))
            {
                return watchListFromFile;
            }
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string row = null;
                do
                {
                    row = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(row))
                    {
                        watchListFromFile.Add(row);
                    
                    }

                } while (!string.IsNullOrEmpty(row));

            }
            return watchListFromFile;
        }
        // Write to file so it can be read
        public void WriteWatchListToFile()
        {
            using (StreamWriter streamWriter = File.CreateText(filePath))
            {
                foreach (var item in watchList)
                {
                    
                    streamWriter.WriteLine(item);
                }
            }
        }
        // Check against title
        public bool DoesTitleExist(string title)
        {
            foreach (var item in watchList)
            {
                if (item.Equals(title))
                {
                    return true;
                }

            }
            return false;
        }
        public bool AddToWatchlist(string title)
        {
            try
            {
                watchList.Add(title);
                WriteWatchListToFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public List<WatchlistRow> GetWatchlist()
        {
            List<WatchlistRow> result = new List<WatchlistRow>();
            foreach (var item in watchList)
            {
                WatchlistRow watchlistRow = new WatchlistRow();
                watchlistRow.Title = item;
                result.Add(watchlistRow);

            }
            return result;
        }

        public bool RemoveFromWatchlist(string title)
        {
            try
            {
                watchList.Remove(title);
                WriteWatchListToFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Models;
using Microsoft.Data.Sqlite;

namespace MahApps.Core
{
    public static class DbCommands
    {
        static string FileName = "BudgetDb.db";

        public static void InitializeDb()
        {
            string DbPath = Path.Combine("C:\\Users\\mattia\\Documents\\GitHub\\CompSci-NEA-Project\\Budget Application Test", FileName);

            using (SqliteConnection connection = new SqliteConnection($"Filename={DbPath}"))
            {
                connection.Open();
                string TableCommand = "CREATE TABLE IF NOT EXISTS budgetsTable(" +
                    "ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "StartDate VARCHAR(20) NOT NULL, " +
                    "EndDate VARCHAR(20) NOT NULL, " +
                    "BudgetAmount DOUBLE NOT NULL);";

                SqliteCommand CreateTable = new SqliteCommand(TableCommand, connection);

                CreateTable.ExecuteReader();

            }
        }


        public static void DataInDb (string StartDate, string EndDate, double BudgetAmount)
        {
            string DbPath = Path.Combine("C:\\Users\\mattia\\Documents\\GitHub\\CompSci-NEA-Project\\Budget Application Test", FileName);

            using (SqliteConnection connection = new SqliteConnection($"Filename={DbPath}"))
            {
                connection.Open();
                string TableCommand = $"INSERT INTO budgetsTable (StartDate, EndDate, BudgetAmount) VALUES(" +
                    $"{StartDate}, {EndDate}, {BudgetAmount});";

                SqliteCommand AddToTable = new SqliteCommand(TableCommand, connection);

                AddToTable.ExecuteReader();

            }
        }


    }
}

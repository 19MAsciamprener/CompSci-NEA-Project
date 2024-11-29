using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
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

            using (var connection = new SqliteConnection($"Filename={DbPath}"))
            {
                connection.Open();
                string TableCommand = "CREATE TABLE IF NOT EXISTS budgetsTable(" +
                    "ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "StartDate VARCHAR(20) NOT NULL, " +
                    "EndDate VARCHAR(20) NOT NULL, " +
                    "BudgetAmount DOUBLE NOT NULL);";

                var CreateTable = new SqliteCommand(TableCommand, connection);

                CreateTable.ExecuteReader();

            }
        }


        public static void DataInDb (string StartDate, string EndDate, double BudgetAmount)
        {
            string DbPath = Path.Combine("C:\\Users\\mattia\\Documents\\GitHub\\CompSci-NEA-Project\\Budget Application Test", FileName);

            using (var connection = new SqliteConnection($"Filename={DbPath}"))
            {
                connection.Open();
                string TableCommand = $"INSERT INTO budgetsTable (StartDate, EndDate, BudgetAmount) VALUES(" +
                    $"{StartDate}, {EndDate}, {BudgetAmount});";

                var AddToTable = new SqliteCommand(TableCommand, connection);

                AddToTable.ExecuteReader();

            }
        }

        public static BudgetClass RetreiveData(int IdVar)
        {
            string DbPath = Path.Combine("C:\\Users\\mattia\\Documents\\GitHub\\CompSci-NEA-Project\\Budget Application Test", FileName);

            using (var connection = new SqliteConnection($"Filename={DbPath}"))
            {
                connection.Open();
                string TableCommand = "SELECT * FROM budgetsTable WHERE ID = @id";


                var RetData = new SqliteCommand(TableCommand, connection);
                RetData.Parameters.AddWithValue("@id", IdVar);

                var reader = RetData.ExecuteReader();
                if (reader.HasRows)
                {
                    int ID = 0;
                    string StartDate = string.Empty;
                    string EndDate = string.Empty;
                    double BudgetAmount = 0;

                    while (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        StartDate = reader.GetString(1);
                        EndDate = reader.GetString(2);
                        BudgetAmount = reader.GetDouble(3);

                    }

                    BudgetClass budget = new BudgetClass
                    {
                        Id = ID,
                        StartDate = DateTime.Parse(StartDate),
                        EndDate = DateTime.Parse(EndDate),
                        BudgetAmount = BudgetAmount,
                    };

                    if (budget != null)
                    {
                        return budget;
                    }

                    else
                    {
                        return null;
                    }
                }

                else
                {
                    return null;
                }

            }

        }
        public static int IdCount()
        {
            int Id = 0;
            string DbPath = Path.Combine("C:\\Users\\mattia\\Documents\\GitHub\\CompSci-NEA-Project\\Budget Application Test", FileName);

            using (var connection = new SqliteConnection($"Filename={DbPath}"))
            {
                connection.Open();
                string TableCommand = "SELECT Count(*) FROM budgetsTable";


                var ReadID = new SqliteCommand(TableCommand, connection);
                var reader = ReadID.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id = reader.GetInt32(0);

                    }

                }
                return Id;

            }
        }
    }
}

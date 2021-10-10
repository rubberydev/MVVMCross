

namespace TipCalculator.Android.Helpers
{
    using global::Android.Util;
    using SQLite;
    using System.Collections.Generic;

    /// <summary>
    /// this class is used to register executions and show posible exceptions throught Android.Util.Log
    /// </summary>
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExecutionHistorial.db")))
                {
                    connection.CreateTable<Historial>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warn("SQLiteEx CREATING ::((", ex.Message);
                return false;
            }
        }
        //Add or Insert Operation  

        public bool insertIntoTable(Historial historial)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExecutionHistorial.db")))
                {
                    connection.Insert(historial);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEx INSERTING:( ", ex.Message);
                return false;
            }
        }
        public List<Historial> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExecutionHistorial.db")))
                {
                    return connection.Table<Historial>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Edit Operation  

        public bool updateTable(Historial historial)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExecutionHistorial.db")))
                {
                    connection.Query<Historial>("UPDATE Historial set Register=?,  Where Id=?",historial.Register);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEx UPDATING :(", ex.Message);
                return false;
            }
        }
        //Delete Data Operation  

        public bool removeTable(Historial historial)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExecutionHistorial.db")))
                {
                    connection.Delete(historial);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Error("SQLiteEx REMOVING :(", ex.Message);
                return false;
            }
        }
        //Select Operation  

        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ExecutionHistorial.db")))
                {
                    connection.Query<Historial>("SELECT * FROM Historial Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}
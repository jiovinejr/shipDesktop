using Npgsql;
using ShipApp.Data;
using ShipApp.MVVM.Models;
using System.Diagnostics;

namespace ShipApp.Service
{
    class FileUploadService
    {
        public void InsertFile(FileUpload file)
        {
            try
            {
                using var conn = DbConnectionFactory.CreateConnection();
                conn.Open();

                string sql = @"INSERT INTO file_uploads (file_name, file_drive_id, is_processed, time_uploaded)
                       VALUES (@fileName, @fileDriveId, @isProcessed, @timeUploaded)";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("fileName", file.FileName);
                cmd.Parameters.AddWithValue("fileDriveId", file.FileDriveId);
                cmd.Parameters.AddWithValue("isProcessed", file.IsProcessed);
                cmd.Parameters.AddWithValue("timeUploaded", file.TimeUploaded);

                cmd.ExecuteNonQuery();
            }
            catch (Npgsql.PostgresException ex)
            {
                Debug.WriteLine($"❌ PostgresException: {ex.MessageText} | Code: {ex.SqlState} | Detail: {ex.Detail}");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ General DB Error: {ex}");
                throw;
            }
        }

    }
}

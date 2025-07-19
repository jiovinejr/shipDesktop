using Npgsql;
using ShipDesktop.Data;
using ShipDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDesktop.Service
{
    class FileUploadService
    {
        public void InsertFile(FileUpload file)
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
    }
}

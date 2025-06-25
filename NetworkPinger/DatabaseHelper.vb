Imports System.Data.SQLite
Imports System.IO
Public Class DatabaseHelper
    Private Const DbFileName As String = "devices.db"
    Private ReadOnly ConnectionString As String = $"Data Source={DbFileName};Version=3;"

    Public Sub New()
        InitializeDatabase()
    End Sub

    Private Sub InitializeDatabase()
        If Not File.Exists(DbFileName) Then
            SQLiteConnection.CreateFile(DbFileName)
            Using conn As New SQLiteConnection(ConnectionString)
                conn.Open()
                Dim sql As String = "CREATE TABLE IF NOT EXISTS Devices (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        IpAddress TEXT NOT NULL,
                                        Description TEXT
                                    );"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End If
    End Sub

    Public Function GetDevices() As List(Of Device)
        Dim devices As New List(Of Device)
        Using conn As New SQLiteConnection(ConnectionString)
            conn.Open()
            Dim sql As String = "SELECT Id, IpAddress, Description FROM Devices ORDER BY Description;"
            Using cmd As New SQLiteCommand(sql, conn)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        devices.Add(New Device() With {
                            .Id = reader.GetInt32(0),
                            .IpAddress = reader.GetString(1),
                            .Description = reader.GetString(2)
                        })
                    End While
                End Using
            End Using
        End Using
        Return devices
    End Function

    Public Sub AddDevice(ipAddress As String, description As String)
        Using conn As New SQLiteConnection(ConnectionString)
            conn.Open()
            Dim sql As String = "INSERT INTO Devices (IpAddress, Description) VALUES (@ip, @desc);"
            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ip", ipAddress)
                cmd.Parameters.AddWithValue("@desc", description)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateDevice(id As Integer, ipAddress As String, description As String)
        Using conn As New SQLiteConnection(ConnectionString)
            conn.Open()
            Dim sql As String = "UPDATE Devices SET IpAddress = @ip, Description = @desc WHERE Id = @id;"
            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ip", ipAddress)
                cmd.Parameters.AddWithValue("@desc", description)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeleteDevice(id As Integer)
        Using conn As New SQLiteConnection(ConnectionString)
            conn.Open()
            Dim sql As String = "DELETE FROM Devices WHERE Id = @id;"
            Using cmd As New SQLiteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class

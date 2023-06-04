using System;
using System.Data;
using System.Data.OleDb;

public class KoneksiDB
{
    public OleDbCommand cmd;
    public OleDbConnection conn;
    public OleDbDataAdapter OleAdapter;
    public OleDbDataReader OleReader;

    public void Koneksi()
    {
        conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=db1.accdb");
        conn.Open();
    }
}

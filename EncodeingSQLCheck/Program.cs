

//foreach (var item in collection)
//{

//}

using System.Data.SqlClient;

//string connectionString = "";
string connectionString = "Data Source=.;Initial Catalog=Students;Integrated Security=True;";
//SqlConnection connection = new SqlConnection(connectionString);


string Encoding()
{
    return "Encoding";
}

//string countQuery = "SELECT COUNT(*) AS row_count FROM StudentsEncodingDetails;"; // לקחת את המספר של השורות בטבלה של הפנים המוכרות השמורות
//string sCount = "";
//int count = int.Parse(sCount);
int count = 0;

try
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string countQuery = "SELECT COUNT(*) AS row_count FROM StudentsEncodingDetails;";
        SqlCommand command = new SqlCommand(countQuery, connection);
        count = (int)command.ExecuteScalar();

        //Console.WriteLine("Row count: " + rowCount);
    }
}
catch (Exception ex)
{
    //Console.WriteLine("Error: " + ex.Message);
}




//string query = "select EncodingFace where ID= @i";// כדי לשלוף את השורה
//תהיה לי עם זה בעיה ברגע שהמספור יכול להתבלבל ולקפוץ למספרים גבוהים

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    for (int i = 1; i <= count; i++)
    {
        string sqlQuery = "SELECT EncodingFace FROM StudentsEncodingDetails WHERE ID = @ID";

        SqlCommand command = new SqlCommand(sqlQuery, connection);
        command.Parameters.AddWithValue("@ID", i);

        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                // Access the EncodingFace value
                string encodingFace = reader["EncodingFace"].ToString();

                Encoding();
            }
        }
    }
}
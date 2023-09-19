using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using IOWA.ITS4.PRESCREEN.DATAOBJECTS;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace IOWA.ITS4.PRESCREEN.BUSINESSLOGIC
{
    public class CountyMain_BL
    {

        public CountyMain_BL()
        {
        }
       
        //Function to get Adjacency
        public Boolean get_countyAdjacency(ref AdjacencyChecker_IP countyInputs)
        {
            
            Boolean result = false;

            using (SqlConnection connection = new SqlConnection(countyInputs.connectionString))
            {
                try
                {
                    connection.Open();
                    //To Call CheckCondition Stored Procedure
                    using SqlCommand command = new SqlCommand("CheckCondition", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    //To send MAPID to stored proceedure
                    SqlParameter paramMapId = new SqlParameter("@MAPID", SqlDbType.Int);
                    paramMapId.Value = countyInputs.mapID;
                    command.Parameters.Add(paramMapId);

                    //To send ADJACENTMAPID to stored proceedure
                    SqlParameter paramAdjacentMapId = new SqlParameter("@ADJACENTMAPID", SqlDbType.Int);
                    paramAdjacentMapId.Value = countyInputs.adjacentMapID; 
                    command.Parameters.Add(paramAdjacentMapId);

                    //To store ReturnValue from stored proceedure
                    SqlParameter paramReturnValue = new SqlParameter("@RETURNVALUE", SqlDbType.Int);
                    paramReturnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(paramReturnValue);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                    result = Convert.ToBoolean(paramReturnValue.Value);
                    

                }
                catch (SqlException ex)
                {
                    // Handle any connection errors here
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return result;
        }
        
        //Function to Get County Names
        public void get_countyNames(ref AdjacencyChecker_IP countyInputs, ref AdjacencyChecker_OP countyNamesOutput)
        {

            using (SqlConnection connection = new SqlConnection(countyInputs.connectionString))
            {
                try
                {
                    
                    connection.Open();
                    //To Call CountyNames Stored Procedure
                    using SqlCommand command = new SqlCommand("CountyNames", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    //To send MAPID to stored proceedure
                    SqlParameter paramMapId = new SqlParameter("@MAPID", SqlDbType.Int);
                    paramMapId.Value = countyInputs.mapID; 
                    command.Parameters.Add(paramMapId);

                    //To send ADJACENTMAPID to stored proceedure
                    SqlParameter paramAdjacentMapId = new SqlParameter("@ADJACENTMAPID", SqlDbType.Int);
                    paramAdjacentMapId.Value = countyInputs.adjacentMapID; 
                    command.Parameters.Add(paramAdjacentMapId);

                    //Read data from stored proceedure using a DataTable
                    using SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dtCountyNames = new DataTable();
                    adapter.Fill(dtCountyNames);

                    countyNamesOutput.countyName = dtCountyNames.Rows[0]["CountyName"].ToString();
                    countyNamesOutput.adjacentCountyName = dtCountyNames.Rows[1]["CountyName"].ToString();

                }
                catch (SqlException ex)
                {
                    // Handle any connection errors here

                    Console.WriteLine("Error: " + ex.Message);
                    

                }
            }
          
        }

    }
}

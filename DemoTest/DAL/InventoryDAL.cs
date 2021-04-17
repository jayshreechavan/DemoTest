using DemoTest.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DemoTest.DAL;

namespace DemoTest.DAL
{
    public class InventoryDAL
    {

        SqlDataAdapter SDA;
        SqlConnection sqlcon;
        SqlDataReader dr;
        SqlCommand cmd;
        public object AddInventoryDetails(InventoryDetailsModel obj)
        {
            try
            {

                int result = 0;
                using (sqlcon = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("Inventory_DM", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Description", obj.Description);
                    cmd.Parameters.AddWithValue("@Price", obj.Price);
                    cmd.Parameters.AddWithValue("@TotalPrice", obj.TotalPrice);
                    cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
                    cmd.Parameters.AddWithValue("@Date", obj.Date);
                    cmd.Parameters.AddWithValue("@InventoryID", obj.InventoryID);
                    cmd.Parameters.AddWithValue("@Mode", 1);
                    cmd.Parameters.Add("@Error", SqlDbType.Int);
                    cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    return result = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                }
            }
            finally
            {
                sqlcon.Close();
            }
        }

        public List<InventoryDetailsModel> EditInventory(int iD)
        {
            List<InventoryDetailsModel> desList = new List<InventoryDetailsModel>();
            try
            {
                //sqlcon = new SqlConnection(SqlConn);
                sqlcon = new SqlConnection(AppConfiguration.ConnectionString);
                cmd = new SqlCommand("Inventory_DM", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", 4);
                cmd.Parameters.AddWithValue("@InventoryID", iD);
                sqlcon.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InventoryDetailsModel obj = new InventoryDetailsModel();
                    obj.InventoryID = Convert.ToInt32(dr["InventoryID"]);
                    obj.Name = Convert.ToString(dr["Name"]);
                    obj.Description = Convert.ToString(dr["Description"]);
                    obj.Date= Convert.ToString(dr["Date"]);
                    obj.Price= Convert.ToDecimal(dr["Price"]);
                    obj.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                    obj.Quantity= Convert.ToInt32(dr["Quantity"]);                    
                    desList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }
            return desList;
        }

        public object DeleteInventory(int iD)
        {
            try
            {

                int result = 0;
                using (sqlcon = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("Inventory_DM", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventoryID", iD);
                    cmd.Parameters.AddWithValue("@Mode", 3);
                    cmd.Parameters.Add("@Error", SqlDbType.Int);
                    cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    return result = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                }
            }
            finally
            {
                sqlcon.Close();
            }
        }

        public List<InventoryDetailsModel> GetAllList()
        {
            List<InventoryDetailsModel> desList = new List<InventoryDetailsModel>();
            try
            {
                //sqlcon = new SqlConnection(SqlConn);
                sqlcon = new SqlConnection(AppConfiguration.ConnectionString);
                cmd = new SqlCommand("Inventory_DM", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", 2);
                sqlcon.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InventoryDetailsModel obj = new InventoryDetailsModel();
                    obj.InventoryID = Convert.ToInt32(dr["InventoryID"]);
                    obj.Name = Convert.ToString(dr["Name"]);
                    obj.Description= Convert.ToString(dr["Description"]);
                    obj.Price = Convert.ToDecimal(dr["Price"]);
                    obj.TotalPrice= Convert.ToDecimal(dr["TotalPrice"]);
                    obj.Quantity = Convert.ToInt32(dr["Quantity"]);
                    obj.Date = Convert.ToString(dr["Date"]);
                    desList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }
            return desList;
        }
    }
}
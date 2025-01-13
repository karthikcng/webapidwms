
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapidwms.datacontracts;
using webapidwms.dataobjects;

namespace webapidwms.bussinesslogic
{
    public class MAIN_BL
    {
        public int Get_Dwms_Menu(ref get_menu_IP ip, ref get_menu_OP op, string connectionString)
        {
            string query = @"
            SELECT DISTINCT  tenant_code, system_code,system_id,tenant_id, l1_menu_item_name1, l2_menu_item_name1 , l1_menu_item_display_order, l2_menu_item_display_order 
            FROM system.vw_user_role_main_menu
            WHERE tenant_id = @TenantID
              AND system_id = @SystemID
            ORDER BY l1_menu_item_display_order, l2_menu_item_display_order;";


            DataTable dtUserDetail = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenantID", ip.tenant_id);
                    command.Parameters.AddWithValue("@SystemID", ip.system_id);

                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dtUserDetail);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return -1;
                    }
                }
            }


            if (dtUserDetail.Rows.Count > 0)
            {
                op.ml_dwms = new List<vw_user_role_main_menu>();

                foreach (DataRow row in dtUserDetail.Rows)
                {
                    vw_user_role_main_menu menuItem = new vw_user_role_main_menu
                    {
                        tenant_code = Convert.ToInt32(row["tenant_code"]),
                        system_code = row["system_code"].ToString(),
                        tenant_id = Convert.ToInt32(row["tenant_id"]),
                        system_id = Convert.ToInt32(row["system_id"]),
                        l1_menu_item_name1 = row["l1_menu_item_name1"].ToString(),
                        l2_menu_item_name1 = row["l2_menu_item_name1"].ToString(),
                        l1_menu_item_display_order = Convert.ToInt32(row["l1_menu_item_display_order"]),
                        l2_menu_item_display_order = row["l2_menu_item_display_order"].ToString(),
                    };

                    op.ml_dwms.Add(menuItem);
                }
            }

            return 0;
        }
        //public int GetHeader(ref get_header_IP ip, ref get_header_OP op, string connectionString)
        //{
        //    string query = @"SELECT TOP (1000) [ID],[ParentID],[IconName],[MainName] FROM [CMP365_DEV].[dbo].[tbl.main]";

        //    DataTable dtUserDetail = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //                {
        //                    adapter.Fill(dtUserDetail);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Error: " + ex.Message);
        //                return -1;
        //            }
        //        }
        //    }

        //    if (dtUserDetail.Rows.Count > 0)
        //    {
        //        op.ml_main = new List<tbl>();

        //        foreach (DataRow row in dtUserDetail.Rows)
        //        {
        //            tbl menuItem = new tbl
        //            {
        //                ID = row.Field<int>("ID"),
        //                ParentID = row.Field<string>("ParentID"),
        //                IconName = row.Field<string>("IconName"),
        //                MainName = row.Field<string>("MainName"),
        //            };

        //            op.ml_main.Add(menuItem);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No data found.");
        //    }

        //    return 0;
        //}
    }
}

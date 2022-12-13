
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootBallLeague.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SaveData() { ViewBag.result = ""; return View(); }
        [HttpPost]
        public ActionResult SaveData(string matchid, string teamname1, string teamname2, string status, string winningteam, string points)
        {
            String constring = "Data Source=tulasiVM;Initial Catalog=master;Integrated Security=True"; SqlConnection sqlcon = new SqlConnection(constring); String pname = "InsertValues"; sqlcon.Open(); SqlCommand com = new SqlCommand(pname, sqlcon); com.CommandType = System.Data.CommandType.StoredProcedure; com.Parameters.AddWithValue("@Matchid", Convert.ToInt16(matchid)); com.Parameters.AddWithValue("@Teamname1", teamname1); com.Parameters.AddWithValue("@Teamname2", teamname2); com.Parameters.AddWithValue("@status", status); com.Parameters.AddWithValue("@winningteam", winningteam); com.Parameters.AddWithValue("@points", Convert.ToInt16(points));

            com.ExecuteNonQuery(); sqlcon.Close(); ViewBag.result = "Record Has Been Saved Successfully"; return View();
        }
    }
}


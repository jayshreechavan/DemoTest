using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoTest.Models;
using DemoTest.DAL;
using System.Net.Http;


namespace DemoTest.Controllers
{
    public class ShopBridgeController : Controller
    {
        InventoryDAL objDAL = new InventoryDAL();
        CommonMethod cmd = new CommonMethod();
        // GET: ShopBridge
        public ActionResult AddInventory()
        {
            return View();
        }   
        
         [HttpPost]    
        public ActionResult AddInventoryDetails(InventoryDetailsModel objDetails)
        {
            if (Session["InventoryID"] != null)
                objDetails.InventoryID = Convert.ToInt32(Session["InventoryID"].ToString());
            Session["InventoryID"] = null;
            return Json(objDAL.AddInventoryDetails(objDetails));

        }
        [HttpGet]
        public JsonResult BindList()
        {
            List<InventoryDetailsModel> lst= new List<InventoryDetailsModel>();
            lst= objDAL.GetAllList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteInventory(int ID)
        {

            return Json(objDAL.DeleteInventory(ID));
        }
        [HttpPost]
        public ActionResult EditInventory(int ID)
        {
            Session["InventoryID"] = Convert.ToString(ID);
            InventoryDetailsModel obj = new InventoryDetailsModel();
            List<InventoryDetailsModel> typeList = new List<InventoryDetailsModel>();
            typeList = objDAL.EditInventory(ID);
            obj = typeList[0];

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}
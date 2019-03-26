using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace CuaHangDAL
{
    /// <summary>
    /// Controller class for TaiKhoan
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TaiKhoanController
    {
        // Preload our schema..
        TaiKhoan thisSchemaLoad = new TaiKhoan();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TaiKhoanCollection FetchAll()
        {
            TaiKhoanCollection coll = new TaiKhoanCollection();
            Query qry = new Query(TaiKhoan.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TaiKhoanCollection FetchByID(object MaTK)
        {
            TaiKhoanCollection coll = new TaiKhoanCollection().Where("MaTK", MaTK).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TaiKhoanCollection FetchByQuery(Query qry)
        {
            TaiKhoanCollection coll = new TaiKhoanCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object MaTK)
        {
            return (TaiKhoan.Delete(MaTK) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object MaTK)
        {
            return (TaiKhoan.Destroy(MaTK) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public TaiKhoan Insert(TaiKhoan item)
	    {
            
		    item.Save(UserName);
            return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public TaiKhoan Update(TaiKhoan item2)
	    {
		    TaiKhoan item = new TaiKhoan();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.MaTK = item2.MaTK;
				
			item.TenTK = item2.TenTK;
				
			item.MatKhau = item2.MatKhau;
				
			item.Loaitk = item2.Loaitk;
				
			item.Status = item2.Status;
				
			item.Ngaycapnhap = item2.Ngaycapnhap;
				
	        item.Save(UserName);
            return item;
	    }
    }
}

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
    /// Controller class for KhachHang
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class KhachHangController
    {
        // Preload our schema..
        KhachHang thisSchemaLoad = new KhachHang();
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
        public KhachHangCollection FetchAll()
        {
            KhachHangCollection coll = new KhachHangCollection();
            Query qry = new Query(KhachHang.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public KhachHangCollection FetchByID(object MaKh)
        {
            KhachHangCollection coll = new KhachHangCollection().Where("MaKh", MaKh).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public KhachHangCollection FetchByQuery(Query qry)
        {
            KhachHangCollection coll = new KhachHangCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object MaKh)
        {
            return (KhachHang.Delete(MaKh) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object MaKh)
        {
            return (KhachHang.Destroy(MaKh) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public KhachHang Insert(KhachHang item)
	    {
		     
		    item.Save(UserName);
            return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public KhachHang Update(KhachHang item2)
	    {
		    KhachHang item = new KhachHang();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.MaKh = item2.MaKh;
				
			item.TenKH = item2.TenKH;
				
			item.DiaChi = item2.DiaChi;
				
			item.Sdt = item2.Sdt;
				
			item.Email = item2.Email;
				
			item.Cmd = item2.Cmd;
				
			item.Diemso = item2.Diemso;
				
			item.MaTV = item2.MaTV;
				
			item.MaTk = item2.MaTk;
				
			item.Ngaycapnhap = item2.Ngaycapnhap;
				
			item.MaNVchinhsua = item2.MaNVchinhsua;
				
			item.Status = item2.Status;
				
	        item.Save(UserName);
            return item;
	    }
     
    }
}
    
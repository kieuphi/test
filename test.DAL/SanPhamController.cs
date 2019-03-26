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
    /// Controller class for SanPham
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SanPhamController
    {
        // Preload our schema..
        SanPham thisSchemaLoad = new SanPham();
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
        public SanPhamCollection FetchAll()
        {
            SanPhamCollection coll = new SanPhamCollection();
            Query qry = new Query(SanPham.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SanPhamCollection FetchByID(object Masp)
        {
            SanPhamCollection coll = new SanPhamCollection().Where("Masp", Masp).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SanPhamCollection FetchByQuery(Query qry)
        {
            SanPhamCollection coll = new SanPhamCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Masp)
        {
            return (SanPham.Delete(Masp) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Masp)
        {
            return (SanPham.Destroy(Masp) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public SanPham Insert(SanPham item)
	    {

	        
		    item.Save(UserName);
            return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public SanPham Update(SanPham item2)
	    {
            
		    SanPham item = new SanPham();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Masp = item2. Masp;
				
			item.TenSp = item2.TenSp;
				
			item.GiaNhap = item2.GiaNhap;
				
			item.SoLuongTon = item2.SoLuongTon;
				
			item.MaDm = item2.MaDm;
				
			item.Ngaycapnhap = item2.Ngaycapnhap;
				
			item.MaNVchinhsua = item2.MaNVchinhsua;
				
			item.Status = item2.Status;
				
			item.Hinhanh = item2.Hinhanh;
				
	        item.Save(UserName);
            return item;
	    }


    }
}
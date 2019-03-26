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
    /// Controller class for PN
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PnController
    {
        // Preload our schema..
        Pn thisSchemaLoad = new Pn();
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
        public PnCollection FetchAll()
        {
            PnCollection coll = new PnCollection();
            Query qry = new Query(Pn.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCollection FetchByID(object MaPN)
        {
            PnCollection coll = new PnCollection().Where("MaPN", MaPN).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PnCollection FetchByQuery(Query qry)
        {
            PnCollection coll = new PnCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object MaPN)
        {
            return (Pn.Delete(MaPN) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object MaPN)
        {
            return (Pn.Destroy(MaPN) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime? NgayNhap,int? MaNCC,int? MaNV,string Status)
	    {
		    Pn item = new Pn();
		    
            item.NgayNhap = NgayNhap;
            
            item.MaNCC = MaNCC;
            
            item.MaNV = MaNV;
            
            item.Status = Status;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int MaPN,DateTime? NgayNhap,int? MaNCC,int? MaNV,string Status)
	    {
		    Pn item = new Pn();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.MaPN = MaPN;
				
			item.NgayNhap = NgayNhap;
				
			item.MaNCC = MaNCC;
				
			item.MaNV = MaNV;
				
			item.Status = Status;
				
	        item.Save(UserName);
	    }
    }
}

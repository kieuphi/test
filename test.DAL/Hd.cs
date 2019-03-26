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
	/// Strongly-typed collection for the Hd class.
	/// </summary>
    [Serializable]
	public partial class HdCollection : ActiveList<Hd, HdCollection>
	{	   
		public HdCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>HdCollection</returns>
		public HdCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Hd o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the HD table.
	/// </summary>
	[Serializable]
	public partial class Hd : ActiveRecord<Hd>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Hd()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Hd(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Hd(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Hd(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("HD", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMaHD = new TableSchema.TableColumn(schema);
				colvarMaHD.ColumnName = "MaHD";
				colvarMaHD.DataType = DbType.Int32;
				colvarMaHD.MaxLength = 0;
				colvarMaHD.AutoIncrement = true;
				colvarMaHD.IsNullable = false;
				colvarMaHD.IsPrimaryKey = true;
				colvarMaHD.IsForeignKey = false;
				colvarMaHD.IsReadOnly = false;
				colvarMaHD.DefaultSetting = @"";
				colvarMaHD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaHD);
				
				TableSchema.TableColumn colvarNgayDat = new TableSchema.TableColumn(schema);
				colvarNgayDat.ColumnName = "NgayDat";
				colvarNgayDat.DataType = DbType.DateTime;
				colvarNgayDat.MaxLength = 0;
				colvarNgayDat.AutoIncrement = false;
				colvarNgayDat.IsNullable = true;
				colvarNgayDat.IsPrimaryKey = false;
				colvarNgayDat.IsForeignKey = false;
				colvarNgayDat.IsReadOnly = false;
				colvarNgayDat.DefaultSetting = @"";
				colvarNgayDat.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgayDat);
				
				TableSchema.TableColumn colvarMaKH = new TableSchema.TableColumn(schema);
				colvarMaKH.ColumnName = "MaKH";
				colvarMaKH.DataType = DbType.Int32;
				colvarMaKH.MaxLength = 0;
				colvarMaKH.AutoIncrement = false;
				colvarMaKH.IsNullable = true;
				colvarMaKH.IsPrimaryKey = false;
				colvarMaKH.IsForeignKey = true;
				colvarMaKH.IsReadOnly = false;
				colvarMaKH.DefaultSetting = @"";
				
					colvarMaKH.ForeignKeyTableName = "KhachHang";
				schema.Columns.Add(colvarMaKH);
				
				TableSchema.TableColumn colvarMaNV = new TableSchema.TableColumn(schema);
				colvarMaNV.ColumnName = "MaNV";
				colvarMaNV.DataType = DbType.Int32;
				colvarMaNV.MaxLength = 0;
				colvarMaNV.AutoIncrement = false;
				colvarMaNV.IsNullable = true;
				colvarMaNV.IsPrimaryKey = false;
				colvarMaNV.IsForeignKey = true;
				colvarMaNV.IsReadOnly = false;
				colvarMaNV.DefaultSetting = @"";
				
					colvarMaNV.ForeignKeyTableName = "NhanVien";
				schema.Columns.Add(colvarMaNV);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "status";
				colvarStatus.DataType = DbType.String;
				colvarStatus.MaxLength = 50;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"('trong')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("HD",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("MaHD")]
		[Bindable(true)]
		public int MaHD 
		{
			get { return GetColumnValue<int>(Columns.MaHD); }
			set { SetColumnValue(Columns.MaHD, value); }
		}
		  
		[XmlAttribute("NgayDat")]
		[Bindable(true)]
		public DateTime? NgayDat 
		{
			get { return GetColumnValue<DateTime?>(Columns.NgayDat); }
			set { SetColumnValue(Columns.NgayDat, value); }
		}
		  
		[XmlAttribute("MaKH")]
		[Bindable(true)]
		public int? MaKH 
		{
			get { return GetColumnValue<int?>(Columns.MaKH); }
			set { SetColumnValue(Columns.MaKH, value); }
		}
		  
		[XmlAttribute("MaNV")]
		[Bindable(true)]
		public int? MaNV 
		{
			get { return GetColumnValue<int?>(Columns.MaNV); }
			set { SetColumnValue(Columns.MaNV, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CuaHangDAL.CthdCollection CthdRecords()
		{
			return new CuaHangDAL.CthdCollection().Where(Cthd.Columns.MaHD, MaHD).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a KhachHang ActiveRecord object related to this Hd
		/// 
		/// </summary>
		public CuaHangDAL.KhachHang KhachHang
		{
			get { return CuaHangDAL.KhachHang.FetchByID(this.MaKH); }
			set { SetColumnValue("MaKH", value.MaKh); }
		}
		
		
		/// <summary>
		/// Returns a NhanVien ActiveRecord object related to this Hd
		/// 
		/// </summary>
		public CuaHangDAL.NhanVien NhanVien
		{
			get { return CuaHangDAL.NhanVien.FetchByID(this.MaNV); }
			set { SetColumnValue("MaNV", value.MaNV); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime? varNgayDat,int? varMaKH,int? varMaNV,string varStatus)
		{
			Hd item = new Hd();
			
			item.NgayDat = varNgayDat;
			
			item.MaKH = varMaKH;
			
			item.MaNV = varMaNV;
			
			item.Status = varStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varMaHD,DateTime? varNgayDat,int? varMaKH,int? varMaNV,string varStatus)
		{
			Hd item = new Hd();
			
				item.MaHD = varMaHD;
			
				item.NgayDat = varNgayDat;
			
				item.MaKH = varMaKH;
			
				item.MaNV = varMaNV;
			
				item.Status = varStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn MaHDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NgayDatColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MaKHColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MaNVColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string MaHD = @"MaHD";
			 public static string NgayDat = @"NgayDat";
			 public static string MaKH = @"MaKH";
			 public static string MaNV = @"MaNV";
			 public static string Status = @"status";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}

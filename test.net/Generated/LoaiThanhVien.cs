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
	/// Strongly-typed collection for the LoaiThanhVien class.
	/// </summary>
    [Serializable]
	public partial class LoaiThanhVienCollection : ActiveList<LoaiThanhVien, LoaiThanhVienCollection>
	{	   
		public LoaiThanhVienCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LoaiThanhVienCollection</returns>
		public LoaiThanhVienCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LoaiThanhVien o = this[i];
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
	/// This is an ActiveRecord class which wraps the LoaiThanhVien table.
	/// </summary>
	[Serializable]
	public partial class LoaiThanhVien : ActiveRecord<LoaiThanhVien>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LoaiThanhVien()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LoaiThanhVien(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LoaiThanhVien(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LoaiThanhVien(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LoaiThanhVien", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarMaLoaitv = new TableSchema.TableColumn(schema);
				colvarMaLoaitv.ColumnName = "MaLoaitv";
				colvarMaLoaitv.DataType = DbType.Int32;
				colvarMaLoaitv.MaxLength = 0;
				colvarMaLoaitv.AutoIncrement = true;
				colvarMaLoaitv.IsNullable = false;
				colvarMaLoaitv.IsPrimaryKey = true;
				colvarMaLoaitv.IsForeignKey = false;
				colvarMaLoaitv.IsReadOnly = false;
				colvarMaLoaitv.DefaultSetting = @"";
				colvarMaLoaitv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaLoaitv);
				
				TableSchema.TableColumn colvarTenLoai = new TableSchema.TableColumn(schema);
				colvarTenLoai.ColumnName = "TenLoai";
				colvarTenLoai.DataType = DbType.String;
				colvarTenLoai.MaxLength = 50;
				colvarTenLoai.AutoIncrement = false;
				colvarTenLoai.IsNullable = true;
				colvarTenLoai.IsPrimaryKey = false;
				colvarTenLoai.IsForeignKey = false;
				colvarTenLoai.IsReadOnly = false;
				colvarTenLoai.DefaultSetting = @"";
				colvarTenLoai.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTenLoai);
				
				TableSchema.TableColumn colvarUudai = new TableSchema.TableColumn(schema);
				colvarUudai.ColumnName = "uudai";
				colvarUudai.DataType = DbType.Double;
				colvarUudai.MaxLength = 0;
				colvarUudai.AutoIncrement = false;
				colvarUudai.IsNullable = true;
				colvarUudai.IsPrimaryKey = false;
				colvarUudai.IsForeignKey = false;
				colvarUudai.IsReadOnly = false;
				colvarUudai.DefaultSetting = @"";
				colvarUudai.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUudai);
				
				TableSchema.TableColumn colvarNgaycapnhap = new TableSchema.TableColumn(schema);
				colvarNgaycapnhap.ColumnName = "ngaycapnhap";
				colvarNgaycapnhap.DataType = DbType.DateTime;
				colvarNgaycapnhap.MaxLength = 0;
				colvarNgaycapnhap.AutoIncrement = false;
				colvarNgaycapnhap.IsNullable = true;
				colvarNgaycapnhap.IsPrimaryKey = false;
				colvarNgaycapnhap.IsForeignKey = false;
				colvarNgaycapnhap.IsReadOnly = false;
				colvarNgaycapnhap.DefaultSetting = @"";
				colvarNgaycapnhap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgaycapnhap);
				
				TableSchema.TableColumn colvarMaNVchinhsua = new TableSchema.TableColumn(schema);
				colvarMaNVchinhsua.ColumnName = "MaNVchinhsua";
				colvarMaNVchinhsua.DataType = DbType.Int32;
				colvarMaNVchinhsua.MaxLength = 0;
				colvarMaNVchinhsua.AutoIncrement = false;
				colvarMaNVchinhsua.IsNullable = true;
				colvarMaNVchinhsua.IsPrimaryKey = false;
				colvarMaNVchinhsua.IsForeignKey = true;
				colvarMaNVchinhsua.IsReadOnly = false;
				colvarMaNVchinhsua.DefaultSetting = @"";
				
					colvarMaNVchinhsua.ForeignKeyTableName = "NhanVien";
				schema.Columns.Add(colvarMaNVchinhsua);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("LoaiThanhVien",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("MaLoaitv")]
		[Bindable(true)]
		public int MaLoaitv 
		{
			get { return GetColumnValue<int>(Columns.MaLoaitv); }
			set { SetColumnValue(Columns.MaLoaitv, value); }
		}
		  
		[XmlAttribute("TenLoai")]
		[Bindable(true)]
		public string TenLoai 
		{
			get { return GetColumnValue<string>(Columns.TenLoai); }
			set { SetColumnValue(Columns.TenLoai, value); }
		}
		  
		[XmlAttribute("Uudai")]
		[Bindable(true)]
		public double? Uudai 
		{
			get { return GetColumnValue<double?>(Columns.Uudai); }
			set { SetColumnValue(Columns.Uudai, value); }
		}
		  
		[XmlAttribute("Ngaycapnhap")]
		[Bindable(true)]
		public DateTime? Ngaycapnhap 
		{
			get { return GetColumnValue<DateTime?>(Columns.Ngaycapnhap); }
			set { SetColumnValue(Columns.Ngaycapnhap, value); }
		}
		  
		[XmlAttribute("MaNVchinhsua")]
		[Bindable(true)]
		public int? MaNVchinhsua 
		{
			get { return GetColumnValue<int?>(Columns.MaNVchinhsua); }
			set { SetColumnValue(Columns.MaNVchinhsua, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public CuaHangDAL.KhachHangCollection KhachHangRecords()
		{
			return new CuaHangDAL.KhachHangCollection().Where(KhachHang.Columns.MaTV, MaLoaitv).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a NhanVien ActiveRecord object related to this LoaiThanhVien
		/// 
		/// </summary>
		public CuaHangDAL.NhanVien NhanVien
		{
			get { return CuaHangDAL.NhanVien.FetchByID(this.MaNVchinhsua); }
			set { SetColumnValue("MaNVchinhsua", value.MaNV); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTenLoai,double? varUudai,DateTime? varNgaycapnhap,int? varMaNVchinhsua)
		{
			LoaiThanhVien item = new LoaiThanhVien();
			
			item.TenLoai = varTenLoai;
			
			item.Uudai = varUudai;
			
			item.Ngaycapnhap = varNgaycapnhap;
			
			item.MaNVchinhsua = varMaNVchinhsua;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varMaLoaitv,string varTenLoai,double? varUudai,DateTime? varNgaycapnhap,int? varMaNVchinhsua)
		{
			LoaiThanhVien item = new LoaiThanhVien();
			
				item.MaLoaitv = varMaLoaitv;
			
				item.TenLoai = varTenLoai;
			
				item.Uudai = varUudai;
			
				item.Ngaycapnhap = varNgaycapnhap;
			
				item.MaNVchinhsua = varMaNVchinhsua;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn MaLoaitvColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TenLoaiColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UudaiColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NgaycapnhapColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MaNVchinhsuaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string MaLoaitv = @"MaLoaitv";
			 public static string TenLoai = @"TenLoai";
			 public static string Uudai = @"uudai";
			 public static string Ngaycapnhap = @"ngaycapnhap";
			 public static string MaNVchinhsua = @"MaNVchinhsua";
						
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

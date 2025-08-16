using System;
using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    #region 基础数据模块
    /// <summary>
    /// 物料分类实体类，对应数据库中的MaterialCategory表
    /// 用于对物料进行层级分类管理（如电子类、机械类等）
    /// </summary>
    public class MaterialCategory
    {
        /// <summary>
        /// 分类ID，自增主键
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 分类编码，唯一标识，用于系统内快速定位分类
        /// </summary>
        public string CategoryCode { get; set; }

        /// <summary>
        /// 分类名称，如"电子元件"、"五金配件"等
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 父分类ID，关联自身CategoryID，实现层级分类（顶级分类为null）
        /// </summary>
        public int? ParentCategoryID { get; set; }

        /// <summary>
        /// 分类描述，说明该分类包含的物料类型或特性
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否激活，1=激活（可用），0=停用（不可用）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：父分类信息（用于层级查询）
        /// </summary>
        public MaterialCategory ParentCategory { get; set; }

        /// <summary>
        /// 导航属性：子分类集合（用于层级查询）
        /// </summary>
        public List<MaterialCategory> ChildCategories { get; set; }
    }

    /// <summary>
    /// 物料单位实体类，对应数据库中的MaterialUnit表
    /// 定义物料的计量单位及单位间换算关系
    /// </summary>
    public class MaterialUnit
    {
        /// <summary>
        /// 单位ID，自增主键
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// 单位编码，唯一标识，如"PC"（个）、"KG"（千克）
        /// </summary>
        public string UnitCode { get; set; }

        /// <summary>
        /// 单位名称，如"个"、"千克"、"箱"等
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// 转换因子，相对于基础单位的换算比例（如1箱=10个，则箱的转换因子为10）
        /// </summary>
        public decimal ConversionFactor { get; set; }

        /// <summary>
        /// 是否基础单位，1=是（不可删除），0=否（可删除）
        /// </summary>
        public bool IsBaseUnit { get; set; }

        /// <summary>
        /// 单位描述，说明单位的使用场景或换算规则
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// 物料实体类，对应数据库中的Material表
    /// 存储物料的基本信息，是仓库管理的核心数据
    /// </summary>
    public class Material
    {
        /// <summary>
        /// 物料ID，自增主键
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 物料编码，唯一标识，系统内不可重复
        /// </summary>
        public string MaterialCode { get; set; }

        /// <summary>
        /// 物料名称，如"电阻1kΩ"、"轴承6203"等
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 分类ID，关联MaterialCategory表的CategoryID，用于物料归类
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 规格型号，描述物料的技术参数（如尺寸、精度等）
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 基础单位ID，关联MaterialUnit表的UnitID，物料的默认计量方式
        /// </summary>
        public int BaseUnitID { get; set; }

        /// <summary>
        /// 包装单位ID，关联MaterialUnit表的UnitID，可为空（如无独立包装单位则与基础单位一致）
        /// </summary>
        public int? PackageUnitID { get; set; }

        /// <summary>
        /// 单位重量，单个基础单位的重量（如1个零件重0.5kg），可为空
        /// </summary>
        public decimal? UnitWeight { get; set; }

        /// <summary>
        /// 单位体积，单个基础单位的体积（如1个箱子体积0.1m³），可为空
        /// </summary>
        public decimal? UnitVolume { get; set; }

        /// <summary>
        /// 最低库存，低于此数量时系统预警
        /// </summary>
        public decimal MinStock { get; set; }

        /// <summary>
        /// 最高库存，高于此数量时系统预警，可为空
        /// </summary>
        public decimal? MaxStock { get; set; }

        /// <summary>
        /// 有效期天数，物料从生产到过期的天数（0表示无有效期）
        /// </summary>
        public int ExpiryDays { get; set; }

        /// <summary>
        /// 是否激活，1=可用，0=停用（停用后无法参与业务）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 物料描述，说明物料的用途、特性等补充信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属分类信息
        /// </summary>
        public MaterialCategory Category { get; set; }

        /// <summary>
        /// 导航属性：基础单位信息
        /// </summary>
        public MaterialUnit BaseUnit { get; set; }

        /// <summary>
        /// 导航属性：包装单位信息（可为空）
        /// </summary>
        public MaterialUnit PackageUnit { get; set; }
    }
    #endregion

    #region 仓库管理模块
    /// <summary>
    /// 仓库实体类，对应数据库中的Warehouse表
    /// 存储仓库的基本信息，是库存管理的顶层组织单位
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// 仓库ID，自增主键
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 仓库编码，唯一标识，如"WH001"（中央仓）、"WH002"（区域仓）
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 仓库名称，如"上海中央仓"、"广州区域仓"
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 仓库类型，取值范围：'中央仓'、'区域仓'、'其他'
        /// </summary>
        public string WarehouseType { get; set; }

        /// <summary>
        /// 仓库地址，详细的地理位置信息
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系人，仓库的负责人姓名
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话，仓库负责人的联系方式
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 是否激活，1=启用（可存储物料），0=停用（不可进行出入库）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 仓库描述，说明仓库的功能、规模等信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：仓库包含的库区集合
        /// </summary>
        public List<StorageZone> StorageZones { get; set; }
    }

    /// <summary>
    /// 库区实体类，对应数据库中的StorageZone表
    /// 仓库内的分区，用于细化库存管理（如按物料类型分区）
    /// </summary>
    public class StorageZone
    {
        /// <summary>
        /// 库区ID，自增主键
        /// </summary>
        public int ZoneID { get; set; }

        /// <summary>
        /// 库区编码，在所属仓库内唯一，如"Z01"（电子区）、"Z02"（机械区）
        /// </summary>
        public string ZoneCode { get; set; }

        /// <summary>
        /// 库区名称，如"电子元件区"、"成品区"
        /// </summary>
        public string ZoneName { get; set; }

        /// <summary>
        /// 仓库ID，关联Warehouse表的WarehouseID，标识所属仓库
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 是否激活，1=启用，0=停用（停用后不可存储物料）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 库区描述，说明库区的用途或存储规则
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属仓库信息
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// 导航属性：库区包含的货架集合
        /// </summary>
        public List<StorageRack> StorageRacks { get; set; }
    }

    /// <summary>
    /// 货架实体类，对应数据库中的StorageRack表
    /// 库区中的存储架，用于具体存放物料
    /// </summary>
    public class StorageRack
    {
        /// <summary>
        /// 货架ID，自增主键
        /// </summary>
        public int RackID { get; set; }

        /// <summary>
        /// 货架编码，在所属库区中唯一，如"R01"、"R02"
        /// </summary>
        public string RackCode { get; set; }

        /// <summary>
        /// 货架名称，如"A区货架1"、"B区货架2"
        /// </summary>
        public string RackName { get; set; }

        /// <summary>
        /// 库区ID，关联StorageZone表的ZoneID，标识所属库区
        /// </summary>
        public int ZoneID { get; set; }

        /// <summary>
        /// 是否激活，1=启用，0=停用（停用后不可存储物料）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 货架描述，说明货架的规格或存储限制
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属库区信息
        /// </summary>
        public StorageZone StorageZone { get; set; }

        /// <summary>
        /// 导航属性：货架包含的库位集合
        /// </summary>
        public List<StorageLocation> StorageLocations { get; set; }
    }

    /// <summary>
    /// 库位实体类，对应数据库中的StorageLocation表
    /// 货架上的具体存储位置，是库存管理的最小单位
    /// </summary>
    public class StorageLocation
    {
        /// <summary>
        /// 库位ID，自增主键
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// 库位编码，在所属货架中唯一，如"L0101"（货架1的第1个库位）
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 库位名称，如"货架1层1位"
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 货架ID，关联StorageRack表的RackID，标识所属货架
        /// </summary>
        public int RackID { get; set; }

        /// <summary>
        /// 最大存放数量，库位可容纳的最大物料数量，可为空
        /// </summary>
        public decimal? MaxQuantity { get; set; }

        /// <summary>
        /// 当前存放数量，库位中现有物料的数量
        /// </summary>
        public decimal CurrentQuantity { get; set; }

        /// <summary>
        /// 是否激活，1=启用，0=停用（停用后不可存储物料）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 库位描述，说明库位的规格或存储要求
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属货架信息
        /// </summary>
        public StorageRack StorageRack { get; set; }
    }
    #endregion

    #region 采购管理模块
    /// <summary>
    /// 供应商实体类，对应数据库中的Supplier表
    /// 存储物料供应商的基本信息
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// 供应商ID，自增主键
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// 供应商编码，唯一标识，如"SP001"
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 供应商名称，企业全称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 供应商等级，取值范围：'一级'、'二级'、'三级'、'其他'，用于评估供应商优先级
        /// </summary>
        public string SupplierLevel { get; set; }

        /// <summary>
        /// 联系人，供应商的对接人姓名
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话，供应商联系人的联系方式
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 地址，供应商的注册地址或办公地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电子邮箱，供应商的官方邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 是否激活，1=合作中，0=终止合作（停用后无法创建新采购订单）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 供应商描述，说明供应商的主营产品、合作历史等
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：该供应商的所有采购订单
        /// </summary>
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }

    /// <summary>
    /// 采购订单实体类，对应数据库中的PurchaseOrder表
    /// 记录向供应商采购物料的订单主信息
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// 订单ID，自增主键
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 订单编号，唯一标识，如"PO20231001001"
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 供应商ID，关联Supplier表的SupplierID，标识向哪个供应商采购
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// 订单日期，创建采购订单的日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 预计到货日期，供应商承诺的交货日期，可为空
        /// </summary>
        public DateTime? ExpectedDate { get; set; }

        /// <summary>
        /// 订单总金额，所有明细金额的总和（Quantity * UnitPrice）
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 订单状态，取值范围：'草稿'、'已审核'、'部分入库'、'全部入库'、'取消'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注，记录订单的特殊要求或说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人ID，关联用户表的用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人ID，关联用户表的用户ID，可为空
        /// </summary>
        public int? UpdateUserID { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：对应的供应商信息
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// 导航属性：订单包含的物料明细集合
        /// </summary>
        public List<PurchaseOrderDetail> Details { get; set; }
    }

    /// <summary>
    /// 采购订单明细实体类，对应数据库中的PurchaseOrderDetail表
    /// 记录采购订单中具体物料的采购信息
    /// </summary>
    public class PurchaseOrderDetail
    {
        /// <summary>
        /// 明细ID，自增主键
        /// </summary>
        public int DetailID { get; set; }

        /// <summary>
        /// 订单ID，关联PurchaseOrder表的OrderID，标识所属订单
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 物料ID，关联Material表的MaterialID，标识采购的物料
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 订购数量，计划采购的物料数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单位ID，关联MaterialUnit表的UnitID，采购数量的计量单位
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// 单价，该物料的采购单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 金额，该明细的总金额（Quantity * UnitPrice）
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 已收数量，该物料实际入库的数量（用于跟踪入库进度）
        /// </summary>
        public decimal ReceivedQuantity { get; set; }

        /// <summary>
        /// 备注，记录该物料的特殊采购要求
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属采购订单信息
        /// </summary>
        public PurchaseOrder PurchaseOrder { get; set; }

        /// <summary>
        /// 导航属性：对应的物料信息
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// 导航属性：对应的单位信息
        /// </summary>
        public MaterialUnit Unit { get; set; }
    }
    #endregion

    #region 入库管理模块
    /// <summary>
    /// 入库单实体类，对应数据库中的StockInOrder表
    /// 记录物料入库的主信息，支持多种入库类型
    /// </summary>
    public class StockInOrder
    {
        /// <summary>
        /// 入库单ID，自增主键
        /// </summary>
        public int InOrderID { get; set; }

        /// <summary>
        /// 入库单编号，唯一标识，如"IN20231001001"
        /// </summary>
        public string InOrderNo { get; set; }

        /// <summary>
        /// 来源类型，取值范围：'采购入库'、'生产退料'、'调拨入库'、'退货入库'、'其他'
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// 来源单号，关联对应的源单据编号（如采购订单号），可为空
        /// </summary>
        public string SourceNo { get; set; }

        /// <summary>
        /// 仓库ID，关联Warehouse表的WarehouseID，标识物料入库的仓库
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 入库日期，物料实际入库的日期
        /// </summary>
        public DateTime InDate { get; set; }

        /// <summary>
        /// 总数量，所有入库明细的数量总和
        /// </summary>
        public decimal TotalQuantity { get; set; }

        /// <summary>
        /// 状态，取值范围：'草稿'、'已审核'、'已完成'、'取消'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注，记录入库的特殊情况或说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人ID，关联用户表的用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人ID，关联用户表的用户ID，可为空
        /// </summary>
        public int? UpdateUserID { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：入库的仓库信息
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// 导航属性：入库单包含的物料明细集合
        /// </summary>
        public List<StockInOrderDetail> Details { get; set; }
    }

    /// <summary>
    /// 入库单明细实体类，对应数据库中的StockInOrderDetail表
    /// 记录入库单中具体物料的入库信息
    /// </summary>
    public class StockInOrderDetail
    {
        /// <summary>
        /// 明细ID，自增主键
        /// </summary>
        public int DetailID { get; set; }

        /// <summary>
        /// 入库单ID，关联StockInOrder表的InOrderID，标识所属入库单
        /// </summary>
        public int InOrderID { get; set; }

        /// <summary>
        /// 物料ID，关联Material表的MaterialID，标识入库的物料
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 批次号，物料的生产批次（用于追溯），可为空
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 入库数量，实际入库的物料数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单位ID，关联MaterialUnit表的UnitID，入库数量的计量单位
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// 库位ID，关联StorageLocation表的LocationID，物料存放的具体库位
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// 生产日期，物料的生产时间，可为空
        /// </summary>
        public DateTime? ProductionDate { get; set; }

        /// <summary>
        /// 过期日期，物料的失效时间（根据ExpiryDays计算），可为空
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// 备注，记录该物料入库的特殊情况
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属入库单信息
        /// </summary>
        public StockInOrder StockInOrder { get; set; }

        /// <summary>
        /// 导航属性：对应的物料信息
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// 导航属性：对应的单位信息
        /// </summary>
        public MaterialUnit Unit { get; set; }

        /// <summary>
        /// 导航属性：存放的库位信息
        /// </summary>
        public StorageLocation StorageLocation { get; set; }
    }
    #endregion

    #region 销售管理模块
    /// <summary>
    /// 客户实体类，对应数据库中的Customer表
    /// 存储客户的基本信息，用于销售业务管理
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 客户ID，自增主键
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户编码，唯一标识，如"CS001"
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 客户名称，企业或个人全称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 信用额度，允许客户赊账的最大金额
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// 联系人，客户的对接人姓名
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话，客户联系人的联系方式
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 地址，客户的收货地址或办公地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电子邮箱，客户的联系邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 是否激活，1=合作中，0=终止合作（停用后无法创建新销售订单）
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 客户描述，说明客户的业务范围、合作历史等
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：该客户的所有销售订单
        /// </summary>
        public List<SalesOrder> SalesOrders { get; set; }
    }

    /// <summary>
    /// 销售订单实体类，对应数据库中的SalesOrder表
    /// 记录向客户销售物料的订单主信息
    /// </summary>
    public class SalesOrder
    {
        /// <summary>
        /// 订单ID，自增主键
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 订单编号，唯一标识，如"SO20231001001"
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 客户ID，关联Customer表的CustomerID，标识向哪个客户销售
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 订单日期，创建销售订单的日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 预计发货日期，承诺给客户的交货日期，可为空
        /// </summary>
        public DateTime? ExpectedDate { get; set; }

        /// <summary>
        /// 订单总金额，所有明细金额的总和（Quantity * UnitPrice）
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 订单状态，取值范围：'草稿'、'已审核'、'部分出库'、'全部出库'、'取消'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注，记录订单的特殊要求或说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人ID，关联用户表的用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人ID，关联用户表的用户ID，可为空
        /// </summary>
        public int? UpdateUserID { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：对应的客户信息
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// 导航属性：订单包含的物料明细集合
        /// </summary>
        public List<SalesOrderDetail> Details { get; set; }
    }

    /// <summary>
    /// 销售订单明细实体类，对应数据库中的SalesOrderDetail表
    /// 记录销售订单中具体物料的销售信息
    /// </summary>
    public class SalesOrderDetail
    {
        /// <summary>
        /// 明细ID，自增主键
        /// </summary>
        public int DetailID { get; set; }

        /// <summary>
        /// 订单ID，关联SalesOrder表的OrderID，标识所属订单
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 物料ID，关联Material表的MaterialID，标识销售的物料
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 销售数量，客户订购的物料数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单位ID，关联MaterialUnit表的UnitID，销售数量的计量单位
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// 单价，该物料的销售单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 金额，该明细的总金额（Quantity * UnitPrice）
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 已发数量，该物料实际出库的数量（用于跟踪出库进度）
        /// </summary>
        public decimal ShippedQuantity { get; set; }

        /// <summary>
        /// 备注，记录该物料的特殊销售要求
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属销售订单信息
        /// </summary>
        public SalesOrder SalesOrder { get; set; }

        /// <summary>
        /// 导航属性：对应的物料信息
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// 导航属性：对应的单位信息
        /// </summary>
        public MaterialUnit Unit { get; set; }
    }
    #endregion

    #region 出库管理模块
    /// <summary>
    /// 出库单实体类，对应数据库中的StockOutOrder表
    /// 记录物料出库的主信息，支持多种出库类型
    /// </summary>
    public class StockOutOrder
    {
        /// <summary>
        /// 出库单ID，自增主键
        /// </summary>
        public int OutOrderID { get; set; }

        /// <summary>
        /// 出库单编号，唯一标识，如"OUT20231001001"
        /// </summary>
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 来源类型，取值范围：'销售出库'、'生产领料'、'调拨出库'、'报废出库'、'其他'
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// 来源单号，关联对应的源单据编号（如销售订单号），可为空
        /// </summary>
        public string SourceNo { get; set; }

        /// <summary>
        /// 仓库ID，关联Warehouse表的WarehouseID，标识物料出库的仓库
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 出库日期，物料实际出库的日期
        /// </summary>
        public DateTime OutDate { get; set; }

        /// <summary>
        /// 总数量，所有出库明细的数量总和
        /// </summary>
        public decimal TotalQuantity { get; set; }

        /// <summary>
        /// 状态，取值范围：'草稿'、'已审核'、'已完成'、'取消'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注，记录出库的特殊情况或说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人ID，关联用户表的用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人ID，关联用户表的用户ID，可为空
        /// </summary>
        public int? UpdateUserID { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：出库的仓库信息
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// 导航属性：出库单包含的物料明细集合
        /// </summary>
        public List<StockOutOrderDetail> Details { get; set; }
    }

    /// <summary>
    /// 出库单明细实体类，对应数据库中的StockOutOrderDetail表
    /// 记录出库单中具体物料的出库信息
    /// </summary>
    public class StockOutOrderDetail
    {
        /// <summary>
        /// 明细ID，自增主键
        /// </summary>
        public int DetailID { get; set; }

        /// <summary>
        /// 出库单ID，关联StockOutOrder表的OutOrderID，标识所属出库单
        /// </summary>
        public int OutOrderID { get; set; }

        /// <summary>
        /// 物料ID，关联Material表的MaterialID，标识出库的物料
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 批次号，物料的出库批次（用于追溯），可为空
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 出库数量，实际出库的物料数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单位ID，关联MaterialUnit表的UnitID，出库数量的计量单位
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// 库位ID，关联StorageLocation表的LocationID，物料取出的具体库位
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// 备注，记录该物料出库的特殊情况
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属出库单信息
        /// </summary>
        public StockOutOrder StockOutOrder { get; set; }

        /// <summary>
        /// 导航属性：对应的物料信息
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// 导航属性：对应的单位信息
        /// </summary>
        public MaterialUnit Unit { get; set; }

        /// <summary>
        /// 导航属性：取出的库位信息
        /// </summary>
        public StorageLocation StorageLocation { get; set; }
    }
    #endregion

    #region 调拨与库存调整模块
    /// <summary>
    /// 调拨单实体类，对应数据库中的TransferOrder表
    /// 记录物料在不同仓库间调拨的主信息
    /// </summary>
    public class TransferOrder
    {
        /// <summary>
        /// 调拨单ID，自增主键
        /// </summary>
        public int TransferID { get; set; }

        /// <summary>
        /// 调拨单编号，唯一标识，如"TF20231001001"
        /// </summary>
        public string TransferNo { get; set; }

        /// <summary>
        /// 源仓库ID，关联Warehouse表的WarehouseID，物料调出的仓库
        /// </summary>
        public int FromWarehouseID { get; set; }

        /// <summary>
        /// 目标仓库ID，关联Warehouse表的WarehouseID，物料调入的仓库
        /// </summary>
        public int ToWarehouseID { get; set; }

        /// <summary>
        /// 调拨日期，创建调拨单的日期
        /// </summary>
        public DateTime TransferDate { get; set; }

        /// <summary>
        /// 状态，取值范围：'草稿'、'已审核'、'已调出'、'已调入'、'取消'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注，记录调拨的原因或特殊要求
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人ID，关联用户表的用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人ID，关联用户表的用户ID，可为空
        /// </summary>
        public int? UpdateUserID { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：源仓库信息
        /// </summary>
        public Warehouse FromWarehouse { get; set; }

        /// <summary>
        /// 导航属性：目标仓库信息
        /// </summary>
        public Warehouse ToWarehouse { get; set; }

        /// <summary>
        /// 导航属性：调拨单包含的物料明细集合
        /// </summary>
        public List<TransferOrderDetail> Details { get; set; }
    }

    /// <summary>
    /// 调拨单明细实体类，对应数据库中的TransferOrderDetail表
    /// 记录调拨单中具体物料的调拨信息
    /// </summary>
    public class TransferOrderDetail
    {
        /// <summary>
        /// 明细ID，自增主键
        /// </summary>
        public int DetailID { get; set; }

        /// <summary>
        /// 调拨单ID，关联TransferOrder表的TransferID，标识所属调拨单
        /// </summary>
        public int TransferID { get; set; }

        /// <summary>
        /// 物料ID，关联Material表的MaterialID，标识调拨的物料
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 批次号，物料的调拨批次（用于追溯），可为空
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 调拨数量，需要调拨的物料数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单位ID，关联MaterialUnit表的UnitID，调拨数量的计量单位
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// 源库位ID，关联StorageLocation表的LocationID，物料调出的库位
        /// </summary>
        public int FromLocationID { get; set; }

        /// <summary>
        /// 目标库位ID，关联StorageLocation表的LocationID，物料调入的库位
        /// </summary>
        public int ToLocationID { get; set; }

        /// <summary>
        /// 备注，记录该物料调拨的特殊情况
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属调拨单信息
        /// </summary>
        public TransferOrder TransferOrder { get; set; }

        /// <summary>
        /// 导航属性：对应的物料信息
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// 导航属性：对应的单位信息
        /// </summary>
        public MaterialUnit Unit { get; set; }

        /// <summary>
        /// 导航属性：调出的库位信息
        /// </summary>
        public StorageLocation FromLocation { get; set; }

        /// <summary>
        /// 导航属性：调入的库位信息
        /// </summary>
        public StorageLocation ToLocation { get; set; }
    }

    /// <summary>
    /// 库存调整单实体类，对应数据库中的InventoryAdjustment表
    /// 记录库存数量调整的主信息（如盘盈、盘亏）
    /// </summary>
    public class InventoryAdjustment
    {
        /// <summary>
        /// 调整单ID，自增主键
        /// </summary>
        public int AdjustmentID { get; set; }

        /// <summary>
        /// 调整单编号，唯一标识，如"ADJ20231001001"
        /// </summary>
        public string AdjustmentNo { get; set; }

        /// <summary>
        /// 仓库ID，关联Warehouse表的WarehouseID，需要调整库存的仓库
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 调整日期，进行库存调整的日期
        /// </summary>
        public DateTime AdjustmentDate { get; set; }

        /// <summary>
        /// 调整类型，取值范围：'盘盈'、'盘亏'、'冻结'、'解冻'
        /// </summary>
        public string AdjustmentType { get; set; }

        /// <summary>
        /// 状态，取值范围：'草稿'、'已审核'、'已完成'、'取消'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 备注，记录调整的原因或依据（如盘点报告编号）
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人ID，关联用户表的用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 记录创建时间，自动生成
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人ID，关联用户表的用户ID，可为空
        /// </summary>
        public int? UpdateUserID { get; set; }

        /// <summary>
        /// 记录最后更新时间，每次修改自动更新
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 导航属性：所属仓库信息
        /// </summary>
        public Warehouse Warehouse { get; set; }
    }
    #endregion
}

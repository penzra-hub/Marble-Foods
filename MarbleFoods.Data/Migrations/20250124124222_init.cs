using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarbleFoods.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarbleFoodsAlert",
                columns: table => new
                {
                    AlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelatedEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelatedEntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsAlert", x => x.AlertId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsAuditLog",
                columns: table => new
                {
                    AuditLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsAuditLog", x => x.AuditLogId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsCommodity",
                columns: table => new
                {
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MinimumStockLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumStockLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiresQualityCheck = table.Column<bool>(type: "bit", nullable: false),
                    IsPerishable = table.Column<bool>(type: "bit", nullable: false),
                    ShelfLifeDays = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsCommodity", x => x.CommodityId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsQualityParameter",
                columns: table => new
                {
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsQualityParameter", x => x.ParameterId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsSupplier",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsSupplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiresMFA = table.Column<bool>(type: "bit", nullable: false),
                    UserRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsWarehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsWarehouse", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsCommodityMarbleFoodsQualityParameter",
                columns: table => new
                {
                    CommoditiesCommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualityParametersParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsCommodityMarbleFoodsQualityParameter", x => new { x.CommoditiesCommodityId, x.QualityParametersParameterId });
                    table.ForeignKey(
                        name: "FK_MarbleFoodsCommodityMarbleFoodsQualityParameter_MarbleFoodsCommodity_CommoditiesCommodityId",
                        column: x => x.CommoditiesCommodityId,
                        principalTable: "MarbleFoodsCommodity",
                        principalColumn: "CommodityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsCommodityMarbleFoodsQualityParameter_MarbleFoodsQualityParameter_QualityParametersParameterId",
                        column: x => x.QualityParametersParameterId,
                        principalTable: "MarbleFoodsQualityParameter",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsPurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseStatus = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsPurchaseOrder", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsPurchaseOrder_MarbleFoodsSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "MarbleFoodsSupplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsUserMfaBackupCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsedFromIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    MarbleFoodsUserUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsUserMfaBackupCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsUserMfaBackupCode_MarbleFoodsUser_MarbleFoodsUserUserId",
                        column: x => x.MarbleFoodsUserUserId,
                        principalTable: "MarbleFoodsUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceIdentifier = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUsedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice_MarbleFoodsUser_UserId",
                        column: x => x.UserId,
                        principalTable: "MarbleFoodsUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsInventoryBatch",
                columns: table => new
                {
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StorageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsInventoryBatch", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsInventoryBatch_MarbleFoodsCommodity_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "MarbleFoodsCommodity",
                        principalColumn: "CommodityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsInventoryBatch_MarbleFoodsWarehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "MarbleFoodsWarehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsPurchaseOrderItem",
                columns: table => new
                {
                    PurchaseOrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsPurchaseOrderItem", x => x.PurchaseOrderItemId);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsPurchaseOrderItem_MarbleFoodsPurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "MarbleFoodsPurchaseOrder",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsInventoryTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsInventoryTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsInventoryTransaction_MarbleFoodsInventoryBatch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "MarbleFoodsInventoryBatch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsInventoryTransaction_MarbleFoodsUser_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "MarbleFoodsUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsInventoryTransaction_MarbleFoodsWarehouse_DestinationWarehouseId",
                        column: x => x.DestinationWarehouseId,
                        principalTable: "MarbleFoodsWarehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsInventoryTransaction_MarbleFoodsWarehouse_SourceWarehouseId",
                        column: x => x.SourceWarehouseId,
                        principalTable: "MarbleFoodsWarehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsQualityCheck",
                columns: table => new
                {
                    QualityCheckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QualityStatus = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsQualityCheck", x => x.QualityCheckId);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsQualityCheck_MarbleFoodsInventoryBatch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "MarbleFoodsInventoryBatch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsQualityCheck_MarbleFoodsUser_PerformedByUserId",
                        column: x => x.PerformedByUserId,
                        principalTable: "MarbleFoodsUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarbleFoodsQualityCheckResult",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualityCheckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassedCheck = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarbleFoodsQualityCheckResult", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_MarbleFoodsQualityCheckResult_MarbleFoodsQualityCheck_QualityCheckId",
                        column: x => x.QualityCheckId,
                        principalTable: "MarbleFoodsQualityCheck",
                        principalColumn: "QualityCheckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsAuditLog_EntityName",
                table: "MarbleFoodsAuditLog",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsAuditLog_Timestamp",
                table: "MarbleFoodsAuditLog",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsCommodityMarbleFoodsQualityParameter_QualityParametersParameterId",
                table: "MarbleFoodsCommodityMarbleFoodsQualityParameter",
                column: "QualityParametersParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsInventoryBatch_CommodityId",
                table: "MarbleFoodsInventoryBatch",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsInventoryBatch_WarehouseId",
                table: "MarbleFoodsInventoryBatch",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsInventoryTransaction_BatchId",
                table: "MarbleFoodsInventoryTransaction",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsInventoryTransaction_CreatedByUserId",
                table: "MarbleFoodsInventoryTransaction",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsInventoryTransaction_DestinationWarehouseId",
                table: "MarbleFoodsInventoryTransaction",
                column: "DestinationWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsInventoryTransaction_SourceWarehouseId",
                table: "MarbleFoodsInventoryTransaction",
                column: "SourceWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsPurchaseOrder_SupplierId",
                table: "MarbleFoodsPurchaseOrder",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsPurchaseOrderItem_PurchaseOrderId",
                table: "MarbleFoodsPurchaseOrderItem",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsQualityCheck_BatchId",
                table: "MarbleFoodsQualityCheck",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsQualityCheck_PerformedByUserId",
                table: "MarbleFoodsQualityCheck",
                column: "PerformedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsQualityCheckResult_QualityCheckId",
                table: "MarbleFoodsQualityCheckResult",
                column: "QualityCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsUserMfaBackupCode_MarbleFoodsUserUserId",
                table: "MarbleFoodsUserMfaBackupCode",
                column: "MarbleFoodsUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice_ExpiresAt",
                table: "MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice_UserId_DeviceIdentifier",
                table: "MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice",
                columns: new[] { "UserId", "DeviceIdentifier" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarbleFoodsAlert");

            migrationBuilder.DropTable(
                name: "MarbleFoodsAuditLog");

            migrationBuilder.DropTable(
                name: "MarbleFoodsCommodityMarbleFoodsQualityParameter");

            migrationBuilder.DropTable(
                name: "MarbleFoodsInventoryTransaction");

            migrationBuilder.DropTable(
                name: "MarbleFoodsPurchaseOrderItem");

            migrationBuilder.DropTable(
                name: "MarbleFoodsQualityCheckResult");

            migrationBuilder.DropTable(
                name: "MarbleFoodsRoles");

            migrationBuilder.DropTable(
                name: "MarbleFoodsUserMfaBackupCode");

            migrationBuilder.DropTable(
                name: "MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice");

            migrationBuilder.DropTable(
                name: "MarbleFoodsQualityParameter");

            migrationBuilder.DropTable(
                name: "MarbleFoodsPurchaseOrder");

            migrationBuilder.DropTable(
                name: "MarbleFoodsQualityCheck");

            migrationBuilder.DropTable(
                name: "MarbleFoodsSupplier");

            migrationBuilder.DropTable(
                name: "MarbleFoodsInventoryBatch");

            migrationBuilder.DropTable(
                name: "MarbleFoodsUser");

            migrationBuilder.DropTable(
                name: "MarbleFoodsCommodity");

            migrationBuilder.DropTable(
                name: "MarbleFoodsWarehouse");
        }
    }
}

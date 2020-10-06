using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    ArchetypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MaximumJobLevel = table.Column<int>(nullable: false),
                    MinimumJobLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.ArchetypeId);
                });

            migrationBuilder.CreateTable(
                name: "ArmorPieceCategory",
                columns: table => new
                {
                    ArmorPieceCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorPieceCategory", x => x.ArmorPieceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BaseLevels",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpRequired = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseLevels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Characteristic",
                columns: table => new
                {
                    CharacteristicId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacteristicCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristic", x => x.CharacteristicId);
                });

            migrationBuilder.CreateTable(
                name: "JobLevels",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpRequired = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    MapId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapId);
                });

            migrationBuilder.CreateTable(
                name: "QuestGroups",
                columns: table => new
                {
                    QuestGroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinimumLevel = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestGroups", x => x.QuestGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TargetRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Capacity = table.Column<int>(nullable: false),
                    Money = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    RequiredLevel = table.Column<int>(nullable: true),
                    Equipment_RequiredLevel = table.Column<int>(nullable: true),
                    ArmorPieceCategoryId = table.Column<int>(nullable: true),
                    Range = table.Column<int>(nullable: true),
                    SingleHand = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_ArmorPieceCategory_ArmorPieceCategoryId",
                        column: x => x.ArmorPieceCategoryId,
                        principalTable: "ArmorPieceCategory",
                        principalColumn: "ArmorPieceCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QuestId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequiredLevel = table.Column<int>(nullable: false),
                    QuestMoney = table.Column<int>(nullable: true),
                    MinimumLevel = table.Column<int>(nullable: false),
                    QuestGroupId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_Quests_QuestGroups_QuestGroupId",
                        column: x => x.QuestGroupId,
                        principalTable: "QuestGroups",
                        principalColumn: "QuestGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchetypeSkills",
                columns: table => new
                {
                    ArchetypeId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchetypeSkills", x => new { x.ArchetypeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ArchetypeSkills_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "ArchetypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchetypeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    SpCost = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    Cooldown = table.Column<float>(nullable: false),
                    EffectValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => new { x.SkillId, x.Level });
                    table.ForeignKey(
                        name: "FK_SkillLevels_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    StorageId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Banned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsummableCharacteristic",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    CharacteristicId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Duration = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsummableCharacteristic", x => new { x.ItemId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_ConsummableCharacteristic_Characteristic_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristic",
                        principalColumn: "CharacteristicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsummableCharacteristic_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCharacteristic",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    CharacteristicId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCharacteristic", x => new { x.ItemId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_EquipmentCharacteristic_Characteristic_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristic",
                        principalColumn: "CharacteristicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentCharacteristic_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemInstance",
                columns: table => new
                {
                    ItemInstanceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: true),
                    Index = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UpgradeLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstance", x => x.ItemInstanceId);
                    table.ForeignKey(
                        name: "FK_ItemInstance_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInstance_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollectionQuestItem",
                columns: table => new
                {
                    QuestId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionQuestItem", x => new { x.QuestId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CollectionQuestItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionQuestItem_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "QuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestItems",
                columns: table => new
                {
                    QuestId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestItems", x => new { x.QuestId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_QuestItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestItems_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "QuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creatures",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    BaseLevelId = table.Column<int>(nullable: false),
                    HP = table.Column<int>(nullable: false),
                    SP = table.Column<int>(nullable: false),
                    AGI = table.Column<int>(nullable: false),
                    INT = table.Column<int>(nullable: false),
                    DEX = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    VIT = table.Column<int>(nullable: false),
                    LUK = table.Column<int>(nullable: false),
                    ATK = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    MATK = table.Column<int>(nullable: false),
                    ASPD = table.Column<double>(nullable: false),
                    MSPD = table.Column<double>(nullable: false),
                    HIT = table.Column<int>(nullable: false),
                    FLEE = table.Column<int>(nullable: false),
                    CRIT = table.Column<int>(nullable: false),
                    ArchetypeId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    MapId = table.Column<int>(nullable: true),
                    PositionX = table.Column<int>(nullable: true),
                    PositionY = table.Column<int>(nullable: true),
                    JobLevelId = table.Column<int>(nullable: true),
                    StatusPoints = table.Column<int>(nullable: true),
                    SkillPoints = table.Column<int>(nullable: true),
                    StorageId = table.Column<int>(nullable: true),
                    AccountId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LatestConnectionDate = table.Column<DateTime>(nullable: true),
                    MonsterId = table.Column<int>(nullable: true),
                    BaseExp = table.Column<int>(nullable: true),
                    JobExp = table.Column<int>(nullable: true),
                    Aggressive = table.Column<bool>(nullable: true),
                    CanMove = table.Column<bool>(nullable: true),
                    Range = table.Column<double>(nullable: true),
                    Looter = table.Column<bool>(nullable: true),
                    InitialX = table.Column<int>(nullable: true),
                    InitialY = table.Column<int>(nullable: true),
                    NPC_CanMove = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creatures", x => x.CreatureId);
                    table.ForeignKey(
                        name: "FK_Creatures_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_BaseLevels_BaseLevelId",
                        column: x => x.BaseLevelId,
                        principalTable: "BaseLevels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_JobLevels_JobLevelId",
                        column: x => x.JobLevelId,
                        principalTable: "JobLevels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "MapId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "ArchetypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_Map_MapId1",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "MapId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HuntingQuestMonster",
                columns: table => new
                {
                    QuestId = table.Column<int>(nullable: false),
                    MonsterId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingQuestMonster", x => new { x.QuestId, x.MonsterId });
                    table.ForeignKey(
                        name: "FK_HuntingQuestMonster_Creatures_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creatures",
                        principalColumn: "CreatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HuntingQuestMonster_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "QuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterItems",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterItems", x => new { x.CreatureId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_MonsterItems_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "CreatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StorageId",
                table: "Accounts",
                column: "StorageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypeSkills_SkillId",
                table: "ArchetypeSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristic_CharacteristicCode",
                table: "Characteristic",
                column: "CharacteristicCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionQuestItem_ItemId",
                table: "CollectionQuestItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsummableCharacteristic_CharacteristicId",
                table: "ConsummableCharacteristic",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_AccountId",
                table: "Creatures",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_BaseLevelId",
                table: "Creatures",
                column: "BaseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_JobLevelId",
                table: "Creatures",
                column: "JobLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_MapId",
                table: "Creatures",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_Name",
                table: "Creatures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_StorageId",
                table: "Creatures",
                column: "StorageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_ArchetypeId",
                table: "Creatures",
                column: "ArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_MonsterId",
                table: "Creatures",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_MapId1",
                table: "Creatures",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCharacteristic_CharacteristicId",
                table: "EquipmentCharacteristic",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_HuntingQuestMonster_MonsterId",
                table: "HuntingQuestMonster",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstance_ItemId",
                table: "ItemInstance",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstance_StorageId",
                table: "ItemInstance",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ArmorPieceCategoryId",
                table: "Items",
                column: "ArmorPieceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterItems_ItemId",
                table: "MonsterItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestItems_ItemId",
                table: "QuestItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_QuestGroupId",
                table: "Quests",
                column: "QuestGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchetypeSkills");

            migrationBuilder.DropTable(
                name: "CollectionQuestItem");

            migrationBuilder.DropTable(
                name: "ConsummableCharacteristic");

            migrationBuilder.DropTable(
                name: "EquipmentCharacteristic");

            migrationBuilder.DropTable(
                name: "HuntingQuestMonster");

            migrationBuilder.DropTable(
                name: "ItemInstance");

            migrationBuilder.DropTable(
                name: "MonsterItems");

            migrationBuilder.DropTable(
                name: "QuestItems");

            migrationBuilder.DropTable(
                name: "SkillLevels");

            migrationBuilder.DropTable(
                name: "Characteristic");

            migrationBuilder.DropTable(
                name: "Creatures");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BaseLevels");

            migrationBuilder.DropTable(
                name: "JobLevels");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DropTable(
                name: "ArmorPieceCategory");

            migrationBuilder.DropTable(
                name: "QuestGroups");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}

﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EchoServer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("DataAccessLayer.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Banned")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("StorageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("StorageId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Archetype", b =>
                {
                    b.Property<int>("ArchetypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaximumJobLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimumJobLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ArchetypeId");

                    b.ToTable("Archetypes");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ArchetypeSkill", b =>
                {
                    b.Property<int>("ArchetypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArchetypeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ArchetypeSkills");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ArmorPieceCategory", b =>
                {
                    b.Property<int>("ArmorPieceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .HasColumnType("TEXT");

                    b.HasKey("ArmorPieceCategoryId");

                    b.ToTable("ArmorPieceCategory");
                });

            modelBuilder.Entity("DataAccessLayer.Models.BaseLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpRequired")
                        .HasColumnType("INTEGER");

                    b.HasKey("LevelId");

                    b.ToTable("BaseLevels");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Characteristic", b =>
                {
                    b.Property<int>("CharacteristicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharacteristicCode")
                        .HasColumnType("TEXT");

                    b.HasKey("CharacteristicId");

                    b.HasIndex("CharacteristicCode")
                        .IsUnique();

                    b.ToTable("Characteristic");
                });

            modelBuilder.Entity("DataAccessLayer.Models.CollectionQuestItem", b =>
                {
                    b.Property<int>("QuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("CollectionQuestItem");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ConsummableCharacteristic", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacteristicId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("ItemId", "CharacteristicId");

                    b.HasIndex("CharacteristicId");

                    b.ToTable("ConsummableCharacteristic");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Creature", b =>
                {
                    b.Property<int>("CreatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AGI")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ASPD")
                        .HasColumnType("REAL");

                    b.Property<int>("ATK")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArchetypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CRIT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DEF")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DEX")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FLEE")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HIT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("INT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LUK")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MATK")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MSPD")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("STR")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VIT")
                        .HasColumnType("INTEGER");

                    b.HasKey("CreatureId");

                    b.HasIndex("ArchetypeId");

                    b.ToTable("Creatures");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Creature");
                });

            modelBuilder.Entity("DataAccessLayer.Models.EquipmentCharacteristic", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacteristicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId", "CharacteristicId");

                    b.HasIndex("CharacteristicId");

                    b.ToTable("EquipmentCharacteristic");
                });

            modelBuilder.Entity("DataAccessLayer.Models.HuntingQuestMonster", b =>
                {
                    b.Property<int>("QuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonsterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestId", "MonsterId");

                    b.HasIndex("MonsterId");

                    b.ToTable("HuntingQuestMonster");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ItemInstance", b =>
                {
                    b.Property<int>("ItemInstanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StorageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UpgradeLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemInstanceId");

                    b.HasIndex("ItemId");

                    b.HasIndex("StorageId");

                    b.ToTable("ItemInstance");
                });

            modelBuilder.Entity("DataAccessLayer.Models.JobLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpRequired")
                        .HasColumnType("INTEGER");

                    b.HasKey("LevelId");

                    b.ToTable("JobLevels");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Map", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("MapId");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("DataAccessLayer.Models.MonsterItem", b =>
                {
                    b.Property<int>("CreatureId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.HasKey("CreatureId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("MonsterItems");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Quest", b =>
                {
                    b.Property<int>("QuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MinimumLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuestMoney")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestId");

                    b.HasIndex("QuestGroupId");

                    b.ToTable("Quests");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Quest");
                });

            modelBuilder.Entity("DataAccessLayer.Models.QuestGroup", b =>
                {
                    b.Property<int>("QuestGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimumLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("QuestGroupId");

                    b.ToTable("QuestGroups");
                });

            modelBuilder.Entity("DataAccessLayer.Models.QuestItem", b =>
                {
                    b.Property<int>("QuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("QuestItems");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TargetRequired")
                        .HasColumnType("INTEGER");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DataAccessLayer.Models.SkillLevel", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Cooldown")
                        .HasColumnType("REAL");

                    b.Property<int>("EffectValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Range")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpCost")
                        .HasColumnType("INTEGER");

                    b.HasKey("SkillId", "Level");

                    b.ToTable("SkillLevels");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Storage", b =>
                {
                    b.Property<int>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Money")
                        .HasColumnType("INTEGER");

                    b.HasKey("StorageId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Character", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Creature");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LatestConnectionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MapId")
                        .HasColumnName("MapId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StorageId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AccountId");

                    b.HasIndex("BaseLevelId");

                    b.HasIndex("JobLevelId");

                    b.HasIndex("MapId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StorageId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Character");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Monster", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Creature");

                    b.Property<bool>("Aggressive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseExp")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanMove")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobExp")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Looter")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonsterId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Range")
                        .HasColumnType("REAL");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Monster");
                });

            modelBuilder.Entity("DataAccessLayer.Models.NPC", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Creature");

                    b.Property<int>("CanMove")
                        .HasColumnName("NPC_CanMove")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InitialX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InitialY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapId")
                        .HasColumnName("MapId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MapId")
                        .HasName("IX_Creatures_MapId1");

                    b.HasDiscriminator().HasValue("NPC");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Consummable", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Item");

                    b.Property<int>("RequiredLevel")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Consummable");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Equipment", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Item");

                    b.Property<int>("RequiredLevel")
                        .HasColumnName("Equipment_RequiredLevel")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Equipment");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Miscellaneous", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Item");

                    b.HasDiscriminator().HasValue("Miscellaneous");
                });

            modelBuilder.Entity("DataAccessLayer.Models.CollectionQuest", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Quest");

                    b.HasDiscriminator().HasValue("CollectionQuest");
                });

            modelBuilder.Entity("DataAccessLayer.Models.HuntingQuest", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Quest");

                    b.HasDiscriminator().HasValue("HuntingQuest");
                });

            modelBuilder.Entity("DataAccessLayer.Models.ArmorPiece", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Equipment");

                    b.Property<int>("ArmorPieceCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ArmorPieceCategoryId");

                    b.HasDiscriminator().HasValue("ArmorPiece");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Weapon", b =>
                {
                    b.HasBaseType("DataAccessLayer.Models.Equipment");

                    b.Property<int>("Range")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SingleHand")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Account", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Storage", "Storage")
                        .WithOne("Account")
                        .HasForeignKey("DataAccessLayer.Models.Account", "StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ArchetypeSkill", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Archetype", "Archetype")
                        .WithMany("ArchetypeSkills")
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Skill", "Skill")
                        .WithMany("ArchetypeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.CollectionQuestItem", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Item", "Item")
                        .WithMany("CollectionQuestItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.CollectionQuest", "CollectionQuest")
                        .WithMany("CollectionQuestItems")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ConsummableCharacteristic", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Characteristic", "Characteristic")
                        .WithMany("ConsummableCharacteristics")
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Consummable", "Consummable")
                        .WithMany("ConsummableCharacteristics")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Creature", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Archetype", "Archetype")
                        .WithMany("Creatures")
                        .HasForeignKey("ArchetypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.EquipmentCharacteristic", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Characteristic", "Characteristic")
                        .WithMany("EquipmentCharacteristics")
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Equipment", "Equipment")
                        .WithMany("EquipmentCharacteristics")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.HuntingQuestMonster", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Monster", "Monster")
                        .WithMany("HuntingQuestMonsters")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.HuntingQuest", "HuntingQuest")
                        .WithMany("HuntingQuestMonsters")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ItemInstance", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Item", "Item")
                        .WithMany("ItemInstances")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Storage", "Storage")
                        .WithMany("ItemInstances")
                        .HasForeignKey("StorageId");
                });

            modelBuilder.Entity("DataAccessLayer.Models.MonsterItem", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Monster", "Monster")
                        .WithMany("MonsterItems")
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Item", "Item")
                        .WithMany("MonsterItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Quest", b =>
                {
                    b.HasOne("DataAccessLayer.Models.QuestGroup", "QuestGroup")
                        .WithMany("Quests")
                        .HasForeignKey("QuestGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.QuestItem", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Item", "Item")
                        .WithMany("QuestItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Quest", "Quest")
                        .WithMany("QuestItems")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.SkillLevel", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Skill", "Skill")
                        .WithMany("SkillLevels")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Character", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.BaseLevel", "BaseLevel")
                        .WithMany("Characters")
                        .HasForeignKey("BaseLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.JobLevel", "JobLevel")
                        .WithMany("Characters")
                        .HasForeignKey("JobLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Map", "Map")
                        .WithMany("Characters")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Storage", "Storage")
                        .WithOne("Character")
                        .HasForeignKey("DataAccessLayer.Models.Character", "StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.NPC", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Map", "Map")
                        .WithMany("NPCs")
                        .HasForeignKey("MapId")
                        .HasConstraintName("FK_Creatures_Map_MapId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.ArmorPiece", b =>
                {
                    b.HasOne("DataAccessLayer.Models.ArmorPieceCategory", "ArmorPieceCategory")
                        .WithMany("ArmorPieces")
                        .HasForeignKey("ArmorPieceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

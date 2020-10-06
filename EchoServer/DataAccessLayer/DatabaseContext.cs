
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ArchetypeSkill> ArchetypeSkills { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<MonsterItem> MonsterItems { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestItem> QuestItems { get; set; }
        public DbSet<QuestGroup> QuestGroups { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<BaseLevel> BaseLevels { get; set; }
        public DbSet<JobLevel> JobLevels { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Account> accounts = modelBuilder.Entity<Account>();
            EntityTypeBuilder<Creature> creatures = modelBuilder.Entity<Creature>();
            EntityTypeBuilder<Character> characters = modelBuilder.Entity<Character>();
            EntityTypeBuilder<Monster> monsters = modelBuilder.Entity<Monster>();
            EntityTypeBuilder<MonsterItem> monsterItems = modelBuilder.Entity<MonsterItem>();
            EntityTypeBuilder<NPC> npcs = modelBuilder.Entity<NPC>();
            EntityTypeBuilder<BaseLevel> baseLevels = modelBuilder.Entity<BaseLevel>();
            EntityTypeBuilder<JobLevel> jobLevels = modelBuilder.Entity<JobLevel>();
            EntityTypeBuilder<Characteristic> characteristics = modelBuilder.Entity<Characteristic>();

            EntityTypeBuilder<Archetype> archetypes = modelBuilder.Entity<Archetype>();
            EntityTypeBuilder<ArchetypeSkill> archetypeSkills = modelBuilder.Entity<ArchetypeSkill>();
            EntityTypeBuilder<Skill> skills = modelBuilder.Entity<Skill>();
            EntityTypeBuilder<SkillLevel> skillLevels = modelBuilder.Entity<SkillLevel>();

            EntityTypeBuilder<EquipmentCharacteristic> equipmentCharacteristics = modelBuilder.Entity<EquipmentCharacteristic>();
            EntityTypeBuilder<Equipment> equipments = modelBuilder.Entity<Equipment>();
            EntityTypeBuilder<ArmorPieceCategory> armorPieceCategories = modelBuilder.Entity<ArmorPieceCategory>();
            EntityTypeBuilder<Consummable> consummables = modelBuilder.Entity<Consummable>();
            EntityTypeBuilder<ConsummableCharacteristic> consummableCharacteristics = modelBuilder.Entity<ConsummableCharacteristic>();
            EntityTypeBuilder<Item> items = modelBuilder.Entity<Item>();
            EntityTypeBuilder<Storage> storages = modelBuilder.Entity<Storage>();
            EntityTypeBuilder<ItemInstance> itemInstances = modelBuilder.Entity<ItemInstance>();
            EntityTypeBuilder<Weapon> weapons = modelBuilder.Entity<Weapon>();
            EntityTypeBuilder<ArmorPiece> armorPieces = modelBuilder.Entity<ArmorPiece>();
            EntityTypeBuilder<Miscellaneous> miscellaneous = modelBuilder.Entity<Miscellaneous>();

            EntityTypeBuilder<Quest> quests = modelBuilder.Entity<Quest>();
            EntityTypeBuilder<QuestItem> questItems = modelBuilder.Entity<QuestItem>();
            EntityTypeBuilder<HuntingQuest> huntingQuests = modelBuilder.Entity<HuntingQuest>();
            EntityTypeBuilder<HuntingQuestMonster> huntingQuestMonsters = modelBuilder.Entity<HuntingQuestMonster>();
            EntityTypeBuilder<CollectionQuest> collectionQuests = modelBuilder.Entity<CollectionQuest>();
            EntityTypeBuilder<CollectionQuestItem> collectionQuestItems = modelBuilder.Entity<CollectionQuestItem>();
            EntityTypeBuilder<QuestGroup> questGroups = modelBuilder.Entity<QuestGroup>();

            // PRIMARY KEYS
            accounts.HasKey(account => account.AccountId);
            creatures.HasKey(creature => creature.CreatureId);
            archetypes.HasKey(archetype => archetype.ArchetypeId);
            skills.HasKey(skill => skill.SkillId);
            skillLevels.HasKey(skillLevel => new {skillLevel.SkillId, skillLevel.Level});
            archetypeSkills.HasKey(archetypeSkill => new {archetypeSkill.ArchetypeId, archetypeSkill.SkillId});
            equipmentCharacteristics.HasKey(equipmentCharacteristic => new {equipmentCharacteristic.ItemId, equipmentCharacteristic.CharacteristicId});
            monsterItems.HasKey(monsterItem => new {monsterItem.CreatureId, monsterItem.ItemId});
            armorPieceCategories.HasKey(armorPieceCategory => armorPieceCategory.ArmorPieceCategoryId);
            consummableCharacteristics.HasKey(consummableCharacteristic => new {consummableCharacteristic.ItemId, consummableCharacteristic.CharacteristicId});
            items.HasKey(item => item.ItemId);
            itemInstances.HasKey(itemInstance => itemInstance.ItemInstanceId);
            quests.HasKey(quest => quest.QuestId);
            huntingQuestMonsters.HasKey(huntingQuestMonster => new {huntingQuestMonster.QuestId, huntingQuestMonster.MonsterId});
            collectionQuestItems.HasKey(collectionQuestItem => new {collectionQuestItem.QuestId, collectionQuestItem.ItemId});
            questGroups.HasKey(questGroup => questGroup.QuestGroupId);
            questItems.HasKey(questItem => new {questItem.QuestId, questItem.ItemId});
            baseLevels.HasKey(level => level.LevelId);
            jobLevels.HasKey(level => level.LevelId);
            characteristics.HasKey(characteristic => characteristic.CharacteristicId);

            // INDEXES
            accounts.HasIndex(account => account.Email).IsUnique();
            accounts.HasIndex(account => account.StorageId).IsUnique();
            characters.HasIndex(character => character.Name).IsUnique();
            characters.HasIndex(character => character.StorageId).IsUnique();
            monsters.HasIndex(monster => monster.MonsterId).IsUnique();
            characteristics.HasIndex(characteristic => characteristic.CharacteristicCode).IsUnique();

            // RELATIONAL CONSTRAINTS
            accounts.HasOne(account => account.Storage).WithOne(bank => bank.Account).HasForeignKey<Account>(account => account.StorageId);
            creatures.HasOne(creature => creature.Archetype).WithMany(Archetype => Archetype.Creatures).HasForeignKey(creature => creature.ArchetypeId);
            characters.HasOne(character => character.Account).WithMany(account => account.Characters).HasForeignKey(character => character.AccountId);
            characters.HasOne(character => character.Storage).WithOne(storage => storage.Character).HasForeignKey<Character>(character => character.StorageId);
            characters.HasOne(character =>  character.Map).WithMany(map => map.Characters).HasForeignKey(character => character.MapId);
            characters.HasOne(character => character.BaseLevel).WithMany(baseLevel => baseLevel.Characters).HasForeignKey(character => character.BaseLevelId);
            characters.HasOne(character => character.JobLevel).WithMany(jobLevel => jobLevel.Characters).HasForeignKey(character => character.JobLevelId);

            npcs.HasOne(npc => npc.Map).WithMany(map => map.NPCs).HasForeignKey(npc => npc.MapId);

            monsterItems.HasOne(monsterItem => monsterItem.Monster).WithMany(monster => monster.MonsterItems).HasForeignKey(monsterItem => monsterItem.CreatureId);
            monsterItems.HasOne(monsterItem => monsterItem.Item).WithMany(item => item.MonsterItems).HasForeignKey(monsterItem => monsterItem.ItemId);

            equipmentCharacteristics.HasOne(equipmentCharacteristic => equipmentCharacteristic.Characteristic).WithMany(characteristic => characteristic.EquipmentCharacteristics).HasForeignKey(equipmentCharacteristic => equipmentCharacteristic.CharacteristicId);
            equipmentCharacteristics.HasOne(equipmentCharacteristic => equipmentCharacteristic.Equipment).WithMany(equipment => equipment.EquipmentCharacteristics).HasForeignKey(equipmentCharacteristic => equipmentCharacteristic.ItemId);
            consummableCharacteristics.HasOne(consummableCharacteristic => consummableCharacteristic.Characteristic).WithMany(characteristic => characteristic.ConsummableCharacteristics).HasForeignKey(consummableCharacteristic => consummableCharacteristic.CharacteristicId);
            consummableCharacteristics.HasOne(consummableCharacteristic => consummableCharacteristic.Consummable).WithMany(consummable => consummable.ConsummableCharacteristics).HasForeignKey(consummableCharacteristic => consummableCharacteristic.ItemId);
            itemInstances.HasOne(itemInstance => itemInstance.Item).WithMany(item => item.ItemInstances).HasForeignKey(itemInstance => itemInstance.ItemId);
            itemInstances.HasOne(itemInstance => itemInstance.Storage).WithMany(storage => storage.ItemInstances).HasForeignKey(itemInstance => itemInstance.StorageId);
            armorPieces.HasOne(armorPiece => armorPiece.ArmorPieceCategory).WithMany(armorPieceCategory => armorPieceCategory.ArmorPieces).HasForeignKey(armorPiece => armorPiece.ArmorPieceCategoryId);
            archetypeSkills.HasOne(archetypeSkill => archetypeSkill.Skill).WithMany(skill => skill.ArchetypeSkills).HasForeignKey(archetypeSkill => archetypeSkill.SkillId);
            archetypeSkills.HasOne(archetypeSkill => archetypeSkill.Archetype).WithMany(archetype => archetype.ArchetypeSkills).HasForeignKey(archetypeSkill => archetypeSkill.ArchetypeId);
            skillLevels.HasOne(skillLevel => skillLevel.Skill).WithMany(skill => skill.SkillLevels).HasForeignKey(skillLevel => skillLevel.SkillId);

            collectionQuestItems.HasOne(collectionQuestItem => collectionQuestItem.Item).WithMany(item => item.CollectionQuestItems).HasForeignKey(collectionQuestItem => collectionQuestItem.ItemId);
            collectionQuestItems.HasOne(collectionQuestItem => collectionQuestItem.CollectionQuest).WithMany(collectionQuest => collectionQuest.CollectionQuestItems).HasForeignKey(collectionQuestItem => collectionQuestItem.QuestId);
            huntingQuestMonsters.HasOne(huntingQuestMonster => huntingQuestMonster.Monster).WithMany(monster => monster.HuntingQuestMonsters).HasForeignKey(huntingQuestMonster => huntingQuestMonster.MonsterId);
            huntingQuestMonsters.HasOne(huntingQuestMonster => huntingQuestMonster.HuntingQuest).WithMany(huntingQuest => huntingQuest.HuntingQuestMonsters).HasForeignKey(huntingQuestMonster => huntingQuestMonster.QuestId);
            questItems.HasOne(questItem => questItem.Quest).WithMany(quest => quest.QuestItems).HasForeignKey(questItem => questItem.QuestId);
            questItems.HasOne(questItem => questItem.Item).WithMany(item => item.QuestItems).HasForeignKey(questItem => questItem.ItemId);
            quests.HasOne(quest => quest.QuestGroup).WithMany(questGroup => questGroup.Quests).HasForeignKey(quest => quest.QuestGroupId);

            // FIX DUPLICATE COLUMNS FOR DERIVED TYPES OF HIERARCHY (TPC) 
            characters.Property(character => character.MapId).HasColumnName("MapId");
            npcs.Property(npc => npc.MapId).HasColumnName("MapId");

        }
    }
}
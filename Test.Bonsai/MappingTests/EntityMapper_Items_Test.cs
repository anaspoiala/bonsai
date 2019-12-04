using System;
using System.Collections.Generic;
using Bonsai.Domain;
using Bonsai.Persistence.Helpers;
using FluentAssertions;
using NUnit.Framework;
using DB = Bonsai.Persistence.Model.Items;
using DBTagging = Bonsai.Persistence.Model.Tagging;

namespace Test.Bonsai.MappingTests
{
    [TestFixture]
    class EntityMapper_Items_Test
    {
        // ==================================== Pantry ====================================

        [Test]
        public void Pantry_ToDatabaseModel_ShouldMapEmptyPantry()
        {
            var pantry = new Pantry();
            DB.Pantry dbPantry;

            Action action = () => { EntityMapper.ToDatabaseModel(pantry); };
            action.Should().NotThrow<ArgumentNullException>("all class fields should be initialized");

            dbPantry = EntityMapper.ToDatabaseModel(pantry);
            dbPantry.Id.Should().Be(pantry.Id);
            dbPantry.Items.Should().NotBeNull();
            dbPantry.Items.Count.Should().Be(0);
        }

        [Test]
        public void Pantry_ToDatabaseModel_ShouldMapNullPantry()
        {
            Pantry pantry = null;
            DB.Pantry dbPantry = EntityMapper.ToDatabaseModel(pantry);
            dbPantry.Should().BeNull();
        }

        [Test]
        public void Pantry_ToDatabaseModel_ShouldMapNonEmptyPantry()
        {
            Pantry pantry = new Pantry
            {
                Id = 123,
                Items = new List<PantryItem>
                {
                    new PantryItem
                    {
                        Id = 1,
                        Quantity = new Quantity { Amount = 1, Unit = "ml"},
                        Item = new Item { Id = 1, Name = "Water" }
                    },
                    new PantryItem
                    {
                        Id = 2,
                        Quantity = new Quantity { Amount = 5, Unit = "g"},
                        Item = new Item { Id = 2, Name = "Juice" }
                    }
                }
            };

            DB.Pantry dbPantry = EntityMapper.ToDatabaseModel(pantry);

            dbPantry.Should().NotBeNull();
            dbPantry.Id.Should().Be(123);
            dbPantry.Items.Should().NotBeNullOrEmpty();
            dbPantry.Items.Count.Should().Be(2);
            dbPantry.Items.TrueForAll(i => i != null).Should().BeTrue();
        }

        [Test]
        public void Pantry_ToDomainModel_ShouldMapEmptyPantry()
        {
            var dbPantry = new DB.Pantry();
            Pantry pantry;

            Action action = () => { EntityMapper.ToDomainModel(dbPantry); };
            action.Should().NotThrow<ArgumentNullException>("all class fields should be initialized");

            pantry = EntityMapper.ToDomainModel(dbPantry);
            pantry.Id.Should().Be(dbPantry.Id);
            pantry.Items.Should().BeNullOrEmpty();
        }

        [Test]
        public void Pantry_ToDomainModel_ShouldMapNullPantry()
        {
            DB.Pantry dbPantry = null;
            Pantry pantry = EntityMapper.ToDomainModel(dbPantry);
            pantry.Should().BeNull();
        }

        [Test]
        public void Pantry_ToDomainModel_ShouldMapNonEmptyPantry()
        {
            DB.Pantry dbPantry = new DB.Pantry
            {
                Id = 123,
                Items = new List<DB.PantryItem>
                {
                    new DB.PantryItem
                    {
                        Id = 1,
                        Quantity = new Quantity { Amount = 1, Unit = "ml"},
                        Item = new DB.Item { Id = 1, Name = "Water" }
                    },
                    new DB.PantryItem
                    {
                        Id = 2,
                        Quantity = new Quantity { Amount = 5, Unit = "g"},
                        Item = new DB.Item { Id = 2, Name = "Juice" }
                    }
                }
            };

            Pantry pantry = EntityMapper.ToDomainModel(dbPantry);

            pantry.Should().NotBeNull();
            pantry.Id.Should().Be(123);
            pantry.Items.Should().NotBeNullOrEmpty();
            pantry.Items.Count.Should().Be(2);
            pantry.Items.TrueForAll(i => i != null).Should().BeTrue();
        }

        // ==================================== Item ====================================

        [Test]
        public void Item_ToDatabaseModel_ShouldMapNullItem()
        {
            Item item = null;
            DB.Item dbItem = EntityMapper.ToDatabaseModel(item);
            dbItem.Should().BeNull();
        }


        [Test]
        public void Item_ToDatabaseModel_ShouldMapNonNullItem()
        {
            Item item = new Item
            {
                Id = 1,
                Name = "Water"
            };

            DB.Item dbItem = EntityMapper.ToDatabaseModel(item);

            dbItem.Should().NotBeNull();
            dbItem.Id.Should().Be(1);
            dbItem.Name.Should().Be("Water");
            dbItem.Tags.Should().BeNullOrEmpty();
        }

        [Test]
        public void Item_ToDatabaseModel_ShouldMapTags()
        {
            Item item = new Item
            {
                Tags = new List<Tag>
                {
                    new Tag(), new Tag()
                }
            };

            DB.Item dbItem = EntityMapper.ToDatabaseModel(item);

            dbItem.Should().NotBeNull();
            dbItem.Tags.Should().NotBeNull();
            dbItem.Tags.Should().NotBeEmpty();
            dbItem.Tags.Count.Should().Be(2);
        }

        [Test]
        public void Item_ToDomainModel_ShouldMapNullItem()
        {
            DB.Item dbItem = null;
            Item item = EntityMapper.ToDomainModel(dbItem);
            item.Should().BeNull();
        }


        [Test]
        public void Item_ToDomainModel_ShouldMapNonNullItem()
        {
            DB.Item dbItem = new DB.Item
            {
                Id = 1,
                Name = "Water"
            };

            Item item = EntityMapper.ToDomainModel(dbItem);

            item.Should().NotBeNull();
            item.Id.Should().Be(1);
            item.Name.Should().Be("Water");
            item.Tags.Should().BeNullOrEmpty();
        }

        [Test]
        public void Item_ToDomainModel_ShouldMapTags()
        {
            DB.Item dbItem = new DB.Item
            {
                Tags = new List<DBTagging.ItemTag>()
                {
                    new DBTagging.ItemTag(),
                    new DBTagging.ItemTag()
                }
            }; 

            Item item = EntityMapper.ToDomainModel(dbItem);

            item.Should().NotBeNull();
            item.Tags.Should().NotBeNull();
            item.Tags.Should().NotBeEmpty();
            item.Tags.Count.Should().Be(2);
        }

        // ==================================== Pantry Item ====================================

        [Test]
        public void PantryItem_ToDatabaseModel_ShouldMapNullItem()
        {
            PantryItem item = null;
            DB.PantryItem dbItem = EntityMapper.ToDatabaseModel(item);
            dbItem.Should().BeNull();
        }


        [Test]
        public void PantryItem_ToDatabaseModel_ShouldMapNonNullItem()
        {
            PantryItem item = new PantryItem
            {
                Id = 1,
                Item = new Item { Id = 1, Name = "Water" },
                Quantity = new Quantity { Amount = 100, Unit = "ml" },
                BuyDate = DateTime.Parse("6/1/2018"),
                ExpirationDate = DateTime.Parse("6/1/2020")
            };

            DB.PantryItem dbItem = EntityMapper.ToDatabaseModel(item);

            dbItem.Should().NotBeNull();
            dbItem.Id.Should().Be(1);
            dbItem.Item.Should().NotBeNull();
            dbItem.Quantity.Should().NotBeNull();
            dbItem.Quantity.Amount.Should().Be(100);
            dbItem.Quantity.Unit.Should().Be("ml");
            dbItem.BuyDate.Should().Be(DateTime.Parse("6/1/2018"));
            dbItem.ExpirationDate.Should().Be(DateTime.Parse("6/1/2020"));
        }

        [Test]
        public void PantryItem_ToDatabaseModel_ShouldMapTags()
        {
            PantryItem item = new PantryItem
            {
                Tags = new List<Tag>
                {
                    new Tag(), new Tag()
                }
            };

            DB.PantryItem dbItem = EntityMapper.ToDatabaseModel(item);

            dbItem.Should().NotBeNull();
            dbItem.Tags.Should().NotBeNull();
            dbItem.Tags.Should().NotBeEmpty();
            dbItem.Tags.Count.Should().Be(2);
        }

        [Test]
        public void PantryItem_ToDomainModel_ShouldMapNullItem()
        {
            DB.PantryItem dbItem = null;
            PantryItem item = EntityMapper.ToDomainModel(dbItem);
            item.Should().BeNull();
        }


        [Test]
        public void PantryItem_ToDomainModel_ShouldMapNonNullItem()
        {
            DB.PantryItem dbItem = new DB.PantryItem
            {
                Id = 1,
                Item = new DB.Item(),
                Quantity = new Quantity { Amount = 100, Unit = "ml" },
                BuyDate = DateTime.Parse("6/1/2018"),
                ExpirationDate = DateTime.Parse("6/1/2020")
            };

            PantryItem item = EntityMapper.ToDomainModel(dbItem);

            dbItem.Should().NotBeNull();
            dbItem.Id.Should().Be(1);
            dbItem.Item.Should().NotBeNull();
            dbItem.Quantity.Should().NotBeNull();
            dbItem.Quantity.Amount.Should().Be(100);
            dbItem.Quantity.Unit.Should().Be("ml");
            dbItem.BuyDate.Should().Be(DateTime.Parse("6/1/2018"));
            dbItem.ExpirationDate.Should().Be(DateTime.Parse("6/1/2020"));
        }

        [Test]
        public void PantryItem_ToDomainModel_ShouldMapTags()
        {
            DB.PantryItem dbItem = new DB.PantryItem
            {
                Tags = new List<DBTagging.PantryItemTag>()
                {
                    new DBTagging.PantryItemTag(),
                    new DBTagging.PantryItemTag()
                }
            };

            PantryItem item = EntityMapper.ToDomainModel(dbItem);

            item.Should().NotBeNull();
            item.Tags.Should().NotBeNull();
            item.Tags.Should().NotBeEmpty();
            item.Tags.Count.Should().Be(2);
        }

        // ==================================== Recipe Item ====================================

        [Test]
        public void RecipeItem_ToDatabaseModel_ShouldMapNullItem()
        {
            RecipeItem item = null;
            DB.RecipeItem dbItem = EntityMapper.ToDatabaseModel(item);
            dbItem.Should().BeNull();
        }


        [Test]
        public void RecipeItem_ToDatabaseModel_ShouldMapNonNullItem()
        {
            RecipeItem item = new RecipeItem
            {
                Id = 1,
                Item = new Item { Id = 1, Name = "Onion" },
                RequiredQuantity = new Quantity { Amount = 100, Unit = "g" },
                Adjectives = new List<string> { "cooked", "chopped" }
            };

            DB.RecipeItem dbItem = EntityMapper.ToDatabaseModel(item);

            dbItem.Should().NotBeNull();
            dbItem.Id.Should().Be(1);
            dbItem.Item.Should().NotBeNull();
            dbItem.RequiredQuantity.Should().NotBeNull();
            dbItem.RequiredQuantity.Amount.Should().Be(100);
            dbItem.RequiredQuantity.Unit.Should().Be("g");
            dbItem.Adjectives.Should().NotBeNullOrEmpty();
            dbItem.Adjectives.Should().HaveCount(2);
            dbItem.Adjectives.Should().Contain(new List<string> { "cooked", "chopped" });
        }

        [Test]
        public void RecipeItem_ToDomainModel_ShouldMapNullItem()
        {
            DB.RecipeItem dbItem = null;
            RecipeItem item = EntityMapper.ToDomainModel(dbItem);
            item.Should().BeNull();
        }

        [Test]
        public void RecipeItem_ToDomainModel_ShouldMapNonNullItem()
        {
            DB.RecipeItem dbItem = new DB.RecipeItem
            {
                Id = 1,
                Item = new DB.Item { Id = 1, Name = "Onion" },
                RequiredQuantity = new Quantity { Amount = 100, Unit = "g" },
                Adjectives = new List<string> { "cooked", "chopped" }
            };

            RecipeItem item = EntityMapper.ToDomainModel(dbItem);

            dbItem.Should().NotBeNull();
            dbItem.Id.Should().Be(1);
            dbItem.Item.Should().NotBeNull();
            dbItem.RequiredQuantity.Should().NotBeNull();
            dbItem.RequiredQuantity.Amount.Should().Be(100);
            dbItem.RequiredQuantity.Unit.Should().Be("g");
            dbItem.Adjectives.Should().NotBeNullOrEmpty();
            dbItem.Adjectives.Should().HaveCount(2);
            dbItem.Adjectives.Should().Contain(new List<string> { "cooked", "chopped" });
        }


    }
}

SET NOCOUNT ON;

DECLARE @Seed TABLE (
    ProductId     UNIQUEIDENTIFIER,
    [Name]        NVARCHAR(200),
    [Description] NVARCHAR(MAX),
    [Price]       DECIMAL(10,2),
    [Category]    NVARCHAR(100),
    [PictureUrl]  NVARCHAR(400),
    StockQuantity INT,
    [Position]    NVARCHAR(50)
);

INSERT INTO @Seed (ProductId, [Name], [Description], [Price], [Category], [PictureUrl], StockQuantity, [Position]) VALUES
(NEWID(), N'Mermaid''s Breath Perfume', N'Captures the scent of ocean moonlight and forgotten songs.', 89.99, N'Enchanted', N'/uploads/products/MermaidPerfume.png', 40, N'A-01'),
(NEWID(), N'Moonlight Honey', N'Bees that only fly at night under full moons.', 19.99, N'Gourmet', N'/uploads/products/MoonlightHoney.png', 120, N'A-02'),
(NEWID(), N'Dragonfruit Phoenix Jam', N'Spreads itself. Toast not included.', 7.50, N'Gourmet', N'/uploads/products/DragonfruitJam.png', 150, N'A-03'),
(NEWID(), N'Unicorn Tears (250ml)', N'Limited-edition tears — 100% ethically harvested.', 49.99, N'Mythical', N'/uploads/products/UnicornTears.png', 60, N'A-04'),
(NEWID(), N'Candle of Eternal Tuesday', N'Burns forever but only smells like mild productivity.', 14.50, N'Arcane Home', N'/uploads/products/EternalTuesday.png', 80, N'A-05'),
(NEWID(), N'Baby Dragon Egg (Incubation Kit)', N'Comes warm. Handle with destiny.', 299.00, N'Mythical Pets', N'/uploads/products/BabyDragonEgg.png', 12, N'A-06'),
(NEWID(), N'Dryad Leaf Tea (20 bags)', N'Calms the soul, awakens the forest within.', 12.99, N'Herbal', N'/uploads/products/DryadTea.png', 90, N'A-07'),
(NEWID(), N'Bottled Thunder (Mini Flask)', N'Capture of one lightning bolt, 2017 vintage.', 24.99, N'Elemental', N'/uploads/products/BottledThunder.png', 55, N'A-08'),
(NEWID(), N'Wizard''s Beard Wax', N'For magical volume and mystical hold.', 16.99, N'Grooming', N'/uploads/products/WizardsWax.png', 75, N'A-09'),
(NEWID(), N'Chimera Fur Blanket', N'Soft as a cat, warm as a lion, confusing as a goat.', 189.00, N'Mythical Textiles', N'/uploads/products/ChimeraBlanket.png', 18, N'A-10'),
(NEWID(), N'Vampire''s Reserve (O Positive, Non-Alcoholic)', N'Rich aroma with eternal aftertaste.', 39.99, N'Gothic', N'/uploads/products/VampireReserve.png', 33, N'A-11'),
(NEWID(), N'Elven Dew Moisturizer', N'Collected at dawn in Lothlorien (or a place suspiciously similar).', 27.50, N'Beauty', N'/uploads/products/ElvenMoisturizer.png', 70, N'A-12'),
(NEWID(), N'Necromancer''s Black Salt', N'Enhances flavor and raises eyebrows.', 6.99, N'Gourmet', N'/uploads/products/BlackSalt.png', 140, N'A-13'),
(NEWID(), N'Pocket Watch of Lost Time', N'Doesn''t tell time, it steals it.', 74.99, N'Arcane Artifacts', N'/uploads/products/PocketWatch.png', 22, N'A-14'),
(NEWID(), N'Starlight Ink', N'Glows with your thoughts. For celestial correspondence only.', 22.00, N'Stationery', N'/uploads/products/StarlightInk.png', 65, N'A-15'),
(NEWID(), N'Philosophers Stone', N'Stone of all wisdom', 69.99, N'Enchanted', N'/uploads/products/PhilosophersStone.png', 39, N'C-13'),
(NEWID(), N'Silver Tip Crosbow Bolts x5', N'Beast killing accessory for every beast hunter.', 59.25, N'Accessories', N'/uploads/products/SilverTipCrosbowBolts.png', 56, N'C-14'),
(NEWID(), N'Werewolf Fur', N'Fur used in every powerful potion.', 23.15, N'Arcane Home', N'/uploads/products/WerewolfFur.png', 56, N'C-15'),
(NEWID(), N'Vampire Fangs', N'Home protection from spells and uninvited guests.', 70.59, N'Arcane Home', N'/uploads/products/VampireFangs.png', 18, N'C-16');

INSERT INTO dbo.Products (Id, [Name], [Description], [Price], [Category], [PictureUrl])
SELECT ProductId, [Name], [Description], [Price], [Category], [PictureUrl]
FROM @Seed;

INSERT INTO dbo.Warehouse (Id, ProductId, StockQuantity, [Position])
SELECT NEWID(), ProductId, StockQuantity, [Position]
FROM @Seed;

using H571H2_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace H571H2_HFT_2021222.Repository
{
    public class SteamDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Person> People { get; set; }

        public SteamDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("SteamDb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(game => game.Company)
                .WithMany(game => game.Game)
                .HasForeignKey(game => game.companyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasOne(company => company.Executive)
                .WithOne(company => company.Company)
                .HasForeignKey<Person>(company => company.companyID)
                .OnDelete(DeleteBehavior.Cascade);


            //Db Seed

            modelBuilder.Entity<Company>().HasData(new Company[]
            {
                //new Company("id#name#executive#country#employees"),
                new Company("1#Valve#1#USA#360"),
                new Company("2#KRAFTON, Inc.#2#South Korea#2100"),
                new Company("3#Facepunch Studios#3#UK#20"),
                new Company("4#Psyonix LLC#4#USA#189"),
                new Company("5#Ubisoft Montreal#5#Canada#2300"),
                new Company("6#Bohemia Interactive#6#Czech Republic#300"),
                new Company("7#Studio Wildcard#7#USA#35"),
                new Company("8#Rockstar North#8#UK#650"),
                new Company("9#Bethesda Game Studios#9#USA#420"),
                new Company("10#Behaviour Interactive Inc.#10#Canada#850"),
                new Company("11#Bungie#11#USA#900"),
                new Company("12#CAPCOM Co., Ltd.#12#Japan#2832"),
                new Company("13#Digital Extremes#13#Canada#300"),
                new Company("14#Grinding Gear Games#14#New Zealand#120"),
                new Company("15#Amazon Games#15#USA#2000"),
                new Company("16#NetEase Games#16#China#200"),
                new Company("17#SCS Software#17#Czech Republic#170"),
                new Company("18#OVERKILL - a Starbreeze Studio.#18#Sweden#180"),
                new Company("19#The Fun Pimps#19#USA#20"),
                new Company("20#Re-Logic#20#USA#12"),
                new Company("21#Firaxis Games#21#USA#180"),
                new Company("22#Respawn Entertainment#22#USA#315"),
                new Company("23#TaleWorlds Entertainment#23#Turkey#131"),
                new Company("24#FromSoftware Inc.#24#Japan#332"),
                new Company("25#Visual Concepts#25#USA#350"),
                new Company("26#Smartly Dressed Games#26#Canada#2"),
                new Company("27#Massive Entertainment#27#Sweden#650"),
                new Company("28#Gaijin Entertainment#28#Hungary#200"),
                new Company("29#Wargaming Group Limited#29#Cyprus#1750"),
                new Company("30#Crate Entertainment#30#USA#13"),
                new Company("31#CD PROJEKT RED#31#Poland#1111"),
                new Company("32#ConcernedApe#32#USA#1"),
                new Company("33#GuiGu Studio#33#China#100"),
                new Company("34#Titan Forge Games#34#USA#450"),
                new Company("35#Wallpaper Engine Team#35#Germany#2"),
                new Company("36#Gearbox Software#36#USA#1300"),
                new Company("37#Hello Games#37#UK#26"),
                new Company("38#Colossal Order Ltd.#38#Finland#17"),


            });

            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                //new Game("appid#genre#name#developer#positive#negative#average_forever#average_2weeks#price#initialprice#ccu"),
                new Game("1#moba#Dota 2#1#1437883#285737#35726#1523#0#0#546508"),
                new Game("2#fps#Counter-Strike: Global Offensive#1#5619875#749716#30200#766#0#0#730849"),
                new Game("3#battle royale#PUBG: BATTLEGROUNDS#2#1126362#883021#22329#778#0#0#407073"),
                new Game("4#survival#Rust#3#676194#101067#21374#1332#3999#3999#82414"),
                new Game("5#sports, driving#Rocket League#4#489784#61605#15582#452#0#0#38236"),
                new Game("6#fps#Tom Clancy's Rainbow Six Siege#5#915089#135174#13570#453#1999#1999#55863"),
                new Game("7#open world, fps#Arma 3#6#199795#21371#12798#857#2999#2999#17906"),
                new Game("8#survival, mmo#ARK: Survival Evolved#7#423287#93985#12089#1593#2999#2999#56731"),
                new Game("9#open world#Grand Theft Auto V#8#1129243#206769#12053#468#2998#2998#90523"),
                new Game("10#fps#Counter-Strike#1#195563#5028#11366#1383#999#999#13425"),
                new Game("11#sandbox#Garry's Mod#3#791415#27967#10927#957#999#999#28357"),
                new Game("12#fps#Team Fortress 2#1#806182#54992#9433#1722#0#0#80282"),
                new Game("13#open world, arpg#The Elder Scrolls V: Skyrim#9#292824#15955#8958#280#1999#1999#4587"),
                new Game("14#survival horror#Dead by Daylight#10#480242#108901#8688#475#999#1999#32091"),
                new Game("15#mmofps#Destiny 2#11#390063#72695#8622#1412#0#0#62263"),
                new Game("16#open world#Monster Hunter: World#12#299196#51643#8466#379#1499#2999#19527"),
                new Game("17#tps#Warframe#13#434017#46197#8023#978#0#0#53289"),
                new Game("18#arpg#Path of Exile#14#164190#16187#7810#683#0#0#9380"),
                new Game("19#mmorpg#New World#15#152961#72460#7543#56#3999#3999#27070"),
                new Game("20#battle royale#NARAKA: BLADEPOINT#16#78475#20628#7201#908#1999#1999#107335"),
                new Game("21#simulator, open world#Euro Truck Simulator 2#17#526188#13864#6842#332#1999#1999#31337"),
                new Game("22#fps#Counter-Strike: Source#1#132313#5248#6589#142#999#999#7062"),
                new Game("23#fps#PAYDAY 2#18#509620#62182#6540#1592#999#999#35116"),
                new Game("24#open world, survival#7 Days to Die#19#190194#25404#6342#827#2499#2499#24239"),
                new Game("25#open world, arpg, fps#Fallout 4#9#223419#52794#6187#235#1999#1999#15107"),
                new Game("26#sandbox#Terraria#20#926356#19887#6046#613#999#999#25562"),
                new Game("27#strategy#Sid Meier's Civilization V#21#176993#7111#5951#417#2999#2999#19922"),
                new Game("28#battle royale#Apex Legends#22#381110#58508#5553#816#0#0#274179"),
                new Game("29#arpg#Mount & Blade II: Bannerlord#23#162545#22835#5468#556#4999#4999#15528"),
                new Game("30#soulslike#ELDEN RING#24#404832#48448#5264#875#5999#5999#147736"),
                new Game("31#sports #NBA 2K20#25#30509#30105#5038#254#0#0#1940"),
                new Game("32#strategy#Sid Meier's Civilization VI#21#177827#35170#4927#772#5999#5999#36088"),
                new Game("33#soulslike#DARK SOULS III#24#306112#19806#4924#142#5999#5999#6300"),
                new Game("34#survival#Unturned#26#434916#40606#4718#2382#0#0#43225"),
                new Game("35#open world, tps#Tom Clancy's The Division#27#59486#26692#4233#0#2999#2999#631"),
                new Game("36#simulator#War Thunder#28#231640#63004#4199#796#0#0#47449"),
                new Game("37#tank simulator#World of Tanks Blitz#29#87740#21243#3515#601#0#0#22929"),
                new Game("38#arpg, dungeon crawler#Grim Dawn#30#69916#4895#3508#0#2499#2499#3997"),
                new Game("39#open world, arpg#The Witcher 3: Wild Hunt#31#604604#24619#3391#371#799#3999#22012"),
                new Game("40#farming simulator#Stardew Valley#32#449130#8702#3357#379#1499#1499#27589"),
                new Game("41#open world, arpg, sandbox#Tale of Immortal#33#108890#65477#3250#810#1999#1999#8039"),
                new Game("42#moba#SMITE#34#78856#19456#3220#371#0#0#17147"),
                new Game("43#open world, fps, arpg#Cyberpunk 2077#31#383054#128922#3066#693#2999#5999#15773"),
                new Game("44#other#Wallpaper Engine#35#491084#9902#2934#107#399#399#80096"),
                new Game("45#fps#Borderlands 2#36#244583#16475#2820#502#1999#1999#3770"),
                new Game("46#space, open world, survival#No Man's Sky#37#172034#56949#2804#310#5999#5999#19220"),
                new Game("47#city building, sandbox#Cities: Skylines#38#180120#12761#2779#219#2999#2999#17810"),



            });

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                //new Person("id#name#salary#age#companyID"),
                // Salaries and ages are RANDOM generated
                new Person("1#Gabe Newell#210807#53#1"),
                new Person("2#Kim Chang-han#808384#44#2"),
                new Person("3#Garry Newman#391659#46#3"),
                new Person("4#Dave Hagewood#476097#44#4"),
                new Person("5#Yannis Mallat#815266#56#5"),
                new Person("6#Marek Spanel#574371#46#6"),
                new Person("7#Doug Kennedy#968894#44#7"),
                new Person("8#Andrew Semple#713917#55#8"),
                new Person("9#Ashley Cheng#578596#36#9"),
                new Person("10#Remi Racine#838055#41#10"),
                new Person("11#Pete Parsons#650531#48#11"),
                new Person("12#Kenzo Tsujimoto#418026#37#12"),
                new Person("13#James Schmalz#787164#51#13"),
                new Person("14#Chris Wilson#617960#46#14"),
                new Person("15#Christoph Hartmann#499829#41#15"),
                new Person("16#Ding Lei#709205#40#16"),
                new Person("17#Pavel Sebor#773530#55#17"),
                new Person("18#Tobias Sjorgen#213562#56#18"),
                new Person("19#CHRISTIAN LANG#222219#43#19"),
                new Person("20#Andrew Spinks#920535#43#20"),
                new Person("21#Steve Martin#467306#59#21"),
                new Person("22#Vince Zampella#292973#60#22"),
                new Person("23#Armagan Yavuz#377372#47#23"),
                new Person("24#Hidetaka Miyazaki#545734#58#24"),
                new Person("25#Greg Thomas#228941#37#25"),
                new Person("26#Nelson Sexton#415273#38#26"),
                new Person("27#Thomas Andren#994882#50#27"),
                new Person("28#Anton Yudintsev#346533#51#28"),
                new Person("29#Victor Kislyi#263972#48#29"),
                new Person("30#Arthur Bruno#859792#59#30"),
                new Person("31#Adam Kicinski#507459#52#31"),
                new Person("32#Eric Barone#759588#51#32"),
                new Person("33#Huang Zhenlong#554509#58#33"),
                new Person("34#Erez Goren#838930#35#34"),
                new Person("35#Kristjan Skutta#266793#50#35"),
                new Person("36#Steve Jones#636537#39#36"),
                new Person("37#Sean Murray#268521#58#37"),
                new Person("38#Mariina Hallikainen#344204#40#38"),

            });


        }





    }
}
